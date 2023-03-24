using ExampleClassLibrary;
using System.Diagnostics.CodeAnalysis;

var users = new List<User>()
{
    new("Sam", 35),
    new("Bob", 31),
    new("Tim", 29),
    new("Joe", 42),
    new("Leo", 35),
    new("Tom", 41),
    new("Bill", 19),
    new("Ann", 35),
    new("Poul", 24),
    new("Leo", 30),
    new("Phill", 37),
    new("Elisa", 25),
};

var usersEmpty = new List<User>();

// All, Any, Contains

bool isAll = users.All(u => u.Age > 30);
Console.WriteLine(isAll);

bool isAny = users.Any(u => u.Age < 16);
Console.WriteLine(isAny);


string name = "Max";
bool hasName = users.Contains(new User(name, 0), new UserNameComparer());
Console.WriteLine(hasName);

// First, FirstOrDefault

var uFirst = users.First();
var uFirstMore35 = users.First(u => u.Age > 35);
Console.WriteLine(uFirstMore35.Name);

var uFirstD = usersEmpty.FirstOrDefault();
Console.WriteLine(uFirstD?.Name + uFirstD?.Age.ToString());

// Last, LastOrDefault


var usersName3 = from u in users
                 where u.Name.Length > 3
                 select u;

users.Add(new User("Joseph", 42));

foreach(var user in usersName3)
    Console.WriteLine($"{user.Name}");

class UserNameComparer : IEqualityComparer<User>
{
    public bool Equals(User? x, User? y)
    {
        return x.Name.Equals(y.Name);
    }

    public int GetHashCode([DisallowNull] User obj)
    {
        return obj.Name.GetHashCode();
    }
}