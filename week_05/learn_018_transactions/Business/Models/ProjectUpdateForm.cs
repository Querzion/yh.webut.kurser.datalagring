namespace Business.Models;

public class ProjectUpdateForm
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public string? Notes { get; set; }
    public string Status { get; set; } = null!;
    public string ProjectManager { get; set; } = null!;
}