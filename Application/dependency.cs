using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

using ToDoApplication.Application.DTOs;
using ToDoApplication.Core.Entities;

namespace ToDoApplication.Application;

public static class Dependency{

    public static void ConfigureApplication(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(
            config =>
            {
                config.CreateMap<Card,CardDTO>().ReverseMap();
                config.CreateMap<Card,CardCreationDTO>().ReverseMap();
            }
        );
        var mapper = mapperConfig.CreateMapper();
        return;
    }

}