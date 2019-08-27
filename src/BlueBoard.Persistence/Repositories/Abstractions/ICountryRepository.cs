using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlueBoard.Domain;

namespace BlueBoard.Persistence.Repositories
{
    public interface ICountryRepository : IRepository
    {
        Task<IList<Country>> GetAllAsync();
    }
}
