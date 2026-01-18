namespace Morent.UseCases.Features.CarTransactions.Delete;

public record DeleteCarTransactionCommand(int Id) : MediatR.IRequest<Result<bool>>;
