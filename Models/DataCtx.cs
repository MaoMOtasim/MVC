using System;
using System.Data.Entity;
using System.Linq;

namespace MVC.Models
{
    public class DataCtx : DbContext
    {
        // Your context has been configured to use a 'DataCtx' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MVC.Models.DataCtx' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DataCtx' 
        // connection string in the application configuration file.
        public DataCtx()
            : base("name=DataCtx")
        {
        }

        
        public DbSet<User> Users { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}