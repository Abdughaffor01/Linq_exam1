using _001Task.Data;

await using var dataContext = new DataContext();


Console.WriteLine(" Good look 😊😊😊 ");

//1
//Напишите запрос LINQ, чтобы получить всех людей, живущих в городе с населением более 3 человек.
//Write a LINQ query to retrieve all the people who live in a city with a population greater than 3 
Console.WriteLine();
Console.WriteLine("Example 1");
Console.WriteLine();
var peopleByCity = from c in dataContext.Cities
                   where c.Population > 3000000
                   select new {
                       Name = c.Name,
                       People = (from p in dataContext.Peoples
                                where p.CityId == c.Id
                                select p).ToList()
                   };

foreach (var p in peopleByCity)
{
    Console.WriteLine(p.Name);
    foreach (var i in p.People) Console.WriteLine($"\tFullName = {i.FirstName} {i.LastName}");
}


//2
//Получите все города со средней численностью населения в соответствующей стране
//Retrieve all cities with their respective country's average population
Console.WriteLine();
Console.WriteLine("_____________Example 2");
Console.WriteLine();
var averaggePeopleByCity = from c in dataContext.Cities
                           join p in dataContext.Peoples on c.Id equals p.CityId
                           group c by new { p.CityId, c.Name } into g
                           select new
                           {
                               name = g.Key.Name,
                               average = g.Average(x => x.Population)
                           };

foreach (var p in averaggePeopleByCity) Console.WriteLine($"{p.name} averagge people in city = {p.average}");

//3
//Получите города с самым высоким населением в каждой стране
//Retrieve the cities with the highest population in each country
Console.WriteLine();
Console.WriteLine("_____________Example 3");
Console.WriteLine();

var CityByContry = from p in dataContext.Countries
                   select new
                   {
                       nameContry = p.Name,
                       maxPopulation = (from i in dataContext.Cities
                                        group i by i.CountryId into g
                                        select g.Max(x=>x.Population)).FirstOrDefault()
                   };

foreach (var p in CityByContry) Console.WriteLine($"{p.nameContry} averagge people in city = {p.maxPopulation}");


//4
//Получите среднее население городов в каждой стране
//Retrieve the average population of cities in each country
Console.WriteLine();
Console.WriteLine("_____________Example 4");
Console.WriteLine();
var averagePeopleByContry = from p in dataContext.Countries
                           join c in dataContext.Cities on p.Id equals c.CountryId
                           group c by new { c.CountryId, p.Name } into g
                           select new
                           {
                               name = g.Key.Name,
                               average = g.Average(x=>x.Population)
                           };

foreach (var p in averagePeopleByContry) Console.WriteLine($"{p.name} averagge people in countru = {p.average}");


//5
//Получить все города, в которых есть человек по имени "Марк".
//Retrieve all cities that have a person with by name "Mark"
Console.WriteLine();
Console.WriteLine("_____________Example 5");
Console.WriteLine();
var citiByNamePeople = from c in dataContext.Cities
                            join p in dataContext.Peoples on c.Id equals p.CityId
                            where p.FirstName=="Mark"
                            select c;

foreach (var p in citiByNamePeople) Console.WriteLine($"{p.Name}");



//6
//Получить всех людей вместе с соответствующими названиями городов и стран
//Retrieve all people along with their associated city and country names

Console.WriteLine();
Console.WriteLine("_____________Example 6");
Console.WriteLine();

var countryWithPeople = from c in dataContext.Countries
                        select new
                        {
                            name= c.Name,
                            Cities = c.Cities,
                            People = c.Cities.SelectMany(x => x.Peoples).ToList()
                        };

foreach (var p in countryWithPeople) { 

    Console.WriteLine($"Country = {p.name}");
    foreach (var ct in p.Cities)
    {
        Console.WriteLine($"\tCities = {ct.Name}");
        foreach (var m in p.People) Console.WriteLine($"\t\tPeople = {m.LastName}");
    }
}

//7
//Получите все города вместе с соответствующими названиями стран, используя свойство навигации
//Retrieve all cities along with their associated country names using a navigation property

Console.WriteLine();
Console.WriteLine("_____________Example 7");
Console.WriteLine();




//8
//Получить всех людей вместе с связанными с ними городом и страной.
//Retrieve all people along with their associated city and country 





//9
//Получить всех людей, живущих в "USA".
//Retrieve all people living in  "USA".


Console.WriteLine();
Console.WriteLine("_____________Example 9");
Console.WriteLine();

var allPeopleByUSA = from c in dataContext.Countries
                     where c.Name == "USA"
                     select new
                     {
                         Name=c.Name,
                         People=c.Cities.Where(ct=>ct.CountryId==c.Id).SelectMany(p=>p.Peoples).ToList(),
                     };

foreach (var c in allPeopleByUSA)
{
    Console.WriteLine($" name country = {c.Name}");
    foreach (var p in c.People) Console.WriteLine($"\t fullname = {p.FirstName} {p.LastName}");
}


//10
//Получить всех людей вместе с соответствующим населением города и страны
//Retrieve all people along with their associated city and country populations 


Console.WriteLine();
Console.WriteLine("_____________Example 10");
Console.WriteLine();

var allPeopleWithPopuletionCities = from p in dataContext.Peoples
                                    select new
                                    {
                                        Fullname=$"{p.FirstName} {p.LastName}",
                                        Population=(from c in dataContext.Cities
                                                          where c.Id==p.CityId
                                                          select c.Population).FirstOrDefault()
                                    };

foreach (var c in allPeopleWithPopuletionCities)
{
    Console.WriteLine($" name  people = {c.Fullname} population citie = {c.Population}");
}

