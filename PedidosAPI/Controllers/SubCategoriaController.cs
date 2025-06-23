using Microsoft.AspNetCore.Mvc;
using PedidosAPI.Models;
using PedidosAPI.repository.Interface;

namespace PedidosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriaController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public SubCategoriaController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategoria>>> Get()
        {
            var subCategorias = await _uof.SubCategoriaRepository.GetAllAsync();

            if (subCategorias is null)
                return NotFound();

            return Ok(subCategorias);

        }

        [HttpGet("{id:int}", Name = "ObterSubCategoria")]
        public async Task<ActionResult<IEnumerable<SubCategoria>>> Get(int id)
        {
            var subCategoria = await _uof.SubCategoriaRepository.GetAsync(sc => sc.Id == id);

            if(subCategoria is null) return NotFound();

            return Ok(subCategoria);
        }

        [HttpPost]
        public async Task<ActionResult<SubCategoria>> Post(SubCategoria subCategoria)
        {
            if(subCategoria is null) return BadRequest("Dados Inválidos ou em branco");

            var SubCategoriaCriada = _uof.SubCategoriaRepository.Create(subCategoria);


            await _uof.Commit();

            return new CreatedAtRouteResult("ObterSubCategoria", new { id = SubCategoriaCriada.Id }, SubCategoriaCriada);
        }

        [HttpPut]
        public async Task<ActionResult<SubCategoria>> Put(int id, SubCategoria subCategoria)
        {
            if (id != subCategoria.Id) return BadRequest("Subcategoria não encontrada para atualizar");

            var categoriaAtualizada = _uof.SubCategoriaRepository.Update(subCategoria);
            await _uof.Commit();

            return Ok(categoriaAtualizada);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            var subCategoria = await _uof.SubCategoriaRepository.GetAsync(c => c.Id == id);

            if (subCategoria is null) return NotFound($"Categoria com id={id} não encontrada...");

           _uof.SubCategoriaRepository.Delete(subCategoria);

            await _uof.Commit();

            return Ok(subCategoria);
        }
    }
}
