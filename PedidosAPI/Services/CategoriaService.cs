using PedidosAPI.Models;
using PedidosAPI.repository.Interface;
using PedidosAPI.Services.Interface;
using System.Runtime.InteropServices;

namespace PedidosAPI.Services
{
    public class CategoriaService : BaseValidationService, ICategoriaService
    {
        private readonly IUnitOfWork _uof;

        public CategoriaService(IUnitOfWork uof)
        {
            _uof = uof;
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            var categorias = await _uof.CategoriaRepository.GetAllAsync();

            return categorias;
        }

        public Task<Categoria?> GetCategoria(int id)
        {
            var categoria =  _uof.CategoriaRepository.GetAsync(c => c.Id == id);

            if (categoria is null) throw new KeyNotFoundException($"Categoria não encontrada....");

            return categoria;
        }

        public async Task<Categoria> CreateCategoria(Categoria categoria)
        {
            if (categoria == null) throw new KeyNotFoundException("Categoria não encontrada");

            await ValidationEntityExisting(
                _uof.CategoriaRepository,
                c => c.Id == categoria.Id,
                "Não é possivel cadastrar a categoria pois ela já existe !"
                );

            var categeoriaCriate =  _uof.CategoriaRepository.Create(categoria);
            await _uof.Commit();

            return categeoriaCriate;
        }

        public async Task<Categoria> UpdateCategoriaAsync(Categoria categoria)
        {

            var categoriaAtualizada = _uof.CategoriaRepository.Update(categoria);
            await _uof.Commit();

            return categoriaAtualizada;
           
        }

        public async Task RemoverCategoriaAsync(int id)
        {
            await ValidationEntityExisting(
                _uof.SubCategoriaRepository, 
                s => s.CategoriaId == id,
                "Não é possivel excluir a categoria "
                );

            var categoria = await _uof.CategoriaRepository.GetAsync(c => c.Id == id);

            if (categoria == null) throw new KeyNotFoundException("Categoria não encontrada !");

            _uof.CategoriaRepository.Delete(categoria);
        }


    }
}
