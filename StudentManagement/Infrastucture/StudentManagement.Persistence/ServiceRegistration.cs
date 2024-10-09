using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Application.Repositories;
using StudentManagement.Application.Services;
using StudentManagement.Domain.Concretes;
using StudentManagement.Persistence.Context;
using StudentManagement.Persistence.Repositories;
using StudentManagement.Persistence.Services;

namespace StudentManagement.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<StudentManagementDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IRepository<Student>, Repository<Student>>();
        services.AddScoped<IRepository<Lesson>, Repository<Lesson>>();
        services.AddScoped<IRepository<Exam>, Repository<Exam>>();

        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<ILessonService, LessonService>();
        services.AddScoped<IExamService, ExamService>();
    }
}
