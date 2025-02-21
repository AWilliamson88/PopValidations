﻿using ApprovalTests;
using FluentAssertions;
using PopValidations;
using PopValidations_Tests.TestHelpers;
using PopValidations_Tests.ValidationsTests.GenericTestableObjects;
using System.Threading.Tasks;
using Xunit;

namespace PopValidations_Tests.ValidationsTests.NotNullValidationTests.NotNullValidationTests;

public class NotNull_NoError_TestingValidator : AbstractValidator<NullAllFieldTypesDto>
{
    public NotNull_NoError_TestingValidator()
    {
        Describe(x => x.Integer).NotNull();
        Describe(x => x.String).NotNull();
        Describe(x => x.Decimal).NotNull();
        Describe(x => x.Double).NotNull();
        Describe(x => x.Short).NotNull();
        Describe(x => x.Long).NotNull();
        Describe(x => x.TwoComponentTuple).NotNull();
        Describe(x => x.TwoComponentNewTupple).NotNull();
        Describe(x => x.AllFieldTypesList).NotNull();
        Describe(x => x.AllFieldTypesLinkedList).NotNull();
        Describe(x => x.AllFieldTypesIEnumerable).NotNull();
        Describe(x => x.AllFieldTypesDictionary).NotNull();
        Describe(x => x.Struct).NotNull();
    }
}

public class NotNullValidation_RunnerTests
{
    [Fact]
    public async Task GivenAValidator_WithNoErrors_ThenNoErrorsAreProduced()
    {
        // Arrange
        var runner = ValidationRunnerHelper.BasicRunnerSetup(new NotNull_NoError_TestingValidator());

        // Act
        var validationResult = await runner.Validate(new NullAllFieldTypesDto());

        // Assert
        validationResult.Errors.Should().BeEmpty();
    }

    [Fact]
    public async Task GivenAValidator_WithErrors_ThenEveryFieldHasErrors()
    {
        // Arrange
        var runner = ValidationRunnerHelper.BasicRunnerSetup(new NotNull_NoError_TestingValidator());

        // Act
        var validationResult = await runner.Validate(new NullAllFieldTypesDto()
        {
            Integer = null,
            String = null,
            Decimal = null,
            Double = null,
            Short = null,
            Long = null,
            TwoComponentTuple = null,
            TwoComponentNewTupple = null,
            AllFieldTypesList = null,
            AllFieldTypesLinkedList = null,
            AllFieldTypesIEnumerable = null,
            AllFieldTypesDictionary = null,
            Struct = null,
        });
        var json = JsonConverter.ToJson(validationResult);

        // Assert
        validationResult.Errors.Should().HaveCount(13);
        Approvals.VerifyJson(json);
    }
}
