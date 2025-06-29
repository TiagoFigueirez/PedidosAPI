using PedidosAPI.Models;
using PedidosAPI.repository.Interface;
using PedidosAPI.Services.Interface;

namespace PedidosAPI.Services
{
    public class SubCategoriaService : BaseService, ISubCategoriaService
    {

        private readonly IUnitOfWork _uof;

        public SubCategoriaService(IUnitOfWork uof)
        {
            _uof = uof;
        }

        public async Task<IEnumerable<SubCategoria>> GetSubCategoriasAsync()
        {
            var subCategorias = await _uof.SubCategoriaRepository.GetAllAsync();

            return subCategorias;
           
        }

        public async Task<SubCategoria> GetSubCategoria(int id)
        {
            var subCategoria = await _uof.SubCategoriaRepository.GetAsync(s => s.Id == id);

            if(subCategoria is null) throw new KeyNotFoundException("Subcategoria não encontrada");

            return subCategoria;
        }

        public async Task<SubCategoria> CreateSubCategoria(SubCategoria subCategoria)
        {
            if (subCategoria is null) throw new KeyNotFoundException("Dados em branco");

            await ValidationEntityExisting(
                _uof.SubCategoriaRepository,
                s => s.Nome == subCategoria.Nome,
                "Nome da categoria já existe !!!"
                );

            var subCategoriaCriada = _uof.SubCategoriaRepository.Create(subCategoria);
            await _uof.Commit();

            return subCategoria;
        }

        public async Task<SubCategoria> UpdateSubCategoriaAsync(SubCategoria subCategoria)
        {
            await ValidationEntityExisting(
                _uof.SubCategoriaRepository,
                s => s.Nome == subCategoria.Nome,
                "Já existe uma Subcategoria com esse nome !!"
                );

            var subCategoriaAtualizada = _uof.SubCategoriaRepository.Update(subCategoria);
            await _uof.Commit();
            return subCategoria;
        }
        public async Task RemoverSubCategoriaAsync(int id)
        {
            await ValidationEntityExisting(
                _uof.ProdutoRepository,
                p => p.SubcategoriaId == id,
                "Não é possivel excluir a categoria pois existe pelo menos 1 produto atrelada a ela"
                );

            var subCategoria = await _uof.SubCategoriaRepository.GetAsync(s => s.Id == id);

            if (subCategoria is null) throw new KeyNotFoundException("subCategoria não encontrada para excluir");
            _uof.SubCategoriaRepository.Delete(subCategoria);

        }
    }
}
