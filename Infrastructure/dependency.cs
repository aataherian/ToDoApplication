using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


namespace ToDoApplication.Infrastructure;

public static class Dependency{

    public static void ConfigurePersistence(this IServiceCollection services, IConfiguration config)
    {

    }
    
    
    
    public static void ConfigurePersistence(this IServiceCollection services, string connectionString)
    {

    }
    

}