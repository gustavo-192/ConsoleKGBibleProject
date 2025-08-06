namespace Repository.Json;

public interface IGenericRepository
{
    public T Create<T>(T entity);
    public IList<T> ReadAll<T>();
    public T Update<T>(T entity);
    public bool Delete<T>(T entity);
    public int GetLastId<T>();
    public T GetById<T>(int id);

}