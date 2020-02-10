using AutoShop_Shared.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Cosmos;

namespace AutoShop_Shared.Services
{
    public class CosmosDBRepository<T> : IRepository<T>
    {
        private readonly Container _container;
        public CosmosDBRepository(IOptionsMonitor<AppSettings> settings)
        {
            AppSettings appSettings = settings.CurrentValue;
            CosmosClient client = new
                    CosmosClient(appSettings.CosmosDBUrl, appSettings.CosmosDBKey);

            Database database = client.GetDatabase(appSettings.CosmosDatabase);
            _container = database.GetContainer(appSettings.CosmosContainer);

        }


        public List<T> GetItems(AppSettings settings)
        {
            string sqlQueryText = settings.QuerySelect + " " + settings.QueryWhere;
            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);

            FeedIterator<T> queryResultSetIterator =
                _container.GetItemQueryIterator<T>(queryDefinition);

            List<T> results = new List<T>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<T> currentResultSet =
                    queryResultSetIterator.ReadNextAsync().GetAwaiter().GetResult();

                results.AddRange(currentResultSet);
                //foreach (T item in currentResultSet)
                //{
                //    results.Add(item);
                //}
            }
            return results;
        }

        public T GetItem(string id = "", string partitionKey = "")
        {
            ItemResponse<T> response =
                _container.ReadItemAsync<T>(id, new PartitionKey(partitionKey)).GetAwaiter().GetResult();
            return response.Resource;
        }

        public T InsertItem(T item)
        {
            ItemResponse<T> response = _container.UpsertItemAsync<T>(item).GetAwaiter().GetResult();
            return response.Resource;

        }

        public T UpdateItem(T item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(string id = "", string partitionKey = "")
        {
            throw new NotImplementedException();
        }
    }
}
