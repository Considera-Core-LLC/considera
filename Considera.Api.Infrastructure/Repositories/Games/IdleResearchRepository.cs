using ConsideraDevApi.Core.Interfaces;
using ConsideraDevApi.Core.Interfaces.Games;
using ConsideraDevApi.Core.Models.Games;
using Microsoft.EntityFrameworkCore;

namespace ConsideraDevApi.Infrastructure.Repositories.Games;

public class IdleResearchRepository : BaseRepository<IdleResearch>, IIdleResearchRepository
{
    public IdleResearchRepository(DbContext context) : base(context) {}
}