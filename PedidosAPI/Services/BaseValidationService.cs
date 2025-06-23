using PedidosAPI.repository.Interface;
using System.Linq.Expressions;

namespace PedidosAPI.Services
{
    public class BaseValidationService
    {

        protected async Task ValidationExclusaoDependente<TDependente>(IGenericRepository<TDependente> repository,
            Expression<Func<TDependente, bool>> foreignKeySelector, string entityName) where  TDependente : class
        {
            var dependentes = await repository.GetAsync(foreignKeySelector);

            if (dependentes != null) throw new InvalidOperationException($"Não foi possível exclui {entityName} pois ela possui dependentes");

        }
    }
}
