using Morent.UseCases.DTOs;
using Morent.Core.Entities;

namespace Morent.UseCases.Features.Users.Update;

public class UpdateUserHandler : MediatR.IRequestHandler<UpdateUserCommand, Result<UserDto>>
{
  private readonly IRepository<User> _repo;

  public UpdateUserHandler(IRepository<User> repo)
  {
    _repo = repo;
  }

  public async Task<Result<UserDto>> Handle(UpdateUserCommand request, CancellationToken ct)
  {
    var entity = await _repo.GetByIdAsync(request.updateUserDto.UserId, ct);
    if (entity == null) return Result.NotFound("User not found");
    
    if(request.updateUserDto.DateOfBirth != entity.DateOfBirth) entity.DateOfBirth = (DateTime)request.updateUserDto.DateOfBirth!;
    if(request.updateUserDto.FullName != entity.FullName && !string.IsNullOrEmpty(entity.FullName)) 
      entity.FullName = request.updateUserDto.FullName!;
    if(request.updateUserDto.Email != entity.Email && !string.IsNullOrEmpty(entity.Email))
      entity.Email = request.updateUserDto.Email!;
    if(request.updateUserDto.PhoneNumber != entity.PhoneNumber && !string.IsNullOrEmpty(entity.PhoneNumber))
      entity.PhoneNumber = request.updateUserDto.PhoneNumber!;
    if(request.updateUserDto.NationalID != entity.NationalID && !string.IsNullOrEmpty(entity.NationalID))
      entity.NationalID = request.updateUserDto.NationalID!;
    if(request.updateUserDto.Address != entity.Address && !string.IsNullOrEmpty(entity.Address))
      entity.Address = request.updateUserDto.Address!;
    if(request.updateUserDto.DrivingLicenseNumber != entity.DrivingLicenseNumber && !string.IsNullOrEmpty(entity.DrivingLicenseNumber))
      entity.DrivingLicenseNumber = request.updateUserDto.DrivingLicenseNumber!;
    if(request.updateUserDto.JobRole != entity.JobRole && !string.IsNullOrEmpty(entity.JobRole))
      entity.JobRole = request.updateUserDto.JobRole!;
    if(request.updateUserDto.PhotoUrl != entity.PhotoUrl && !string.IsNullOrEmpty(entity.PhotoUrl))
      entity.PhotoUrl = request.updateUserDto.PhotoUrl!;

    await _repo.UpdateAsync(entity, ct);

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
