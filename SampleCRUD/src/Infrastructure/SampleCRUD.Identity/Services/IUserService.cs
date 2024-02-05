using SampleCRUD.Identity.Models;

namespace SampleCRUD.Identity.Services;

public interface IUserService
{
    Task<List<Employee>> GetEmployees();
    Task<Employee> GetEmployee(string userId);
    public string UserId { get; }
}
