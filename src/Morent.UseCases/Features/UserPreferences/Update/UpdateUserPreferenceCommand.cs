using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.UserPreferences.Update;

public record UpdateUserPreferenceCommand(UpdateUserPreferenceDto userPreferenceDto) : MediatR.IRequest<Result<UserPreferenceDto>>;
