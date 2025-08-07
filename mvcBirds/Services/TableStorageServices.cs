using Azure;
using Azure.Data.Tables;
using mvcBirds.Models;

namespace mvcBirds.Services
{
    public class TableStorageServices
    {
        private readonly TableClient _birderTableClient;
        private readonly TableClient _birdTableClient;
        public TableStorageServices(string connectionString)
        {
            _birderTableClient = new TableClient(connectionString, "birder");
            _birdTableClient = new TableClient(connectionString, "bird");
        }
        public async Task<List<Birder>> GetAllBirdersAsync()
        {
            var birders = new List<Birder>();
            await foreach (var birder in _birderTableClient.QueryAsync<Birder>())
            {
                birders.Add(birder);
            }
            return birders;
        }
        public async Task AddBirderAsync(Birder birder)
        {
            if (string.IsNullOrEmpty(birder.PartitionKey) || string.IsNullOrEmpty(birder.RowKey))
            {
                throw new ArgumentException("PartitionKey and RowKey must be set.");
            }

            try
            {
                await _birderTableClient.AddEntityAsync(birder);
            }
            catch (RequestFailedException ex)
            {
                throw new InvalidOperationException("Error adding entity to Table Storage", ex);
            }
        }
        public async Task DeleteBirderAsync(string partitionKey, string rowKey)
        {
            await _birderTableClient.DeleteEntityAsync(partitionKey, rowKey);
        }

        public async Task<List<Bird>> GetAllBirdsAsync()
        {
            var birds = new List<Bird>();
            await foreach (var bird in _birdTableClient.QueryAsync<Bird>())
            {
                birds.Add(bird);
            }
            return birds;
        }

        public async Task AddBirdAsync(Bird bird)
        {
            if (string.IsNullOrEmpty(bird.PartitionKey) || string.IsNullOrEmpty(bird.RowKey))
                throw new ArgumentException("PartitionKey and RowKey must be set.");

            try
            {
                await _birdTableClient.AddEntityAsync(bird);
            }
            catch (RequestFailedException ex)
            {
                throw new InvalidOperationException("Error adding entity to Table Storage", ex);
            }
        }

        public async Task DeleteBirdAsync(string partitionKey, string rowKey)
        {
            await _birdTableClient.DeleteEntityAsync(partitionKey, rowKey);
        }
    }
}
