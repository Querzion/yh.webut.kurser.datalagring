using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models;

public class ProjectRegistrationForm
{

    public string Description { get; set; } = null!;
    public string? Notes { get; set; }
    public string Status { get; set; } = null!;
    public string ProjectManager { get; set; } = null!;
    
    public DateTime StartDate { get; set; } 
    
    public DateTime? EndDate { get; set; }
   
    public CustomerRegistrationForm Customer { get; set; } = new();
}