using System.Collections.Generic;
using System.Threading.Tasks;

namespace R2Q.Application.Contracts.Orm
{
    /// <summary>
    /// Defines the contract for the ORM service
    /// </summary>
    public interface IOrmService
    {
        /// <summary>
        /// Executes the query and returns the response in the specified type.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        Task<IEnumerable<TResult>> ExecuteQueryAsync<TResult>(string query, IDictionary<string, object> parameters = null);

        /// <summary>
        /// This method will execute multiple queries and returns the result
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<List<dynamic>> ExecuteMultipleQuery(string query, IDictionary<string, object> parameters);

        /// <summary>
        /// This method will execute non-query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<int> ExecuteNonQueryAsync(string query, IDictionary<string, object> parameters);

        /// <summary>
        /// Initializes the ORM service.
        /// </summary>
        void InitializeOrmService();
    }
}
