namespace JapaneseCalculatorApp.Core;

public partial class Calculator
{
    public enum Numerics
    {
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,

        Point = 10,
        Minus = 11,
    }

    public enum Operators
    {
        None,
        Add,
        Subtract,
        Multiply,
        Divide,
    }

    public enum Commands
    {
        Calculate,
        ChangeSign,
        AllClear,
        BackSpace,
    }
}