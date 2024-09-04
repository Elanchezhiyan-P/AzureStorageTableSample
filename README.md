# AzureStorageService

## Overview

The `AzureStorageService<T>` class provides a generic implementation for interacting with Azure Table Storage in a cost-efficient manner. This service allows you to create tables, add entities, retrieve entities, and delete entities using Azure's Table Storage API. The implementation leverages the Azure SDK for .NET to ensure seamless integration and management of Azure Table Storage resources.

## Table of Contents

1. [Prerequisites](#prerequisites)
2. [Setup and Configuration](#setup-and-configuration)
3. [Usage](#usage)
4. [Cost Efficiency](#cost-efficiency)

## Prerequisites

- .NET 6.0 or later
- Azure SDK for .NET (`Azure.Data.Tables` package)
- Azure Storage Account

## Setup and Configuration

### Install the Required NuGet Package

To use this service, you need to add the `Azure.Data.Tables` NuGet package to your project. You can do this via the NuGet Package Manager or by running the following command in the Package Manager Console:

```bash
dotnet add package Azure.Data.Tables
```

### Connection String
You will need an Azure Storage Account connection string to interact with the Table Storage. You can find this in the Azure Portal under your Storage Account's "Access Keys" section.

## Usage

### Instantiate the Service

```CSharp
// For operations on a specific table
var storageService = new AzureStorageService<MyEntity>(connectionString, "myTableName");

// For creating tables and managing Table Service Client
var tableService = new AzureStorageService<MyEntity>(connectionString);
```
### Create a Table

```CSharp
await tableService.CreateTableAsync("myTableName");
```

### Add or Update an Entity

```CSharp
var myEntity = new MyEntity { PartitionKey = "partition1", RowKey = "row1", Property = "value" };
await storageService.AddEntityAsync(myEntity);
```

### Get an Entity

```CSharp
var entity = await storageService.GetEntityAsync("partition1", "row1");
```

### Delete an Entity

```CSharp
var deletedEntity = await storageService.DeleteEntityAsync("partition1", "row1");
```

## Cost Efficiency

Azure Table Storage is a highly cost-efficient storage solution due to its:

1. **Scalability:** Supports a high volume of transactions at a low cost.
2. **Pay-As-You-Go Pricing:** Only pay for the storage and transactions you use.
3. **Low Storage Costs:** Charges are based on the amount of data stored and the number of transactions performed, making it economical for large datasets with infrequent updates.

By using TableClient for CRUD operations and leveraging asynchronous methods, this implementation minimizes resource consumption and operational costs.