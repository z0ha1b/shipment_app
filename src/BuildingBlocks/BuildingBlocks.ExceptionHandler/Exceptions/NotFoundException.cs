namespace BuildingBlocks.ExceptionHandler.Exceptions;

public class NotFoundException: ApplicationException
{
    public NotFoundException(string name, object key) : base($"Entity {name} - {key} is not found.")
    {
    }
}