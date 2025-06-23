using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedidosAPI.Models;
using PedidosAPI.repository.Interface;
using System.Reflection.Metadata.Ecma335;

namespace PedidosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public ProdutoController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> Get()
        {
            var produtos =  await _uof.ProdutoRepository.GetAllAsync();

            if (produtos is null) return NotFound();

            return Ok(produtos);
        }

        [HttpGet("{id:int}",Name ="ObterProduto")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            var produto = await _uof.ProdutoRepository.GetAsync(p => p.Id == id);

            if(produto is null) return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> Post(Produto produto)
        {
            if (produto is null) return BadRequest();

            var produtoCriado = _uof.ProdutoRepository.Create(produto);

            await _uof.Commit();

            return new CreatedAtRouteResult("ObterProduto", new { id = produtoCriado.Id }, produtoCriado);
        }

        public async Task<ActionResult<Produto>> Put(int id, Produto produto)
        {
            if (id != produto.Id) return BadRequest("Produto não encontrado");

            var produtoAtualizado = _uof.ProdutoRepository.Update(produto);
            await _uof.Commit();

            return Ok(produtoAtualizado);   

        }

        public async Task<ActionResult<Produto>> Delete(int id)
        {
            var produto = await _uof.ProdutoRepository.GetAsync(p => p.Id == id);

            if (produto is null) return NotFound();

            _uof.ProdutoRepository.Delete(produto);
            await _uof.Commit();

            return Ok(produto);
        }
    }
}
