using BeerShelf.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerShelf.Model;

namespace BeerShelf.Data
{
    class BeerShelfUow : IBeerShelfUow, IDisposable
    {
        private BeerShelfDbContext DbContext { get; set; }

        public BeerShelfUow(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();

            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        public IRepository<Bottle> Bottles { get { return GetStandardRepo<Bottle>();} }
        public IRepository<User> Users { get { return GetStandardRepo<User>(); } }
        public void Commit()
        {
            DbContext.SaveChanges();
        }

        private void CreateDbContext()
        {
            DbContext = new BeerShelfDbContext();

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        protected IRepositoryProvider RepositoryProvider { get; set; }
        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>(); 
        }

        private T GetRepo<T>() where T :class
        {
            return RepositoryProvider.GetRepository<T>();
        }
    }
}
