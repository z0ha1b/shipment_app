namespace Shipment.Core.Validators.Interface;

public interface IValidators
{
    public Task<bool> EmailValidator();
}