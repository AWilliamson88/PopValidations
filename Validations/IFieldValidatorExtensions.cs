﻿using System;
using System.Collections.Generic;
using PopValidations.FieldDescriptors.Base;
using PopValidations.Scopes.ForEachs;
using PopValidations.ValidatorInternals;

namespace PopValidations;

public static partial class IFieldValidatorExtensions
{
    public static IFieldDescriptor<TValidationType, TFieldType?> Vitally<TValidationType, TFieldType>(this IFieldDescriptor<TValidationType, TFieldType?> fieldDescriptor)
    {
        fieldDescriptor.NextValidationIsVital();
        return fieldDescriptor;
    }

    public static IFieldDescriptor<TValidationType, TFieldType> SetValidator<TValidationType, TFieldType>(
        this IFieldDescriptor<TValidationType, TFieldType> fieldDescriptor,
        ISubValidatorClass validatorClass
    )
    {
        fieldDescriptor.AddValidation(validatorClass);
        return fieldDescriptor;
    }

    public static IFieldDescriptor<TClassType, IEnumerable<TPropertyType?>?> ForEach<TClassType, TPropertyType>(
            this IFieldDescriptor<TClassType, IEnumerable<TPropertyType?>?> fieldDescriptor,
            Action<IFieldDescriptor<IEnumerable<TPropertyType?>, TPropertyType?>> actions
            )
    {
        var forEachScope = new ForEachScope<TClassType, TPropertyType>(
            fieldDescriptor,
            actions
        );
        fieldDescriptor.AddValidation(forEachScope);
        return fieldDescriptor;
    }
}