using RazorErrorHandling.Models;

namespace RazorErrorHandling.Services;

public interface IUserService
{
    Task<Result<bool>> RegisterUserAsync(UserRegistration registration);
}

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;

    public UserService(ILogger<UserService> logger)
    {
        _logger = logger;
    }

    public async Task<Result<bool>> RegisterUserAsync(UserRegistration registration)
    {
        try
        {
            // Simulate validation
            if (string.IsNullOrEmpty(registration.Email))
                return Result<bool>.Fail("Email is required", ErrorType.Validation);

            if (registration.Password?.Length < 8)
                return Result<bool>.Fail(
                    "Password must be at least 8 characters",
                    ErrorType.Validation
                );

            // Simulate database operation
            if (registration.Email == "existing@example.com")
                return Result<bool>.Fail("User already exists", ErrorType.Conflict);

            // Simulate successful registration
            return Result<bool>.Ok(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during user registration");
            return Result<bool>.Fail("An unexpected error occurred", ErrorType.System);
        }
    }
}
