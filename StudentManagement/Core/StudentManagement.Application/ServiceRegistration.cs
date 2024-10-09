using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Application.Mappers;
using FluentValidation.AspNetCore;

namespace StudentManagement.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MapperProfile));
        services.AddFluentValidation(config =>
        {
            config.RegisterValidatorsFromAssemblyContaining<AddStudentValidator>(); 
        });
    }
}
