using Newtonsoft.Json;

namespace WebApplication1.Servicios.Comunes
{
    public static class ArchivoJSON
    {
        public static async Task<List<T>> ReadFromFileAsync<T>(string JSON)
        {
            if (!File.Exists(JSON))
            {
                return new List<T>();
            }

            var json = await File.ReadAllTextAsync(JSON);
            var dtos = JsonConvert.DeserializeObject<List<T>>(json);
            return dtos;
        }

        public static async Task WriteToFileAsync<T>(List<T> categories, string JSON)
        {
            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            if (File.Exists(JSON))
            {
                await File.WriteAllTextAsync(JSON, json);
            }
        }
    }
}
