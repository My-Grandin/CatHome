using Newtonsoft.Json;

namespace CatHome.Infrastructure.Context
{
    public class JsonContext
    {
        public async Task<List<T>> DeserializeJsonFile<T>(string filePath)
        {
            using StreamReader reader = File.OpenText(filePath);
            string jsonString = await reader.ReadToEndAsync();

            if (jsonString.StartsWith("["))
            {
                var data = JsonConvert.DeserializeObject<List<T>>(jsonString);
                return data ?? new List<T>(); // Returnera data om det inte är null, annars en ny tom lista
            }
            else
            {
                var singleData = JsonConvert.DeserializeObject<T>(jsonString);
                var listOfData = singleData != null ? new List<T> { singleData } : new List<T>(); // Skapa en lista med singleData om det inte är null, annars en tom lista
                return listOfData;
            }
        }


        public async Task AddDataToJsonFile<T>(string filePath, T data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            await File.WriteAllTextAsync(filePath, json);
        }
        public int GetNextId<T>(List<T> listOfData)
        {
            return listOfData.Count + 1;
        }
    }
}
