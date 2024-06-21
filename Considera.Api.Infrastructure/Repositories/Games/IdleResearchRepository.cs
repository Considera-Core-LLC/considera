using Considera.Api.Core.Interfaces.Games;
using Considera.Api.Core.Models.Games;
using Microsoft.EntityFrameworkCore;

namespace Considera.Api.Infrastructure.Repositories.Games;

public class IdleResearchRepository : BaseRepository<IdleResearch>, IIdleResearchRepository
{
    public IdleResearchRepository(DbContext context) : base(context) {}
}