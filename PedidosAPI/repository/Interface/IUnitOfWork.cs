namespace PedidosAPI.repository.Interface
{
    public interface IUnitOfWork
    {
        public ICategoriaRepository CategoriaRepository { get;}
        public ISubCategoriaRepository SubCategoriaRepository { get;}

        Task Commit();
    }
}
