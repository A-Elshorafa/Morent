using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.UserPreferences.Create;

public record CreateUserPreferenceCommand(CreateUserPreferenceDto userPreferenceDto) : MediatR.IRequest<Result<UserPreferenceDto>>;
