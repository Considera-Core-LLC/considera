using System.Globalization;
using Amazon.CloudFront;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Amazon.S3.Util;
using ConsideraDevApi.Core.Interfaces.MusiqueHub;
using ConsideraDevApi.Core.Interfaces.MusiqueHub.Services;
using ConsideraDevApi.Core.Models.MusiqueHub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConsideraDev.Api.Controllers.Api.MusiqueHub;

[ApiController]
[Route("api/musique/[controller]")]
public class ContentManagerController : ControllerBase
{
    private readonly string? BucketName;
    private readonly string? CloudFrontDomain;
    private readonly string? CloudFrontKeyId;
    private readonly long MB = (long)Math.Pow(2, 20);
    private readonly int ExpirationDurationInHours;
    
    private readonly IAmazonS3 _s3Client;
    private readonly AwsSettings _awsSettings;
    private readonly IMusiqueHubService _musiqueHubService;

    public ContentManagerController(
        IAmazonS3 s3Client, 
        IOptions<AwsSettings> awsSettings, 
        IMusiqueHubService musiqueHubService,
        IConfiguration configuration)
    {
        _s3Client = s3Client;
        _musiqueHubService = musiqueHubService;
        _awsSettings = awsSettings.Value;
        BucketName = configuration["S3:BucketName"];
        CloudFrontDomain = configuration["CloudFrontDomain"];
        CloudFrontKeyId = configuration["CloudFrontKeyId"];
        ExpirationDurationInHours = int.TryParse(configuration["S3:ObjectExpirationHours"], out var result) ? result : 1;
    }
    [HttpPost]
    public async Task<IActionResult> AddAlbum(IFormFile file)
    {
        try
        {
            var key = Path.GetRandomFileName() + Guid.NewGuid().ToString() + Path.GetExtension(file.FileName).ToLowerInvariant();

            if (await UploadFileToS3(file, key))
            {
                var getUrlRequest = new GetPreSignedUrlRequest
                {
                    BucketName = BucketName,
                    Key = key,
                    Expires = DateTime.UtcNow.AddHours(ExpirationDurationInHours),
                };
                Console.WriteLine(key);
                Console.WriteLine(GetPrivateUrl(key));
                //await _notificationService.SendUploadNotification("hello");
                return Ok(GetPrivateUrl(key));
            }

            return null;
        }
        catch (AmazonS3Exception)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }
    
    private async Task<bool> UploadFileToS3(IFormFile file, string key)
    {
        if (!await AmazonS3Util.DoesS3BucketExistV2Async(_s3Client, BucketName)) return false;
        
        var transferUtilityConfig = new TransferUtilityConfig
        {
            ConcurrentServiceRequests = 5,
            MinSizeBeforePartUpload = 20 * MB,
        };

        using var transferUtility = new TransferUtility(_s3Client, transferUtilityConfig);
        
        var uploadRequest = new TransferUtilityUploadRequest
        {
            Key = key,
            BucketName = BucketName,
            InputStream = file.OpenReadStream(),
            PartSize = 20 * MB,
            StorageClass = S3StorageClass.Standard,
            ServerSideEncryptionMethod = ServerSideEncryptionMethod.AES256,
        };

        await transferUtility.UploadAsync(uploadRequest);
        return true;

    }
    
    [HttpGet]
    public async Task<IActionResult> GetAlbumCover(string fileName)
    {
        var response = await _s3Client.GetObjectAsync(BucketName, fileName);
        using var reader = new StreamReader(response.ResponseStream);
        var contents = await reader.ReadToEndAsync();
        return File(response.ResponseStream, response.Headers.ContentType);
    }
    
    private string GetPrivateUrl(string file) =>
        AmazonCloudFrontUrlSigner.GetCannedSignedURL(
            $"https://{CloudFrontDomain}/{file}",
            new StreamReader(@"rsa_private_key.pem"),
            CloudFrontKeyId,
            DateTime.Now.AddDays(7));
}