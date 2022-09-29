namespace JapaneseCalculatorApp.Core;

public partial class Calculator
{
    public record Output(
        string FirstOperand,
        Operators Operator,
        string SecondOperand,
        string Result);

    public Calculator()
    {
        CommandActions[Commands.Calculate] = new Action(() =>
        {
            Result = Calculate(
                double.Parse(GetNumberString(FirstOperand)),
                Operator,
                double.Parse(GetNumberString(SecondOperand)))
            .ToString();
        });

        CommandActions[Commands.ChangeSign] = new Action(() =>
        {
            if (SecondOperand.Count > 0 &&
                SecondOperand.Remove(Numerics.Minus) is false)
            {
                SecondOperand.Insert(0, Numerics.Minus);
            }
            else if (FirstOperand.Count > 0 &&
                FirstOperand.Remove(Numerics.Minus) is false)
            {
                FirstOperand.Insert(0, Numerics.Minus);
            }
        });

        CommandActions[Commands.AllClear] = new Action(() =>
        {
            FirstOperand.Clear();
            SecondOperand.Clear();
            Operator = Operators.None;
            Result = string.Empty;
        });

        CommandActions[Commands.BackSpace] = new Action(() =>
        {
            if (SecondOperand.Count > 0)
            {
                Result = string.Empty;
                SecondOperand.RemoveRange(SecondOperand.Count - 1, 1);
            }
            else if (Operator is not Operators.None)
            {
                Operator = Operators.None;
            }
            else if (FirstOperand.Count > 0)
            {
                FirstOperand.RemoveRange(FirstOperand.Count - 1, 1);
            }
        });
    }

    private Dictionary<Commands, Action> CommandActions { get; } = new();

    private List<Numerics> FirstOperand { get; } = new();

    private Operators Operator { get; set; } = Operators.None;

    private string Result { get; set; } = string.Empty;

    private List<Numerics> SecondOperand { get; } = new();

    public void AppendNumeric(Numerics numeric)
    {
        if (Result.Length > 0)
        {
            CommandActions[Commands.AllClear]();
        }

        if (Operator is not Operators.None)
        {
            SecondOperand.Add(numeric);
        }
        else
        {
            FirstOperand.Add(numeric);
        }
    }

    public void AppendOperator(Operators @operator)
    {
        if (SecondOperand.Count == 0 &&
            FirstOperand.Count > 0)
        {
            Operator = @operator;
        }
    }

    public Output GetOutput()
    {
        return new Output(
            FirstOperand: GetNumberString(FirstOperand),
            Operator: Operator,
            SecondOperand: GetNumberString(SecondOperand),
            Result: Result);
    }

    public void ProcessCommand(Commands command) => CommandActions[command]();

    private static double Calculate(double firstOperand, Operators @operator, double secondOperand)
    {
        return (firstOperand, @operator, secondOperand) switch
        {
            (_, Operators.Add, _) => firstOperand + secondOperand,
            (_, Operators.Subtract, _) => firstOperand - secondOperand,
            (_, Operators.Multiply, _) => firstOperand * secondOperand,
            (_, Operators.Divide, 0) => throw new DivideByZeroException($"{firstOperand}{@operator}{secondOperand}"),
            (_, Operators.Divide, _) => firstOperand / secondOperand,
            _ => throw new InvalidOperationException($"{firstOperand}{@operator}{secondOperand}"),
        };
    }

    private static string GetNumberString(IEnumerable<Numerics> elements)
    {
        string numberString = string.Empty;

        foreach (int element in elements.Select(x => (int)x))
        {
            numberString += element switch
            {
                < 10 => element.ToString(),
                10 => ".",
                11 => "-",
                _ => throw new NotImplementedException($"{element}"),
            };
        }

        return numberString;
    }
}