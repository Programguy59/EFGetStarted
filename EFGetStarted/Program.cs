using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

using var db = new BloggingContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");
seedTasks(db);
printincompleteTaksandTodos();

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
