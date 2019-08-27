using BlueBoard.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBoard.Persistence.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly BlueBoardContext _context;

        public CountryRepository(BlueBoardContext context)
        {
            _context = context;
        }

        public async Task<IList<Country>> GetAllAsync()
        {
            return await _context.Countries.OrderBy(i => i.Name).ToListAsync();
        }
    }
}
