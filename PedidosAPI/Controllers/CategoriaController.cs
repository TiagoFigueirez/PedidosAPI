using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedidosAPI.Models;
using PedidosAPI.repository.Interface;

namespace PedidosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public CategoriaController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            var categorias = await _uof.CategoriaRepository.GetAllAsync();

            if(categorias is null) return NotFound();

            return Ok(categorias);
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            var categoria = await _uof.CategoriaRepository.GetAsync(c => c.Id == id);

            if(categoria is null) return NotFound($"Categoria não encontrada....");

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria)
        {
            if(categoria is null) return BadRequest("Dados inválidos ou em branco");

            var categoriaCriada = _uof.CategoriaRepository.Create(categoria);

             await _uof.Commit();

            return new CreatedAtRouteResult("ObterCategoria", new {id = categoriaCriada.Id}, categoriaCriada);
        }

        [HttpPut]
        public async Task<ActionResult<Categoria>> Put(int id, Categoria categoria)
        {
            if (id != categoria.Id) return BadRequest("Categoria não encontrada para atualizar....");

            var categoriaAtualizada = _uof.CategoriaRepository.Update(categoria);
            await _uof.Commit();

            return Ok(categoriaAtualizada);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            var categoria = await _uof.CategoriaRepository.GetAsync(c=>c.Id == id);

            if (categoria is null) return NotFound($"Categoria com id={id} não encontrada...");

            categoria.IsAtivo = false;

            _uof.CategoriaRepository.Update(categoria);
            await _uof.Commit();


            return Ok(categoria);
        }
    }
}
