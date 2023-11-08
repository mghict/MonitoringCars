using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class FluentValidationExt
    {
        public
            static async Task<FluentResults.Result<TResult>> Validate<TValidate, TCommand,TResult>(TValidate validator, TCommand command)
            where TValidate : FluentValidation.AbstractValidator<TCommand>
        {
            FluentResults.Result<TResult> result = new FluentResults.Result<TResult>();

            FluentValidation.Results.ValidationResult
                validationResult = await validator.ValidateAsync(instance: command);

            if (validationResult.IsValid == false)
            {
                foreach (var error in validationResult.Errors)
                {
                    result.WithError(errorMessage: error.ErrorMessage);
                }
            }

            return result;
        }


        public
            static async Task<FluentResults.Result> Validate<TValidate,TCommand>
            (TValidate validator, TCommand command)
            where TValidate : FluentValidation.AbstractValidator<TCommand>
        {
            FluentResults.Result result = new FluentResults.Result();

            FluentValidation.Results.ValidationResult
                validationResult = await validator.ValidateAsync(instance: command);

            if (validationResult.IsValid == false)
            {
                foreach (var error in validationResult.Errors)
                {
                    result.WithError(errorMessage: error.ErrorMessage);
                }
            }

            return result;
        }


        //       public
        //           static
        //           async Task <FluentResults.Result<TValue>> Validate<TCommand, TValue>
        //(FluentValidation.AbstractValidator<TCommand> validator, TCommand command)
        //       {
        //           FluentResults.Result<TValue> result = new FluentResults.Result<TValue>();

        //           FluentValidation.Results.ValidationResult
        //               validationResult = await validator.ValidateAsync(instance: command);

        //           if (validationResult.IsValid == false)
        //           {
        //               foreach (var error in validationResult.Errors)
        //               {
        //                   result.WithError(errorMessage: error.ErrorMessage);
        //               }
        //           }

        //           return result;
        //       }


        //public
        //    static
        //    async
        //    System.Threading.Tasks.Task
        //    <FluentResults.Result>
        //    Validate<TCommand>
        //    (FluentValidation.AbstractValidator<TCommand> validator, TCommand command)
        //{
        //    FluentResults.Result result = new FluentResults.Result();

        //    FluentValidation.Results.ValidationResult
        //        validationResult = await validator.ValidateAsync(instance: command);

        //    if (validationResult.IsValid == false)
        //    {
        //        foreach (var error in validationResult.Errors)
        //        {
        //            result.WithError(errorMessage: error.ErrorMessage);
        //        }
        //    }

        //    return result;
        //}
    }
}
