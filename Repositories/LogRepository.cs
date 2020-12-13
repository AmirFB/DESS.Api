using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Dess.Api.DbContexts;
using Dess.Api.Entities;
using Dess.Api.Models.Filters;
using Dess.Api.Types;

namespace Dess.Api.Repositories
{
  public class LogRepository : RepositoryBase<SiteFault, DessDbContext>, ILogRepository
  {
    public LogRepository(DessDbContext context) : base(context) { }

    public async Task<IEnumerable<SiteFault>> GetAsync(ReportFilterDto filter)
    {
      var from = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
      var to = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

      if (filter.From.HasValue)
        from = from.AddMilliseconds((double)filter.From);

      if (filter.To.HasValue)
        to = to.AddMilliseconds((double)filter.To);

      var logs = await Entities
        .Include(l => l.Site)
        .Where(l => from.Year > 2000 ? l.OccuredOn >= from : true)
        .Where(l => to.Year > 2000 ? l.OccuredOn <= to : true)
        .Where(l =>
          filter.Type == ReportType.NotObviated ? l.ObviatedOn.Year <= 2000 :
          filter.Type == ReportType.Obviated ? l.ObviatedOn.Year > 2000 :
          filter.Type == ReportType.NotReseted ? l.ResetedOn.Year <= 2000 :
          filter.Type == ReportType.Reseted ? l.ResetedOn.Year > 2000 :
          true)
        .Where(l =>
          filter.AllGroups ? true :
          filter.SiteGroupIds.Contains(l.Site.GroupId))
        .Where(l =>
          filter.AllSites ? true :
          filter.SiteIds.Contains(l.SiteId))
        .Where(l => filter.FaultTypes.Contains(l.Type))
        .Where(l =>
          filter.SeenByAll ? true :
          filter.SeenBy.Intersect(l.SeenBy).Count() > 0)
        .Where(l =>
          filter.ResetedByAll ? true :
          filter.ResetedBy.Contains(l.ResetedBy))
        .ToListAsync();

      return logs;
    }
  }
}