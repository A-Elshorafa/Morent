using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.UserPreferences.GetById;

public record GetUserPreferenceByIdQuery(int Id) : MediatR.IRequest<Result<UserPreferenceDto>>;
