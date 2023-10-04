using FluentValidation.Results;

namespace BuildingBlocks.ExceptionHandler.Exceptions;

public class ValidationException : ApplicationException
{
    public IDictionary<string, string[]> Erros { get; set; }

    public ValidationException() : base(message: "One or more validation error(s) occurred.")
    {
        Erros = new Dictionary<string, string[]>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Erros = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failure => failure.Key, failure => failure.ToArray());
    }
}