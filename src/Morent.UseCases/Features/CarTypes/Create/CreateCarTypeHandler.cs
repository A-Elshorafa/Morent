using Morent.Core.Entities;
using Morent.Core.DTOs;

namespace Morent.UseCases.Features.CarTypes.Create;

public sealed class CreateCarTypeHandler : MediatR.IRequestHandler<CreateCarTypeCommand, Result<CarTypeDto>>
{
  private readonly IRepository<CarType> _repo;

  public CreateCarTypeHandler(IRepository<CarType> repo)
  {
    _repo = repo;
  }

  public async Task<Result<CarTypeDto>> Handle(CreateCarTypeCommand request, CancellationToken ct)
  {
    var entity = new CarType { TypeName = request.TypeName };
    await _repo.AddAsync(entity, ct);

    return Result.Success( 
      new CarTypeDto { CarTypeId = entity.CarTypeId, TypeName = entity.TypeName }
    );
  }
}
