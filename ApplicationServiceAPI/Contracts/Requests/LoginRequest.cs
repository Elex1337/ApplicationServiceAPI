namespace ApplicationServiceAPI.Contracts.Requests;

public record LoginRequest(
    string Login,
    string Password);