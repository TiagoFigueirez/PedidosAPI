using Microsoft.AspNetCore.Mvc;
using PedidosAPI.Models;
using PedidosAPI.Services.Interface;

namespace PedidosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _prodtSerive;

        public ProdutoController(IProdutoService prodtSerive)
        {
            _prodtSerive = prodtSerive;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> Get()
        {
            var produtos =  await _prodtSerive.GetProdutosAsync();

            if (produtos is null) return NotFound();

            return Ok(produtos);
        }

        [HttpGet("{id:int}",Name ="ObterProduto")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            try
            {
                var produto = await _prodtSerive.GetProduto(id);
                return Ok(produto);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> Post(Produto produto)
        {
            try
            {
                var produtoCriado = await _prodtSerive.CreateProduto(produto);
                return new CreatedAtRouteResult("ObterProduto", new { id = produtoCriado.Id }, produtoCriado);
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
        public async Task<ActionResult<Produto>> Put(int id, Produto produto)
        {
            if (id != produto.Id) return BadRequest("Produto não encontrado");

            try
            {
                var produtoAtualizado = await _prodtSerive.UpdateProdutoAsync(produto);
                return Ok(produtoAtualizado);
            }catch(KeyNotFoundException ex)
            {
                return NotFound(new {ex.Message});
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(new { ex.Message });
            } 

        }

        [HttpDelete]
        public async Task<ActionResult<Produto>> Delete(int id)
        {
            try
            {
                await _prodtSerive.RemoverProdutoAsync(id);
                return Ok();
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
    }
}
