using PedidosAPI.repository.Interface;
using PedidosAPI.Services.Interface;

namespace PedidosAPI.Services
{
    public class CategoriaService : BaseValidationService, ICategoriaService
    {
        private readonly IUnitOfWork _uof;

        public CategoriaService(IUnitOfWork uof)
        {
            _uof = uof;
        }

        public async Task RemoverCategoria(int id)
        {
            await ValidationExclusaoDependente(
                _uof.SubCategoriaRepository, 
                s => s.CategoriaId == id,
                "Categoria"
                );

            var categoria = await _uof.CategoriaRepository.GetAsync(c => c.Id == id);

            if (categoria == null) throw new KeyNotFoundException("Categoria não encontrada !");

            _uof.CategoriaRepository.Delete(categoria);
        }


    }
}
