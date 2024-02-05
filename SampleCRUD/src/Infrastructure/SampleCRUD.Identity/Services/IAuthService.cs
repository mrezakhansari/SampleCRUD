using SampleCRUD.Identity.Models;

namespace SampleCRUD.Identity.Services;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
}
