using Common.ViewModels;
using FluentValidation;

namespace Common.Validators
{
    public class ParamValidator : AbstractValidator<ParamViewModel>
    {
        public ParamValidator()
        {
            RuleFor(p => p.RangeFrom).LessThan(r => r.RangeTo)
                .WithMessage("RangeFrom must be less than RangeTo");
            RuleFor(p => p.CoefficientA).NotEmpty().WithMessage("CoefficientA can not be empty");
            RuleFor(p => p.CoefficientB).NotEmpty().WithMessage("CoefficientB can not be empty");
            RuleFor(p => p.CoefficientC).NotEmpty().WithMessage("CoefficientC can not be empty");
            RuleFor(p => p.Step).NotEmpty().WithMessage("Step can not be empty");
            RuleFor(p => p.RangeFrom).NotEmpty().WithMessage("RangeFrom can not be empty");
            RuleFor(p => p.RangeTo).NotEmpty().WithMessage("RangeTo can not be empty");
        }
    }
}
