using Morent.Core.DTOs;

namespace Morent.UseCases.Features.UserPreferences.GetAll;

public record GetUserPreferenceAllQuery() : MediatR.IRequest<Result<List<UserPreferenceDto>>>;
