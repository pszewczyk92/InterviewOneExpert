using InterviewOneExpert.Services.Validators;

namespace InterviewOneExpert.Services.Tests.Unit.Validators;

public class OrderValidatorTests
{
    private readonly OrderValidator _sut;

    public OrderValidatorTests()
    {
        _sut = new OrderValidator();
    }

    [Theory]
    [InlineData(1, true)]
    [InlineData(0, false)]
    [InlineData(-1, false)]
    public void IsValid_AllCases_ReturnsExpectedResult(int orderId, bool expectedResult)
    {
        var result = _sut.IsValid(orderId);
        Assert.Equal(expectedResult, result);
    }
}
