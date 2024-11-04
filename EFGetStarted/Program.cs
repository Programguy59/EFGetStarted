using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

using var db = new BloggingContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");
seedWorkers(db);


// Create
Console.WriteLine("Inserting a new blog");

db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
db.SaveChanges();

// Read
Console.WriteLine("Querying for a blog");
var blog = db.Blogs
    .OrderBy(b => b.BlogId)
    .First();

// Update
Console.WriteLine("Updating the blog and adding a post");
blog.Url = "https://devblogs.microsoft.com/dotnet";
blog.Posts.Add(
    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
db.SaveChanges();

// Delete
Console.WriteLine("Delete the blog");
db.Remove(blog);
db.SaveChanges();

void printincompleteTaksandTodos()
{
    foreach (Task task in db.Tasks)
    {
        bool unfinhedtodos = false;
        foreach (ToDo todo in task.ToDos)
        {
            if (!todo.IsCompleted)
            {
                unfinhedtodos = true;
            }
        }
        Console.WriteLine("Task: " + task.Name);
        foreach (ToDo todo in task.ToDos)
        { if (!todo.IsCompleted) 
            {
                Console.WriteLine("Todo: " + todo.Name);
            }
        }
    }
}
static void seedTasks(BloggingContext? db)
{
    var ProduceSoftware = new Task { Name = "ProduceSoftware", ToDos = { new ToDo { Name = "Write Code" }, new ToDo { Name = "Compile source" }, new ToDo { Name = "Test Program" } } };
    var BrewCoffee = new Task { Name = "Brew Coffe" , ToDos = { new ToDo { Name = "pour Water" }, new ToDo { Name = "Pour coffee" }, new ToDo { Name = "Turn on" } } };
    db.Add(ProduceSoftware);
    db.Add(BrewCoffee);
}
static void seedWorkers(BloggingContext? db)
{
    //workers
    worker Steen = new worker { Name = "Steen Secher" };
    worker ejvind = new worker { Name = "Ejvind Møller" };
    worker Konrad = new worker { Name = "Konrad Sommer" };
    worker Sofus = new worker { Name = "Sofus Lotus" };
    worker Remo = new worker { Name = "Remo Lademann" };
    worker Ella = new worker { Name = "Ella Fanth" };
    worker Anne = new worker { Name = "Anne Dam" };

    //teams
    Team FrontEnd = new Team { Name = "Frontend" };
    Team Backend = new Team { Name = "Backend" };
    Team Testere = new Team { Name = "Testere" };

    TeamWorkers FrontEnd1 = new TeamWorkers
    { worker = Steen,Team = FrontEnd };
    TeamWorkers FrontEnd2 = new TeamWorkers
    { worker = ejvind, Team = FrontEnd };
    TeamWorkers FrontEnd3 = new TeamWorkers
    { worker = Konrad, Team = FrontEnd };

    TeamWorkers BackEnd1 = new TeamWorkers
    { worker = Konrad, Team = Backend };
    TeamWorkers BackEnd2 = new TeamWorkers
    { worker = Sofus, Team = Backend };
    TeamWorkers BackEnd3 = new TeamWorkers
    { worker = Remo, Team = Backend };

    TeamWorkers Testere1 = new TeamWorkers
    { worker = Ella, Team = Testere };
    TeamWorkers Testere2 = new TeamWorkers
    { worker = Anne, Team = Testere };
    TeamWorkers Testere3 = new TeamWorkers
    { worker = Steen, Team = Testere };


    db.Add(FrontEnd1);
    db.Add(FrontEnd1);
    db.Add(FrontEnd1);

    db.Add(BackEnd1);
    db.Add(BackEnd2);
    db.Add(BackEnd3);

    db.Add(Testere1);
    db.Add(Testere2);
    db.Add(Testere3);
    db.SaveChanges();
}
