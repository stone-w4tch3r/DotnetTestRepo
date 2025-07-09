using System.Linq;

FormattingTest.NotOkNestedFormatting();

public class FormattingTest
{
    public static void OkNestedFormatting(int orderId, int amount, string paymentMethod)
    {
        var paymentService = new PaymentService();
        var result =
            (orderId > 0)
                ? paymentService.IsPaymentSuccessful(amount, paymentMethod)
                    ? amount > 1000
                        ? "Order Processed: Premium Customer Discount Applied"
                        : "Order Processed: Standard Customer"
                    : "Order Failed: Payment Declined"
                : "Order Failed: Invalid Order ID";
    }

    public static void NotOkNestedFormatting()
    {
        var steps = (Step[])[new(), new()];
        var test =
            steps[^1].Type.ToString().Contains('x') ? 100
            : steps.ToList().LastOrDefault(x => x is { Type: StepType.Failure }) is Step s ? s.Count
            : 1;
    }
}

public class Step
{
    public StepType Type { get; set; }

    public int Count { get; set; }
}

public enum StepType
{
    Success,
    Failure,
}

class PaymentService
{
    public bool IsPaymentSuccessful(decimal amount, string paymentMethod) =>
        amount > 0 && paymentMethod != "Declined";
}
