namespace _001Task.Data;
public class DataProvider
{
    public static List<Country> Countries { get;} = new()
    {
        new Country {Id = 1, Name = "USA" },
        new Country {Id = 2, Name = "Canada" },
        new Country {Id = 3, Name = "Tajikistan" }
    };
    public static List<City> Cities { get;} = new()
    {
        new City {Id = 1, Name = "New York", Population = 8623000, CountryId = 1},
        new City {Id = 2, Name = "Toronto", Population = 2930000, CountryId = 2},
        new City {Id = 3, Name = "Dushanbe", Population = 120000, CountryId = 3},
        new City {Id = 4, Name = "Khujand", Population = 200000, CountryId = 3}
    };
    public static List<People> Peoples { get;} = new()
    {
        new People {Id = 1, FirstName = "John", LastName = "Mark", Age = 30, CityId = 1 },
        new People {Id = 2, FirstName = "Jane", LastName = "Doe", Age = 25, CityId = 2 },
        new People {Id = 3, FirstName = "Alice", LastName = "Jane", Age = 35, CityId = 2 },
        new People {Id = 4, FirstName = "Mark", LastName = "Doe", Age = 19, CityId = 1 },
        new People {Id = 5, FirstName = "Malik", LastName = "Malik", Age = 29, CityId = 1 },
        new People {Id = 6, FirstName = "Marks", LastName = "Does", Age = 17, CityId = 1 },
        new People {Id = 7, FirstName = "GHaffor", LastName = "Rahimov", Age = 22, CityId = 3 },
        new People {Id = 8, FirstName = "Ravshan", LastName = "Kholmatov", Age = 29, CityId = 3 }
    };
}