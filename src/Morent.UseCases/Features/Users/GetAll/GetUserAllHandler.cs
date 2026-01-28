using Morent.Core.DTOs;
using Morent.Core.Entities;

namespace Morent.UseCases.Features.Users.GetAll;

public class GetUserAllHandler : MediatR.IRequestHandler<GetUserAllQuery, Result<List<UserDto>>>
{
  private readonly IRepository<User> _repo;

  public GetUserAllHandler(IRepository<User> repo)
  {
    _repo = repo;
  }

  public async Task<Result<List<UserDto>>> Handle(GetUserAllQuery request, CancellationToken ct)
  {
    var list = await _repo.ListAsync(ct);

    return Result.Success(list
      .Select(entity => new UserDto(
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
      ))
      .ToList());
  }
}
