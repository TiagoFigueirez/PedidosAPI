using Microsoft.AspNetCore.Mvc;
using PedidosAPI.Models;
using PedidosAPI.Services.Interface;

namespace PedidosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriaController : ControllerBase
    {
        private readonly ISubCategoriaService _subCatService;

        public SubCategoriaController(ISubCategoriaService subCatService)
        {
            _subCatService = subCatService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategoria>>> Get()
        {
            var subCategorias = await _subCatService.GetSubCategoriasAsync();

            if (subCategorias is null)
                return NotFound();

            return Ok(subCategorias);

        }

        [HttpGet("{id:int}", Name = "ObterSubCategoria")]
        public async Task<ActionResult<IEnumerable<SubCategoria>>> Get(int id)
        {
            try
            {
                var subCategoria = await _subCatService.GetSubCategoria(id);
                return Ok(subCategoria);
            }catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<SubCategoria>> Post(SubCategoria subCategoria)
        {
            try
            {
                var SubCategoriaCriada = await _subCatService.CreateSubCategoria(subCategoria);
                return new CreatedAtRouteResult("ObterSubCategoria", new { id = SubCategoriaCriada.Id }, SubCategoriaCriada);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { ex.Message });
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult<SubCategoria>> Put(int id, SubCategoria subCategoria)
        {
            if (id != subCategoria.Id) return BadRequest("Subcategoria não encontrada para atualizar");

            try
            {
                var subCategoriaAtualizada = await _subCatService.UpdateSubCategoriaAsync(subCategoria);
                return Ok(subCategoriaAtualizada);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { ex.Message });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao atualizar a Subcategoria.", detalhe = ex.Message });
            }
            
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            try
            {
                await _subCatService.RemoverSubCategoriaAsync(id);
                return NoContent();
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(new { ex.Message });
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { ex.Message });
            }
        }
    }
}
