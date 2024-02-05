using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SampleCRUD.Identity.Models;
using System.Security.Claims;

namespace SampleCRUD.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _contextAccessor;

    public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
    {
        _userManager = userManager;
        _contextAccessor = contextAccessor;
    }

    public string UserId { get => _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); }

    public async Task<Employee> GetEmployee(string userId)
    {
        var employee = await _userManager.FindByIdAsync(userId);
        return new Employee
        {
            Email = employee.Email,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Id = employee.Id
        };
    }

    public async Task<List<Employee>> GetEmployees()
    {
        var employees = await _userManager.GetUsersInRoleAsync("Employee");
        return employees.Select(c => new Employee
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName,
            Email = c.Email
        }).ToList();
    }
}
