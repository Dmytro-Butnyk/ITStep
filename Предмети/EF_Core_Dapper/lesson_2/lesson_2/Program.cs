using static System.Console;
using Microsoft.EntityFrameworkCore;
using lesson_2;
using System.Threading.Tasks.Sources;

try
{

    CountriesContext db = new CountriesContext();
    CountriesInfo(db);
    CapitalNames(db);
    EuropeanCountries(db);
    CoNameContainsAU(db);
    CountriesInRange(db);
    CountriesWithLargePopulation(db);
}
catch(Exception ex)
{
    WriteLine(ex.Message);
}

void CountriesInfo(CountriesContext db)
{
    var countries = db.Countries.Include(c => c.Cities).ToList();
    foreach (var country in countries)
    {
        WriteLine($"Country: {country.CountryName}, Area: {country.Area}, World Part: {country.WorldPart}");
        foreach (var city in country.Cities)
        {
            WriteLine($"City: {city.CityName}, Population: {city.Population}, Is Capital: {city.IsCapital}");
        }
        WriteLine();
    }
}
void CapitalNames(CountriesContext db)
{
    var capitals = db.Cities
        .Where(c => (bool)c.IsCapital)
        .Select(c => c.CityName)
        .ToList();
    foreach (var capital in capitals)
    {
        WriteLine(capital);
    }
}
void EuropeanCountries(CountriesContext db)
{
    var europeanCountries = db.Countries
        .Where(c => c.WorldPart == "Europe")
        .Select(c => c.CountryName)
        .ToList();
    foreach (var country in europeanCountries)
    {
        WriteLine(country);
    }
}
void CoNameContainsAU(CountriesContext db)
{
    var countriesWithAandU = db.Countries
        .Where(c => c.CountryName
        .Contains("a") && c.CountryName
        .Contains("u"))
        .Select(c => c.CountryName)
        .ToList();
    foreach (var country in countriesWithAandU)
    {
        WriteLine(country);
    }
}
void CountriesInRange(CountriesContext db)
{
    var countriesInRange = db.Countries.Where(c => c.Area >= 10000 && c.Area <= 500000).Select(c => c.CountryName).ToList();
    foreach (var country in countriesInRange)
    {
        WriteLine(country);
    }

}
void CountriesWithLargePopulation(CountriesContext db)
{
    var countriesWithLargePopulation = db.Countries.Where(c => c.Cities.Sum(city => city.Population) > 1000000).Select(c => c.CountryName).ToList();
    foreach (var country in countriesWithLargePopulation)
    {
        WriteLine(country);
    }
}