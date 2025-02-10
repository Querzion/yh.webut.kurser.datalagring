using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class ProjectFactory
{
    public static ProjectRegistrationForm Create() => new();

    public static ProjectEntity Create(ProjectRegistrationForm registrationForm) => new()
    {
        Description = registrationForm.Description,
        Notes = registrationForm.Notes,
        Status = registrationForm.Status,
        ProjectManager = registrationForm.ProjectManager,
        StartDate = registrationForm.StartDate,
        EndDate = registrationForm.EndDate
    };

    public static Project Create(ProjectEntity entity) => new()
    {
        Description = entity.Description,
        Notes = entity.Notes,
        Status = entity.Status,
        ProjectManager = entity.ProjectManager,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate
    };

    public static ProjectUpdateForm Create(Project project) => new()
    {
        Description = project.Description,
        Notes = project.Notes,
        Status = project.Status,
        ProjectManager = project.ProjectManager
    };

    public static ProjectEntity Create(ProjectEntity projectEntity, ProjectUpdateForm updateForm) => new()
    {
        Id = projectEntity.Id,
        Description = updateForm.Description,
        Notes = updateForm.Notes,
        Status = updateForm.Status,
        ProjectManager = updateForm.ProjectManager,
        CustomerId = projectEntity.CustomerId
    };
}