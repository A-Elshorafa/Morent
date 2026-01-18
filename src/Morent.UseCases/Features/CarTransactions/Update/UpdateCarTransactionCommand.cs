using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.CarTransactions.Update;

public record UpdateCarTransactionCommand(UpdateCarTransactionDto reqDto) : MediatR.IRequest<Result<CarTransactionDetailsDto>>;
