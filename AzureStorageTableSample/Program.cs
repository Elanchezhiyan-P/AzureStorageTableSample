using Azure.Data.Tables;
using AzureStorageTableSample.Model;
using AzureStorageTableSample.Services;

namespace AzureStorageTableSample
{
    internal static class Program
    {
        private static readonly string _connectionString = "DefaultEndpointsProtocol=https;AccountName=****;AccountKey=****;EndpointSuffix=core.windows.net;";
        private static readonly string _employeeTbl = "EmployeeTbl";
        private static readonly string _addressTbl = "AddressTbl";

        static async Task Main(string[] args)
        {
            //Table creation process
            var storageEmpService = new AzureStorageService<EmployeeEntity>(_connectionString);
            await storageEmpService.CreateTableAsync(_employeeTbl);

            var storageAddService = new AzureStorageService<AddressEntity>(_connectionString);
            await storageAddService.CreateTableAsync(_addressTbl);

            //Table insertion process and retrival
            var employeeService = new AzureStorageService<EmployeeEntity>(_connectionString, _employeeTbl);
            var addressService = new AzureStorageService<AddressEntity>(_connectionString, _addressTbl);

            // Create and add employee entity
            var empPayload = new EmployeeEntity("Partition1", "Row1", "John Doe", "Developer", "Engineering", "12345");
            await employeeService.AddEntityAsync(empPayload);

            // Retrieve and display employee entity
            var retrievedPayload = await employeeService.GetEntityAsync("Partition1", "Row1");
            Console.WriteLine($"Employee Name: {retrievedPayload?.Name}");

            // Create and add address entity
            var addressPayload = new AddressEntity("Partition1", "Row1", "123 Main St", "Springfield", "IL", "62701", "USA");
            await addressService.AddEntityAsync(addressPayload);

            // Retrieve and display address entity
            var retrievedAddress = await addressService.GetEntityAsync("Partition1", "Row1");
            Console.WriteLine($"Address: {retrievedAddress?.Street}, {retrievedAddress?.City}");

            // Delete the Employee entity
            var deletedEmployee = await employeeService.DeleteEntityAsync("Partition1", "Row1");
            Console.WriteLine($"Employee has been deleted: {deletedEmployee?.Name}");

            // Delete the address entity
            var deletedAddress = await addressService.DeleteEntityAsync("Partition1", "Row1");
            Console.WriteLine($"Address has been deleted: {deletedAddress?.Street}, {deletedAddress?.City}");
        }
    }
}
