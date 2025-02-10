using System.Diagnostics;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class ProjectService(ICustomerService customerService, IProjectRepository projectRepository)
{
    // If A service exists, rather then a repository, then that should be used instead.
    // private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly ICustomerService _customerService = customerService;
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task CreateProjectAsync(ProjectRegistrationForm form)
    {
        var customer = await _customerService.GetCustomerAsync(form.Customer.CustomerName);
        if (customer == null)
        {
            var result = await _customerService.CreateCustomerAsync(form.Customer);
            if (result)
                customer = await _customerService.GetCustomerAsync(form.Customer.CustomerName);
        }

        if (customer != null)
        {
            await _projectRepository.BeginTransactionAsync();
        
            try
            {
                var projectEntity = ProjectFactory.Create(form);
                projectEntity.CustomerId = customer.Id;
            
                await _projectRepository.AddAsync(projectEntity);
                await _projectRepository.SaveAsync();
            
                await _projectRepository.CommitTransactionAsync();
            }
            catch
            {
                await _projectRepository.RollbackTransactionAsync();
            }
        }
    }
}