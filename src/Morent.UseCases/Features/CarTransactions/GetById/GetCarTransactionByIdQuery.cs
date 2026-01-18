using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.CarTransactions.GetById;

public record GetCarTransactionByIdQuery(int Id) : MediatR.IRequest<Result<CarTransactionDetailsDto>>;
