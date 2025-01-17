using Dapper;
using lesson_8.Models;
using System.Data.SqlClient;
using System.Transactions;
using Z.Dapper.Plus;
using static System.Console;

string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
Initial Catalog=CityCountryContinent;
Integrated Security=True;";

DapperPlusManager.Entity<Continent>().Table("Continents");
DapperPlusManager.Entity<Country>().Table("Countries");
DapperPlusManager.Entity<City>().Table("Cities");

using (SqlConnection connection = new(connectionString))
{
    try
    {
        #region Task 1
        //var cities = connection.Query<City>("select * from Cities").ToList();
        //var countries = connection.Query<Country>("select * from Countries").ToList();
        //var continents = connection.Query<Continent>("select * from Continents").ToList();

        //continents.ForEach(WriteLine);
        //WriteLine();
        //countries.ForEach(WriteLine);
        //WriteLine();
        //cities.ForEach(WriteLine);
        #endregion

        #region Task 2
        //List<Continent> continents = connection.Query<Continent>("select * from Continents").ToList();
        //List<Continent> selectedContinents = new();
        //WriteLine("Type 1 continents name:");
        //for(int i = 0; i < 1; i++)
        //{
        //    Write($"Continent {i + 1}: ");
        //    var name = ReadLine();
        //    if(!continents.Any(x => x.Name == name))
        //    {
        //        WriteLine("Not exist!");
        //        i--;
        //        continue;
        //    }

        //    selectedContinents.Add(continents.FirstOrDefault(x=>x.Name == name));
        //}
        //List<Country> newCountries = new();

        //WriteLine("Enter 2 countries for each continent:");
        //foreach (var it in selectedContinents) {
        //    WriteLine($"Countries for {it.Name}");
        //    for (int i = 0; i < 2; i++)
        //    {
        //        Write($"Country name {i+1}: ");
        //        newCountries.Add(new Country(ReadLine(), it.Id));
        //    }
        //}
        //connection.BulkInsert(newCountries);


        //List<City> newCities = new();
        //WriteLine("Enter cities name for countries:");
        //foreach(var it in newCountries)
        //{
        //    Write($"City name for {it.Name}: ");
        //    newCities.Add(new City(ReadLine(), connection.QueryFirst($"Select Id from Countries " +
        //        $"Where {it.Name} = Name")));
        //}

        //connection.BulkInsert(newCities);
        #endregion

        #region Task 3
        var citiesToUpdate = connection.Query<City>("select * from Cities").ToList();
        citiesToUpdate.ForEach(x => x.Name += " NEW");
        connection.BulkUpdate(citiesToUpdate);

        var countriesToUpdate = connection.Query<Country>("select * from Countries").ToList();
        countriesToUpdate.ForEach(x => x.Name += " NEW");
        connection.BulkUpdate(countriesToUpdate);

        var continentsToUpdate = connection.Query<Continent>("select * from Continents").ToList();
        continentsToUpdate.ForEach(x => x.Name += " NEW");
        connection.BulkUpdate(continentsToUpdate);
        #endregion

        #region Task 4
        Write("Continent name: ");
        var continentName = ReadLine();
        var continent = connection.Query<Continent>("select * from Continents").FirstOrDefault(x => x.Name == continentName);
        CascadeContinent(continent);

        Write("Country name: ");
        var countryName = ReadLine();
        var country = connection.Query<Country>("select * from Countries").FirstOrDefault(x => x.Name == countryName);
        CascadeCountry(country);

        Write("City name:");
        var cityName = ReadLine();
        var city = connection.Query<City>("select * from Cities").FirstOrDefault(x => x.Name == cityName);
        connection.BulkDelete(city);
        #endregion 
    }
    catch (Exception ex)
    {
        WriteLine(ex.Message);
    }
}

void CascadeContinent(Continent continent)
{
    using (SqlConnection connection = new(connectionString))
    {
        try
        {
            var countries = connection.Query<Country>("select * from Countries").Where(x => x.ContinentId == continent.Id).ToList();
            if (countries != null)
            {
                countries.ForEach(CascadeCountry);
            }
            connection.BulkDelete(continent);
        }
        catch (Exception ex)
        {
            WriteLine(ex.Message);
        }
    }
}
void CascadeCountry(Country country)
{
    using (SqlConnection connection = new(connectionString))
    {
        try
        {
            var cities = connection.Query<City>("select * from Cities").Where(x => x.CountryId == country.Id).ToList();
            if (cities != null)
            {
                cities.ForEach(x => connection.BulkDelete(x));
            }
            connection.BulkDelete(country);
        }
        catch (Exception ex)
        {
            WriteLine(ex.Message);
        }
    }
}
