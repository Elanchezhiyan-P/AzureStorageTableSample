using Azure.Data.Tables;
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageTableSample.Model
{
    public class EmployeeEntity : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string AddressRowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public EmployeeEntity() { }

        public EmployeeEntity(string partitionKey, string rowKey, string name, string position, string email, string addressRowKey)
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
            Name = name;
            Position = position;
            Email = email;
            AddressRowKey = addressRowKey;
        }
    }

    public class AddressEntity : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public AddressEntity() { }

        public AddressEntity(string partitionKey, string rowKey, string street, string city, string state, string zipCode, string country)
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode; 
            Country = country;
        }
    }
}
