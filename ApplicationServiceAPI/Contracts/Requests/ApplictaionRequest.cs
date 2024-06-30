namespace ApplicationServiceAPI.Contracts.Requests;

public record ApplictaionRequest(
    string PhoneNumber,
    string FullName,
    string Email,
    int RequestTypeId,
    int UserId);