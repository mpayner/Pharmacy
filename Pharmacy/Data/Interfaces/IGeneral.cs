namespace Pharmacy.Data.Interfaces
{
    public interface IGeneral <T>
    {
        public List<T> GetAll();
        public List<T> GetRange(int offset, int limit);
        public T? Get(int id);
        public void Add(T obj);

        public void Add(List<T> list);
        public void Remove(T obj);

        public int Сount();
    }
}
