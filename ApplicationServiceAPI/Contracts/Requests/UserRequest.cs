namespace ApplicationServiceAPI.Contracts.Requests;

public record UserRequest(
    string Login,
    string FullName,
    string Email,
    string PasswordHash);