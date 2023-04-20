using Pharmacy.Data.Database;
using Pharmacy.Data.Interfaces;

namespace Pharmacy.Data.Repository
{
    public class GeneralRepository<T> : IGeneral<T> where T : class
    {
        protected readonly AppDBContent DBContent;

        public GeneralRepository(AppDBContent dBContent)
        {
            DBContent = dBContent;
        }

        public void Add(T obj)
        {
            this.DBContent.Set<T>().Add(obj);
        }

        public void Add(List<T> list)
        {
            this.DBContent.Set<T>().AddRange(list);
        }

        public int Сount()
        {
            return this.DBContent.Set<T>().Count();
        }

        public T? Get(int id)
        {
            return this.DBContent.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return this.DBContent.Set<T>().ToList();
        }

        public List<T> GetRange(int offset, int limit)
        {
            return this.DBContent.Set<T>().Skip(offset).Take(limit).ToList();
        }

        public void Remove(T obj)
        {
            this.DBContent.Remove(obj);
        }
    }
}
