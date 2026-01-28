using Morent.Core.DTOs;

namespace Morent.UseCases.Features.CarTransactions.Create;

public record CreateCarTransactionCommand(CreateCarTransactionDto reqDto) : MediatR.IRequest<Result<CarTransactionDetailsDto>>;
