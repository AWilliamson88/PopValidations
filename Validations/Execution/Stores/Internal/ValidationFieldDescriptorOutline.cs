﻿using PopValidations.FieldDescriptors.Base;

namespace PopValidations.Execution.Stores.Internal;

class ValidationFieldDescriptorOutline : IFieldDescriptorOutline
{
    private readonly IFieldDescriptorOutline outline;

    public ValidationFieldDescriptorOutline(
        string propertyName,
        IFieldDescriptorOutline outline
    )
    {
        PropertyName = propertyName;
        this.outline = outline;
    }

    public string PropertyName { get; }

    public string AddTo(string existing)
    {
        return existing + "." + PropertyName;// outline.PropertyName;
    }

    public object? GetValue(object? input)
    {
        return outline.GetValue(input);
    }
}