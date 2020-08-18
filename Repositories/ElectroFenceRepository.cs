using System;
using System.Net.Http;
using System.Threading.Tasks;

using Dess.Api.DbContexts;
using Dess.Api.Entities;

using Microsoft.EntityFrameworkCore;

namespace Dess.Api.Repositories
{
	public class ElectroFenceRepository : RepositoryBase<ElectroFence, DessDbContext>, IElectroFenceRepository
    {
		private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient = new HttpClient();

		public ElectroFenceRepository(DessDbContext context,
            IHttpClientFactory httpClientFactory) : base(context) =>
            _httpClientFactory = httpClientFactory;

        public async Task<ElectroFence> GetAsync(string serial)
        {
            if (serial == null)
                throw new ArgumentNullException(nameof(serial));

            return await Entities.Include(entity => entity.Status).FirstOrDefaultAsync(entity => entity.Serial == serial);
        }

        public async Task<ElectroFence> GetForStatusAsync(int id)
		{
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            return await Entities.Include(entity => entity.Status).FirstOrDefaultAsync(entity => entity.Id == id);
        }
    }
}