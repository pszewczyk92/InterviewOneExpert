namespace InterviewOneExpert.Services.Abstractions.Validators;

public interface IOrderValidator
{
    bool IsValid(int orderId);
}
