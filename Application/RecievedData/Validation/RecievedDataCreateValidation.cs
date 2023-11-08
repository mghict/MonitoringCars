using Common.Extensions;
using FluentValidation;
using Moneyon.Common.IOC;

namespace Application.RecievedData.Validation
{
    [AutoRegister]
    public class RecievedDataCreateValidation: FluentValidation.AbstractValidator<Commands.RecievedDataCreateCommand>
    {
        public RecievedDataCreateValidation()
        {
            RuleFor(model => model.DeviceId)
                .NotNull()
                .WithName(model => Common.Resources.EntityProperties.GetPropertyName(nameof(model.DeviceId)))
                //.WithName(model => model.DisplayName(nameof( model.DeviceId)))
                .WithMessage(Common.Resources.FluentMessages.Fluent_DataNotNull)
                .NotEmpty()
                .WithMessage(Common.Resources.FluentMessages.Fluent_DataNotEmpty);

            RuleFor(model => model.OperationCode)
                .NotNull()
                .WithName(model => Common.Resources.EntityProperties.GetPropertyName(nameof(model.OperationCode)))
                .WithMessage(Common.Resources.FluentMessages.Fluent_DataNotNull)
                .NotEmpty()
                .WithMessage(Common.Resources.FluentMessages.Fluent_DataNotEmpty);

            RuleFor(model => model.ExecutiveOperationCode)
                .NotNull()
                .WithName(model => Common.Resources.EntityProperties.GetPropertyName(nameof(model.ExecutiveOperationCode)))
                .WithMessage(Common.Resources.FluentMessages.Fluent_DataNotNull)
                .NotEmpty()
                .WithMessage(Common.Resources.FluentMessages.Fluent_DataNotEmpty);
        }
    }
}
