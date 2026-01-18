using Morent.UseCases.DTOs;
using Morent.Core.Entities;

namespace Morent.UseCases.Features.Users.Delete;

public class DeleteUserHandler : MediatR.IRequestHandler<DeleteUserCommand, Result<bool>>
{
  private readonly IRepository<User> _repo;

  public DeleteUserHandler(IRepository<User> repo)
  {
    _repo = repo;
  }

  public async Task<Result<bool>> Handle(DeleteUserCommand request, CancellationToken ct)
  {
    var entity = await _repo.GetByIdAsync(request.Id, ct);
    if (entity == null) return Result.NotFound("User not found");

    await _repo.DeleteAsync(entity, ct);

    return Result.Success(true);
  }
}
