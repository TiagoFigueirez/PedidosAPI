using PedidosAPI.repository.Interface;
using System.Linq.Expressions;

namespace PedidosAPI.Services
{
    public class BaseService
    {
        //essa classe armazena metodos comuns a todos os Serviços

        protected async Task ValidationEntityExisting<TDependente>(IGenericRepository<TDependente> repository,
            Expression<Func<TDependente, bool>> foreignKeySelector, string messege) where  TDependente : class
        {
            var existente = await repository.GetAsync(foreignKeySelector);

            if (existente != null) throw new InvalidOperationException(messege);

        }
    }
}
