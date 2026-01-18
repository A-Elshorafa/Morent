using Morent.UseCases.DTOs;
using Morent.Core.Entities;

namespace Morent.UseCases.Features.Users.Create;

public class CreateUserHandler : MediatR.IRequestHandler<CreateUserCommand, Result<UserDto>>
{
  private readonly IRepository<User> _repo;

  public CreateUserHandler(IRepository<User> repo)
  {
    _repo = repo;
  }

  public async Task<Result<UserDto>> Handle(CreateUserCommand request, CancellationToken ct)
  {
    var entity = new User
    {
      FullName = request.userDto.FullName ?? string.Empty,
      Email = request.userDto.Email ?? string.Empty,
      PhoneNumber = request.userDto.PhoneNumber ?? string.Empty,
      JobRole = request.userDto.JobRole ?? string.Empty,
      PhotoUrl = request.userDto.PhotoUrl?? string.Empty,
      DateOfBirth = request.userDto.DateOfBirth ?? DateTime.MinValue,
      NationalID = request.userDto.NationalID ?? string.Empty,
      Address = request.userDto.Address ?? string.Empty,
      DrivingLicenseNumber = request.userDto.DrivingLicenseNumber ??  string.Empty,
    };

    await _repo.AddAsync(entity, ct);

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
