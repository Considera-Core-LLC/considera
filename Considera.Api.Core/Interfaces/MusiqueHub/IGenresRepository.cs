﻿using Considera.Api.Core.Models.MusiqueHub;

namespace Considera.Api.Core.Interfaces.MusiqueHub;

public interface IGenresRepository : IRepository<Genre>
{
    Task<IEnumerable<Genre>> GetAll(bool withAlbums, bool withArtists);
    Task AddGenre(Genre genre);
    Task<IEnumerable<Genre>> AssignSubgenres(IEnumerable<Genre> genres);
    Task<bool> GenreExists(Genre genre);
    Task<IEnumerable<Genre>> FetchAllWithAlbums();
    Task<Genre?> FetchByName(string name, bool readOnly = true);
    Task<Genre?> FetchById(Guid genreId, bool readOnly = true);
    Task<Genre?> FetchByGenre(Genre genre, bool readOnly = true);
    Task<Genre> ModifyGenre(Guid genreId, string name, string desc);
}