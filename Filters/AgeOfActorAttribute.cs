using System;
using AutoMapper;

namespace MoviesApp.Filters;
using System.ComponentModel.DataAnnotations;


public class AgeOfActorAttribute : ValidationAttribute
{
    public AgeOfActorAttribute(int minAge,int maxAge)
    {
        MinAge = minAge;
        MaxAge = maxAge;
    }
    public int MinAge { get; }
    public int MaxAge { get; }

    public string GetErrorMessage() =>
        $"Actors must have birth date between {DateTime.Now.Year-MaxAge} and {DateTime.Now.Year - MinAge}.";

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var birthYear = ((DateTime) value).Year;
        Console.WriteLine("YearYearYear"+birthYear);
        if (birthYear < DateTime.Now.Year - MaxAge || birthYear > DateTime.Now.Year - MinAge)
        {
            return new ValidationResult(GetErrorMessage());
        }
        return ValidationResult.Success;
    }
}