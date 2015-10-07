using BeerShelf.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerShelf.Data
{
    public interface IRepositoryProvider
    {
        BeerShelfDbContext DbContext { get; set; }
        IRepository<T> GetRepositoryForEntityType<T>() where T : class;
        void SetRepository<T>(T repository);

        T GetRepository<T>();
       
    }
}
