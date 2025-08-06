using System.Text.Json;

namespace Repository.Json;

public class GenericRepository : IGenericRepository/* <EntityData> */
{
    private string nameInclude = string.Empty;
    public T Create<T>(T entity)
    {

        var id = typeof(T).GetProperty("Id");
        var idIncrementado = GetLastId<T>() + 1;

        entity.GetType().GetProperty("Id").SetValue(entity, idIncrementado);

        IList<T> newJsonData = ReadAll<T>();
        newJsonData.Add(entity);

        var nameRepository = entity.GetType().Name;
        File.WriteAllText(MachineExplorer.GetFilePath(nameRepository),
             JsonSerializer.Serialize(newJsonData));

        return GetById<T>(GetLastId<T>());
    }
    public IList<T> ReadAll<T>()
    {

        var y = typeof(T);
        var nameRepository = nameInclude == string.Empty ? typeof(T).Name : nameInclude;

        string jsonObject = File.ReadAllText(MachineExplorer.GetFilePath(nameRepository));

        List<T> lstJsonData = JsonSerializer.Deserialize<List<T>>(jsonObject) ??
            throw new Exception($"Erro na leitura da coleção do banco de dados");

        return lstJsonData;
    }
    public T Update<T>(T entity)
    {


        int id = Convert.ToInt32(typeof(T).GetProperty("Id").GetValue(entity));

        IList<T> updatedJsonData = ReadAll<T>();

        int index = 0;
        bool removed = false;

        foreach (T item in ReadAll<T>())
        {
            object idLista = typeof(T).GetProperty("Id").GetValue(item);

            if (Convert.ToInt32(idLista) == id)
            {
                updatedJsonData.RemoveAt(index);
                removed = true;
            }

            index++;
        }

        if (removed)
            updatedJsonData.Add(entity);

        var nameRepository = entity.GetType().Name;
        File.WriteAllText(MachineExplorer.GetFilePath(nameRepository),
             JsonSerializer.Serialize(updatedJsonData));

        return GetById<T>(id);
    }

 
    public bool Delete<T>(T entity)
    {
        int id = Convert.ToInt32(typeof(T).GetProperty("Id").GetValue(entity));

        IList<T> updatedJsonData = ReadAll<T>();

        int index = 0;
        bool removed = false;

        foreach (T item in ReadAll<T>())
        {
            object idLista = typeof(T).GetProperty("Id").GetValue(item);

            if (Convert.ToInt32(idLista) == id)
            {
                updatedJsonData.RemoveAt(index);
                removed = true;
            }

            index++;
        }

        if (removed)
        {
            var nameRepository = entity.GetType().Name;
            File.WriteAllText(MachineExplorer.GetFilePath(nameRepository),
                 JsonSerializer.Serialize(updatedJsonData));
        }

        return removed;
    }
    public int GetLastId<T>() =>
         Convert.ToInt32(ReadAll<T>().Max(item => { return typeof(T).GetProperty("Id").GetValue(item); }));


    public T GetById<T>(int id)
    {
        try
        {

            T obj = new List<T>().FirstOrDefault(); // Gambiarra que funciona. 

            bool found = false;

            foreach (T item in ReadAll<T>())
            {
                object idLista = typeof(T).GetProperty("Id").GetValue(item);

                if (Convert.ToInt32(idLista) == id)
                {
                    obj = item;
                    found = true;
                    break;
                }
            }

            if (found)
            {
                nameInclude = string.Empty;
                return obj;
            }
            else
                throw new Exception($"Nenhuma ocorrência com o identificador {id} foi encontrada.");
        }   
        catch (System.Exception)
        {

            throw new Exception($"Nenhuma ocorrência com o identificador {id} foi encontrada.");

        }

    }

    internal T Include<T, TInclude>(T data, TInclude toInclude, bool repository = false)
    {

        object id = typeof(T).GetProperty("Id").GetValue(toInclude);
        nameInclude = toInclude.GetType().Name;

        if (Convert.ToInt32(id) > 0)
            Update(toInclude);
        else
            Create(toInclude);

        return data;
    }
    internal T IncludeRange<T, TInclude>(T data, List<TInclude> toInclude, bool repository = false)
    {
        toInclude.ForEach(item => Include(data, item));
        return data;
    }
}