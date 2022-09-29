using static JapaneseCalculatorApp.Core.Calculator;

namespace JapaneseCalculatorApp.Core;

public partial class JapaneseCalculator
{
    private readonly Calculator calculator = new();

    public KanjiTypes KanjiType { get; set; } = KanjiTypes.CommonKanji;

    public void AppendNumeric(Numerics numeric) => this.calculator.AppendNumeric(numeric);

    public void AppendOperator(Operators @operator) => this.calculator.AppendOperator(@operator);

    public void ProcessCommand(Commands command) => this.calculator.ProcessCommand(command);

    public string TranslateToJapanese(string source)
    {
        if (Dictionary[KanjiType].TryGetValue(source, out string? translation) is true)
        {
            return translation;
        }

        string japanese = string.Empty;

        foreach (string? character in source.Select(x => x.ToString()))
        {
            if (Dictionary[KanjiType].TryGetValue(source, out string? translatedCharacter) is true)
            {
                japanese += translatedCharacter;
            }
        }

        return japanese;
    }

    public (string FirstOperand, string Operator, string SecondOperator) GetFormula()
    {
        Output output = this.calculator.GetOutput();
        return
            (FirstOperand: TranslateToJapanese(output.FirstOperand),
            Operator: TranslateToJapanese(output.Operator.ToString()),
            SecondOperator: TranslateToJapanese(output.SecondOperand));
    }

    public string GetResult() => TranslateToJapanese(this.calculator.GetOutput().Result);
}