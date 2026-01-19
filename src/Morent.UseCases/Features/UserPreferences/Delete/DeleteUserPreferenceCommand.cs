namespace Morent.UseCases.Features.UserPreferences.Delete;

public record DeleteUserPreferenceCommand(int Id) : MediatR.IRequest<Result<bool>>;
