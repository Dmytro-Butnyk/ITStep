using System;
using System.Data.SqlClient;
using System.Net.Http;
using Newtonsoft.Json;

public class WeatherData
{
    public string City { get; set; }
    public float Temperature { get; set; }
    // Добавьте здесь другие метеорологические данные
}

public class WeatherApi
{
    private readonly string _apiKey;

    public WeatherApi(string apiKey)
    {
        _apiKey = apiKey;
    }

    public async Task<WeatherData> GetWeatherAsync(string city)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync($"http://api.weatherapi.com/v1/current.json?key={_apiKey}&q={city}");
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<WeatherData>(json);
            return data;
        }
    }
}

public class Database
{
    private readonly string _connectionString;

    public Database(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task InsertWeatherDataAsync(WeatherData data)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand("INSERT INTO Weather (City, Temperature) VALUES (@City, @Temperature)", connection);
            command.Parameters.AddWithValue("@City", data.City);
            command.Parameters.AddWithValue("@Temperature", data.Temperature);
            // Добавьте здесь другие метеорологические данные
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }
    }
}

public class Program
{
    public static async Task Main()
    {
        var weatherApi = new WeatherApi("434cf98950054ce9b7b174940242602");
        var database = new Database("Server=DESKTOP-BQ34J0O;Database=WeatherDB;User Id=DESKTOP-BQ34J0O;Password=DESKTOP-BQ34J0O;");

        Console.Write("Введите город: ");
        var city = Console.ReadLine();

        var weatherData = await weatherApi.GetWeatherAsync(city);
        await database.InsertWeatherDataAsync(weatherData);

        Console.WriteLine($"Погода в {city}: {weatherData.Temperature}°C");
    }
}
