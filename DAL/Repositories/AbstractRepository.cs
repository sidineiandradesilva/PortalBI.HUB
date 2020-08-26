using System.Collections.Generic;
using System.Web.Configuration;

namespace DAL.Repositories
{
    public abstract class AbstractRepository<TEntity, TKey>
         where TEntity : class
    {
        protected string StringConnection { get; } = WebConfigurationManager.ConnectionStrings["minhaconexao"].ConnectionString;

        public abstract List<TEntity> GetAll(TEntity entity);
        public abstract TEntity GetById(TKey id);
        public abstract void Save(TEntity entity);
        public abstract void Update(TEntity entity);
        public abstract void Delete(TEntity entity);
        public abstract void DeleteById(TKey id);

    }
}
