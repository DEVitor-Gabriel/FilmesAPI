namespace FilmesAPI.Data.Repository
{
    interface IQuery<T>
    {
        ICollection<T> BuscarTodos();
        T BuscarPorId(int id);
    } 
}