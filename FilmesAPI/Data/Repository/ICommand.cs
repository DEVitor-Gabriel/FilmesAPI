namespace FilmesAPI.Data.Repository
{
    interface ICommand<T>
    {
        void Inserir(T obj);
        void Alterar(int id, T obj);
        void Excluir(int id);
        
    } 
}