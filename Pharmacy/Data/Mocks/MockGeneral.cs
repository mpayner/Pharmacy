using Pharmacy.Data.Interfaces;
using System.Reflection;

namespace Pharmacy.Data.Mocks
{
    public class MockGeneral<T> : IGeneral<T> where T : class
    {
        protected List<T> ListContent;

        public MockGeneral(List<T> listContent)
        {
            ListContent = listContent;
        }

        public void Add(T obj)
        {
            ListContent.Add(obj);
        }

        public void Add(List<T> list)
        {
            ListContent.AddRange(list);
        }

        public int Сount()
        {
            return ListContent.Count();
        }

        public T? Get(int id)
        {
            Type genericType = typeof(List<>).MakeGenericType(typeof(T));
            MethodInfo findMethod = genericType.GetMethod("Find");
            Delegate findDelegate = Delegate.CreateDelegate(typeof(Func<T, bool>), null, findMethod);

            return null;
        }


        public List<T> GetAll()
        {
            return ListContent.ToList();
        }

        public List<T> GetRange(int offset, int limit)
        {
            return ListContent.Skip(offset).Take(limit).ToList();
        }

        public void Remove(T obj)
        {
            ListContent.Remove(obj);
        }
    }
}
