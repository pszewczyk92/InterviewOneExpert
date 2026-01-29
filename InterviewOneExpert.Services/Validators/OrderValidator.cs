using InterviewOneExpert.Services.Abstractions.Validators;

namespace InterviewOneExpert.Services.Validators;

public class OrderValidator : IOrderValidator
{
    public bool IsValid(int orderId)
    {
        return orderId > 0;
    }
}
