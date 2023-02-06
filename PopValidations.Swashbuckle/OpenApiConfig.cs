﻿using PopValidations.Swashbuckle.Converters;

namespace PopValidations.Swashbuckle;

public class OpenApiConfig
{
    public string CustomValidationAttribute { get; set; } = "x-validation";
    public bool IncludeCustomValidations { get; set; } = true;
    public List<IValidationToOpenApiConverter> Converters = new()
    {
        new NotNullValidationToOpenApiConverter(),
        new IsEqualToValidationToOpenApiConverter(),
        new IsNullValidationToOpenApiConverter(),
    };
}
