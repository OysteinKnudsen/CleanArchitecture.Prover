using System.Text.Json;

namespace CleanArchitecture.External.SkoleAPI.Data.Services;

public abstract class DataService
{
    private string BaseDirectory { get; } = AppDomain.CurrentDomain.BaseDirectory;

    protected async Task<T> LoadJsonDataAsync<T>(string filePath)
    {
        string fullPath = Path.Combine(BaseDirectory, filePath);

        if (!File.Exists(fullPath))
        {
            throw new FileNotFoundException("Filen ble ikke funnet.", fullPath);
        }

        await using var stream = File.OpenRead(fullPath);
        return await JsonSerializer.DeserializeAsync<T>(stream);
    }
    
}