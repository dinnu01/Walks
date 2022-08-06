using FluentValidation;
using Walks.API.Models.DTOs;

namespace Walks.API.Validators
{
    public class AddRegionRequestValidator:AbstractValidator<AddRegionRequest>
    {
        public AddRegionRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Area).GreaterThan(0);
        }
    }
}
