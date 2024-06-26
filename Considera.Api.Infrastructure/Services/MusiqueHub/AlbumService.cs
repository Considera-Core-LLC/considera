﻿using Considera.Api.Core.Interfaces.MusiqueHub;
using Considera.Api.Core.Interfaces.MusiqueHub.Services;
using Considera.Api.Core.Models.MusiqueHub;
using Considera.Api.Core.Models.MusiqueHub.DTO;

namespace Considera.Api.Infrastructure.Services.MusiqueHub;

public class AlbumService : IAlbumService
{
    private readonly IAlbumsRepository _albumsRepository;
    private readonly IArtistAlbumsRepository _artistAlbumsRepository;
    private readonly IArtistsRepository _artistsRepository;
    private readonly IGenresRepository _genresRepository;

    public AlbumService(
        IAlbumsRepository albumsRepository,
        IArtistAlbumsRepository artistAlbumsRepository,
        IArtistsRepository artistsRepository,
        IGenresRepository genresRepository)
    {
        _albumsRepository = albumsRepository;
        _artistAlbumsRepository = artistAlbumsRepository;
        _artistsRepository = artistsRepository;
        _genresRepository = genresRepository;
    }

    public async Task<IEnumerable<Album>> GetAlbums() => 
        await _albumsRepository.GetAll();
    
    public async Task<IEnumerable<Album>> GetAlbums(IEnumerable<string> albumIds) =>
        await _albumsRepository.Get(albumIds.Select(Guid.Parse));
    
    public async Task<IEnumerable<Album>> GetAlbums(IEnumerable<Guid> albumIds) =>
        await _albumsRepository.Get(albumIds);
    
    public async Task<IEnumerable<Album>> GetAlbumsByGenreId(string genreId) =>
        await _albumsRepository.GetAlbumsByGenreId(Guid.Parse(genreId));
    
    public async Task<IEnumerable<Album>> GetAlbumsByGenreIds(IEnumerable<string> genreIds) =>
        await _albumsRepository.GetAlbumsByGenreIds(genreIds.Select(Guid.Parse));

    public Task<Album?> GetAlbum(string name) => 
        throw new NotImplementedException();

    public async Task<IEnumerable<Album>> GetAlbumsFromGenreAlbums(IEnumerable<string> genreAlbumIds) =>
        null;  
    //(await _artistAlbumsRepository.Get(genreAlbumIds.Select(Guid.Parse)))
        //.Select(x => x.Album);

    public Task<bool> HasAlbum(string name) => 
        throw new NotImplementedException();
    
    public async Task AddAlbum(Album album, string artistIds, string genreIds) =>
        await AddAlbum(album, 
            artistIds.Split(",").Select(Guid.Parse), 
            genreIds.Split(",").Select(Guid.Parse));

    public async Task AddAlbum(
        Album album, 
        IEnumerable<Guid> artistIds, 
        IEnumerable<Guid> genreIds)
    {
        await _albumsRepository.AddAlbum(album);
        
        var artists = await _artistsRepository.Get(artistIds);
        await _artistAlbumsRepository.MapArtistsToAlbum(album, artists);
        
        var genres = await _genresRepository.Get(genreIds);
        await _artistAlbumsRepository.MapGenresToAlbum(album, genres);
    }

    
    public async Task Add(AlbumDto dto)
    {
        var album = await Add(AlbumDto.MapTo(dto));

        if (dto.ArtistIds is not null)
        {
            var artists = await _artistsRepository.Get(dto.ArtistIds.Select(Guid.Parse));
            await _artistAlbumsRepository.MapArtistsToAlbum(album, artists);
        }
        
        if (dto.GenreIds is not null)
        {
            var genres = await _genresRepository.Get(dto.GenreIds.Select(Guid.Parse));
            await _artistAlbumsRepository.MapGenresToAlbum(album, genres);
        }
    }

    private async Task<Album?> Add(Album album) =>
        await _albumsRepository.Add(album);
}
