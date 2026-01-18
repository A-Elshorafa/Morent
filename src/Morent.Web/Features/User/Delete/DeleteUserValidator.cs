using FluentValidation;

namespace Morent.Web.Features.User.Delete;

public class DeleteUserValidator : Validator<DeleteUserRequest>
{
  public DeleteUserValidator()
  {
    RuleFor(x => x.Id).GreaterThan(0);
  }
}
