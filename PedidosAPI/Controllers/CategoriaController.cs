using Microsoft.AspNetCore.Mvc;
using PedidosAPI.Models;
using PedidosAPI.repository.Interface;
using PedidosAPI.Services.Interface;

namespace PedidosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService catService;
        private readonly IUnitOfWork _uof;

        public CategoriaController(ICategoriaService catService, IUnitOfWork uof)
        {
            this.catService = catService;
            _uof = uof;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            var categorias = await catService.GetCategoriasAsync();

            if(categorias is null) return NotFound();

            return Ok(categorias);
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
                try
                {
                    var categoriaEncontrada = await catService.GetCategoria(id);
                    return Ok(categoriaEncontrada);

                }
                catch (KeyNotFoundException ex)
                {
                    return NotFound(new { ex.Message });
                }
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria)
        {
            try
            {
                var categoriaCriada = await catService.CreateCategoria(categoria);

                return new CreatedAtRouteResult("ObterCategoria", new { id = categoriaCriada.Id }, categoriaCriada);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult<Categoria>> Put(int id, Categoria categoria)
        {
            if (id != categoria.Id) return BadRequest("Categoria não encontrada para atualizar....");

            try
            {
                var categoriaAtualizada = catService.UpdateCategoriaAsync(categoria);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao atualizar a categoria.", detalhe = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            try
            {
                await catService.RemoverCategoriaAsync(id);
                return NoContent();

            }catch(InvalidOperationException ex)
            {
                return BadRequest(new {ex.Message});
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { ex.Message });
            }
        }
    }
}
