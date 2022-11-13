using static JapaneseCalculatorApp.Core.Calculator;

namespace JapaneseCalculatorApp.Core;

public static class CalculatorExtensions
{
    public static bool IsEmpty(this IReadOnlyList<Numerics> number)
    {
        return number.Count is 0;
    }

    public static bool IsZero(this IReadOnlyList<Numerics> number)
    {
        return number.Count is 1 && number[0] is Numerics.Zero;
    }

    public static bool HasPoint(this IReadOnlyList<Numerics> number)
    {
        return number.Contains(Numerics.Point);
    }

    public static bool CanAppendPoint(this IReadOnlyList<Numerics> number)
    {
        return number.Count > 0 && number.HasPoint() is false;
    }

    public static bool CanChangeSign(this IReadOnlyList<Numerics> number)
    {
        return number.IsEmpty() is false && number.IsZero() is false;
    }
}