using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.CarTransactions.GetAll;

public record GetCarTransactionAllQuery() : MediatR.IRequest<Result<List<CarTransactionDetailsDto>>>;
