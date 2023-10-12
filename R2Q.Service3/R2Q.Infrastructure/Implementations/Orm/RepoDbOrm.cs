using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using R2Q.Application.Contracts.Orm;
using R2Q.Infrastructure.Constants;

namespace R2Q.Infrastructure.Implementations.Orm
{
    /// <summary>
    /// The RepoDb ORM for the Organization service database
    /// </summary>
    /// <seealso cref="IOrmService" />
    public class RepoDbOrm : IOrmService
    {
        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string? connectionString;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<RepoDbOrm> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepoDbOrm"/> class.
        /// </summary>
        /// <param name="tenantInfo"></param>
        /// <param name="logger"></param>
        public RepoDbOrm(
            IConfiguration configuration,
            ILogger<RepoDbOrm> logger)
        {
            connectionString = configuration.GetConnectionString(InfraConstants.ConnectionStringKey);
            this.logger = logger;
        }

        /// <summary>
        /// Executes the query and returns the response in the specified type.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public async Task<IEnumerable<TResult>> ExecuteQueryAsync<TResult>(string query, IDictionary<string, object> parameters = null)
        {
            var results = new List<TResult>();

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }
                    }

                    using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            TResult result = default;
                            if (typeof(TResult).IsValueType || typeof(TResult) == typeof(string))
                            {
                                result = (TResult)reader[0];
                            }
                            else
                            {
                                // Handle custom mapping logic here if TResult is a complex type.
                                // For simplicity, this example assumes the first column represents the result.
                                // result = MapToObject<TResult>(reader);
                            }

                            results.Add(result);
                        }
                    }
                }
            }

            return results;
        }
        /// <summary>
        /// This method will execute non-query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<int> ExecuteNonQueryAsync(string query, IDictionary<string, object> parameters)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }
                    }

                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        /// <summary>
        /// ExecuteMultipleQuery
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<List<dynamic>> ExecuteMultipleQuery(string query, IDictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Initializes the ORM service.
        /// </summary>
        public void InitializeOrmService()
        {
            //PostgreSqlBootstrap.Initialize();
        }



    }
}
