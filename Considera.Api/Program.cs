using System.Text.Json.Serialization;
using Amazon.CloudFront;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Considera.Api.Core.Interfaces.Games;
using Considera.Api.Core.Interfaces.MusiqueHub;
using Considera.Api.Core.Interfaces.MusiqueHub.Services;
using Considera.Api.DbContexts;
using Considera.Api.Infrastructure.Repositories.Games;
using Considera.Api.Infrastructure.Repositories.MusiqueHub;
using Considera.Api.Infrastructure.Services;
using Considera.Api.Infrastructure.Services.MusiqueHub;
using Microsoft.EntityFrameworkCore;

namespace Considera.Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var container = new WindsorContainer();
        var host = CreateHostBuilder(args, container).Build();
        
        await InitializeAwsClientsAsync(args);

        await host.RunAsync();
    }
    
    private static IHostBuilder CreateHostBuilder(string[] args, IWindsorContainer container) =>
        Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new WindsorServiceProviderFactory()) // Integrate Castle Windsor
            .ConfigureWebHostDefaults(webBuilder =>
            {
                // Configure services and the request pipeline in the web host builder
                webBuilder.ConfigureServices(services =>
                    {
                        // ASP.NET Core services
                        services.AddControllers()
                            .AddJsonOptions(options =>
                            {
                                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                            });
                        services.AddSwaggerGen();
                        services.AddEndpointsApiExplorer();

                        // DbContexts
                        services.AddScoped<DbContext, GamesDbContext>();
                        services.AddScoped<DbContext, MusiqueHubDbContext>();
                        
                        // Repositories
                        services.AddScoped<IIdleResearchRepository, IdleResearchRepository>();
                        services.AddScoped<IAlbumsRepository, AlbumsRepository>();
                        services.AddScoped<IArtistsRepository, ArtistsRepository>();
                        services.AddScoped<IArtistAlbumsRepository, ArtistAlbumsRepository>();
                        services.AddScoped<ISongsRepository, SongsRepository>();
                        services.AddScoped<IGenresRepository, GenresRepository>();
                        services.AddScoped<IMusicRepository, MusicRepository>();
                        services.AddScoped<IUsersRepository, UsersRepository>();
                        
                        // Services
                        services.AddScoped<IGameService, GameService>();
                        services.AddScoped<IMusiqueHubService, MusiqueHubService>();
                        services.AddScoped<IArtistService, ArtistService>();
                        services.AddScoped<IAlbumService, AlbumService>();
                        services.AddScoped<IGenreService, GenreService>();
                        services.AddScoped<IUserService, UserService>();

                        // AWS Services
                        services.AddAWSService<IAmazonS3>();
                        services.AddAWSService<IAmazonCloudFront>();

                        services.AddCors(options => 
                            options.AddPolicy("CorsPolicy", builder => 
                                builder.WithOrigins("http://localhost:4200")
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                                    .AllowCredentials()));
                    })
                    .Configure(app =>
                    {
                        var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
                    
                        if (env.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                            app.UseSwagger();
                            app.UseSwaggerUI();
                        }
                    
                        app.UseRouting();
                        app.UseCors("CorsPolicy");
                        app.UseEndpoints(endpoints => endpoints.MapControllers());
                    });
            });

    private static async Task InitializeAwsClientsAsync(string[] args)
    {
        return;
        var ssoCreds = LoadSsoCredentials("default");
        var ssoProfileClient = new AmazonSecurityTokenServiceClient(ssoCreds);
        Console.WriteLine($"\nSSO Profile:\n {await ssoProfileClient.GetCallerIdentityArn()}");

        var s3Client = new AmazonS3Client(ssoCreds);
        if (GetBucketName(args, out string bucketName))
        {
            try
            {
                Console.WriteLine($"\nCreating bucket {bucketName}...");
                var createResponse = await s3Client.PutBucketAsync(bucketName);
                Console.WriteLine($"Result: {createResponse.HttpStatusCode}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught exception when creating a bucket:");
                Console.WriteLine(e.Message);
            }
        }

        Console.WriteLine("\nGetting a list of your buckets...");
        var listResponse = await s3Client.ListBucketsAsync();
        Console.WriteLine($"Number of buckets: {listResponse.Buckets.Count}");
        foreach (var b in listResponse.Buckets)
        {
            Console.WriteLine(b.BucketName);
        }
        Console.WriteLine();
    }

    private static bool GetBucketName(string[] args, out string bucketName)
    {
        bucketName = string.Empty;
        if (args.Length == 0)
        {
            Console.WriteLine("\nNo arguments specified. Will simply list your Amazon S3 buckets." +
                              "\nIf you wish to create a bucket, supply a valid, globally unique bucket name.");
            return false;
        }

        if (args.Length == 1)
        {
            bucketName = args[0];
            return true;
        }

        Console.WriteLine("\nToo many arguments specified." +
                          "\n\nUsage: S3CreateAndList [bucket_name]" +
                          "\n - bucket_name: A valid, globally unique bucket name." +
                          "\n - If bucket_name isn't supplied, this utility simply lists your buckets.");
        Environment.Exit(1);
        return false;
    }

    static AWSCredentials LoadSsoCredentials(string profile)
    {
        var chain = new CredentialProfileStoreChain();
        if (!chain.TryGetAWSCredentials(profile, out var credentials))
            throw new Exception($"Failed to find the {profile} profile");
        return credentials;
    }
}

// Class to read the caller's identity.
public static class Extensions
{
    public static async Task<string> GetCallerIdentityArn(this IAmazonSecurityTokenService stsClient)
    {
        var response = await stsClient.GetCallerIdentityAsync(new GetCallerIdentityRequest());
        return response.Arn;
    }
}