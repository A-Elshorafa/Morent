using Morent.Core.DTOs;
using Morent.Core.Entities;

namespace Morent.UseCases.Features.Users.GetById;

public class GetUserByIdHandler : MediatR.IRequestHandler<GetUserByIdQuery, Result<UserDto>>
{
  private readonly IRepository<User> _repo;

  public GetUserByIdHandler(IRepository<User> repo)
  {
    _repo = repo;
  }

  public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken ct)
  {
    var entity = await _repo.GetByIdAsync(request.Id, ct);
    if (entity == null) return Result.NotFound("User not found");

    return Result.Success(new UserDto(
      entity.UserId,
      entity.FullName,
      entity.Email,
      entity.PhoneNumber,
      entity.NationalID,
      entity.DateOfBirth,
      entity.Address,
      entity.DrivingLicenseNumber,
      entity.JobRole,
      entity.PhotoUrl
    ));
  }
}
