using BlueBoard.Domain;
using BlueBoard.Persistence;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBoard.API.Infrastructure
{
    public class DataSeeder
    {
        private readonly ILogger<DataSeeder> _logger;
        private readonly BlueBoardContext _context;

        public DataSeeder(ILogger<DataSeeder> logger, BlueBoardContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task SeedAsync()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await SeedCountries();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message, e);
                    transaction.Rollback();
                }
                finally
                {
                    transaction.Dispose();
                }
            }
        }

        private async Task SeedCountries()
        {
            _logger.LogInformation("Starting country seed");
            if (_context.Countries.Any())
            {
                _logger.LogInformation("Country seed not required");
                return;
            }
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Infrastructure", "Data", "country.json");
            var text = File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);

            var countries = data.Select(i => new Country { Iso = i.Key, Name = i.Value });
            _context.AddRange(countries);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Country seed finished");
        }
    }
}
