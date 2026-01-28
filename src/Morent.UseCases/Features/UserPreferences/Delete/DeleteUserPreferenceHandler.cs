using Morent.Core.DTOs;
using Morent.Core.Entities;

namespace Morent.UseCases.Features.UserPreferences.Delete;

public class DeleteUserPreferenceHandler : MediatR.IRequestHandler<DeleteUserPreferenceCommand, Result<bool>>
{
  private readonly IRepository<UserPreference> _repo;

  public DeleteUserPreferenceHandler(IRepository<UserPreference> repo)
  {
    _repo = repo;
  }

  public async Task<Result<bool>> Handle(DeleteUserPreferenceCommand request, CancellationToken ct)
  {
    var entity = await _repo.GetByIdAsync(request.Id, ct);
    if (entity == null) return Result.NotFound("UserPreference not found");

    await _repo.DeleteAsync(entity, ct);

    return Result.Success(true);
  }
}
