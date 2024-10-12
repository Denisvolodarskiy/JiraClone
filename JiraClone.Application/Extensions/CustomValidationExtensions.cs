using FluentValidation;
using JiraClone.Application.Constants;
using System;

namespace JiraClone.Application.Extensions;

public static class CustomValidationExtensions
{
    public static IRuleBuilderOptions<T, TProperty> CannotBeNull<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, string fieldName)
    {
        return ruleBuilder
            .NotNull()
            .WithMessage($"{fieldName} cannot be null.");
    }

    public static IRuleBuilderOptions<T, TProperty> CannotBeEmpty<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, string fieldName)
    {
        return ruleBuilder
            .NotEmpty()
            .WithMessage($"{fieldName} cannot be empty.");
    }

    public static IRuleBuilderOptions<T, string> MustBeValidEmail<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .EmailAddress()
            .WithMessage("Email must be a valid email address.");
    }

    public static IRuleBuilderOptions<T, Guid?> MustBeValidAssignedUserGuid<T>(this IRuleBuilder<T, Guid?> ruleBuilder)
    {

        return ruleBuilder
            .Must(guid =>
                guid == null ||
                guid == Guid.Empty ||
                (Guid.TryParse(guid.ToString(), out var validatedGuid) && validatedGuid.ToString().Length == ApplicationConstants.Validators.AssignedUserIdLength))
            .WithMessage(ApplicationConstants.Validators.AssignedUserIdLengthWarningMessage);
    }

    public static IRuleBuilderOptions<T, int> MustBeGreaterThanZero<T>(this IRuleBuilder<T, int> ruleBuilder, string fieldName)
    {
        return ruleBuilder
            .GreaterThan(0)
            .WithMessage($"{fieldName} must be greater than 0.");
    }


    public static IRuleBuilderOptions<T, string> MustBeLengthBetween<T>(this IRuleBuilder<T, string> ruleBuilder, int minValue, int maxValue, string fieldName)
    {
        return ruleBuilder
            .Length(minValue, maxValue)
            .WithMessage($"{fieldName} must be between {minValue} and {maxValue} characters.");
    }

}
