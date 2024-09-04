using Azure.Data.Tables;

namespace AzureStorageTableSample.Services.Interface
{
    public interface IAzureStorageService<T> where T : class, ITableEntity, new()
    {
        Task CreateTableAsync(string tableName);
        Task AddEntityAsync(T entity);
        Task<T> GetEntityAsync(string partitionKey, string rowKey);
        Task<T> DeleteEntityAsync(string partitionKey, string rowKey);
    }
}
