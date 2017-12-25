using Common.Validators;

namespace Common.ViewModels
{
    [FluentValidation.Attributes.Validator(typeof(ParamValidator))]
    public class ParamViewModel
    {
        public double CoefficientA { get; set; }
        public double CoefficientB { get; set; }
        public double CoefficientC { get; set; }
        public double Step { get; set; }
        public double RangeFrom { get; set; }
        public double RangeTo { get; set; }
    }
}
