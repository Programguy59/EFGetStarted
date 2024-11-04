using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using static worker;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<ToDo> ToDos { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<worker> workers { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<TeamWorkers> TeamWorkers { get; set; }

    public string DbPath { get; }

    public BloggingContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TeamWorkers>()
            .HasKey(p => new { p.TeamId, p.WorkerID });
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class ToDo
{   
    public int ToDoID { get; set; }
    public string Name { get; set; }
    public bool IsCompleted { get; set; }
}

public class Task
{
    public int TaskId { get; set; }
    public string Name { get; set; }

    public List<ToDo> ToDos { get; } = new();
}

public class worker
{
    public int WorkerID { get; set; }
    public string Name { get; set; }
    public List<TeamWorkers> Teams { get; } = new();
}

public class Team
{
    public int TeamID { get; set; }
    public string Name { get; set; }
    public List<TeamWorkers> Workers { get; } = new ();
}

public class TeamWorkers
{
    public int WorkerID { get; set; }
    public worker worker { get; set; }
    public int TeamId { get; set; }
    public Team Team { get; set; }

}

public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }

    public List<Post> Posts { get; } = new();
}

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}
