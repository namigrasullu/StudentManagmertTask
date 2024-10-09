using AutoMapper;
using StudentManagement.Application.Dtos;
using StudentManagement.Domain.Concretes;

namespace StudentManagement.Application.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Lesson, AddLessonDto>(); 
        CreateMap<AddLessonDto, Lesson>();
        CreateMap<UpdateLessonDto, Lesson>();
        CreateMap<Lesson, UpdateLessonDto>();

        CreateMap<AddExamDto, Exam>();
        CreateMap<Exam, AddExamDto>();
        CreateMap<UpdateExamDto, Exam>();
        CreateMap<Exam, UpdateExamDto>();

        CreateMap<AddStudentDto, Student>();
        CreateMap<Student, AddStudentDto>();
        CreateMap<UpdateStudentDto, Student>();
        CreateMap<Student, UpdateStudentDto>();
    }
}
