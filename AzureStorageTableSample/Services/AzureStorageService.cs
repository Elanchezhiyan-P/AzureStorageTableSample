using Azure.Data.Tables;
using AzureStorageTableSample.Services.Interface;

namespace AzureStorageTableSample.Services
{
    internal class AzureStorageService<T> : IAzureStorageService<T> where T : class, ITableEntity, new()
    {
        private readonly TableClient _tableClient;
        private readonly TableServiceClient _tableServiceClient;

        public AzureStorageService(string connectionString)
        {
            _tableServiceClient = new TableServiceClient(connectionString);
        }
        
        public AzureStorageService(string connectionString, string tableName)
        {
            _tableClient = new TableClient(connectionString, tableName);
        }

        public async Task CreateTableAsync(string tableName)
        {
            var tableClient = _tableServiceClient.GetTableClient(tableName);
            await tableClient.CreateIfNotExistsAsync();
        }

        public async Task AddEntityAsync(T entity)
        {
            await _tableClient.UpsertEntityAsync(entity);
        }

        public async Task<T> GetEntityAsync(string partitionKey, string rowKey)
        {
            var response = await _tableClient.GetEntityAsync<T>(partitionKey, rowKey);
            return response.Value;
        }

        public async Task<T> DeleteEntityAsync(string partitionKey, string rowKey)
        {
            var entity = await _tableClient.GetEntityAsync<T>(partitionKey, rowKey);
            await _tableClient.DeleteEntityAsync(partitionKey, rowKey);
            return entity.Value;
        }
    }
}
