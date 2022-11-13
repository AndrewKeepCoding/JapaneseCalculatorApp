using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JapaneseCalculatorApp.Core;
using System;
using System.Collections.Generic;
using static JapaneseCalculatorApp.Core.Calculator;
using static JapaneseCalculatorApp.Core.JapaneseCalculator;

namespace JapaneseCalculatorApp.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private readonly JapaneseCalculator japaneseCalculator;

    [ObservableProperty]
    private Dictionary<string, ElementViewModel> elements = new();

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AppendOperatorCommand))]
    [NotifyCanExecuteChangedFor(nameof(AppendPointCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateCommand))]
    [NotifyCanExecuteChangedFor(nameof(ChangeSignCommand))]
    [NotifyCanExecuteChangedFor(nameof(BackSpaceCommand))]
    [NotifyCanExecuteChangedFor(nameof(AllClearCommand))]
    private string firstOperand = string.Empty;

    [ObservableProperty]
    private string formula = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AppendOperatorCommand))]
    [NotifyCanExecuteChangedFor(nameof(AppendPointCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateCommand))]
    [NotifyCanExecuteChangedFor(nameof(ChangeSignCommand))]
    [NotifyCanExecuteChangedFor(nameof(BackSpaceCommand))]
    [NotifyCanExecuteChangedFor(nameof(AllClearCommand))]
    private string mathOperator = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AppendOperatorCommand))]
    [NotifyCanExecuteChangedFor(nameof(AppendPointCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateCommand))]
    [NotifyCanExecuteChangedFor(nameof(ChangeSignCommand))]
    [NotifyCanExecuteChangedFor(nameof(BackSpaceCommand))]
    [NotifyCanExecuteChangedFor(nameof(AllClearCommand))]
    private string result = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AppendOperatorCommand))]
    [NotifyCanExecuteChangedFor(nameof(AppendPointCommand))]
    [NotifyCanExecuteChangedFor(nameof(CalculateCommand))]
    [NotifyCanExecuteChangedFor(nameof(ChangeSignCommand))]
    [NotifyCanExecuteChangedFor(nameof(BackSpaceCommand))]
    [NotifyCanExecuteChangedFor(nameof(AllClearCommand))]
    private string secondOperand = string.Empty;

    public MainPageViewModel(JapaneseCalculator japaneseCalculator)
    {
        this.japaneseCalculator = japaneseCalculator;
        this.japaneseCalculator.KanjiType = KanjiTypes.CommonKanji;

        foreach (string numeric in Enum.GetNames<Numerics>())
        {
            Elements[numeric] = new ElementViewModel(this.japaneseCalculator.TranslateToJapanese(numeric)) { IsNumeric = true };
        }

        foreach (string @operator in Enum.GetNames<Operators>())
        {
            Elements[@operator] = new ElementViewModel(this.japaneseCalculator.TranslateToJapanese(@operator));
        }

        foreach (string command in Enum.GetNames<Commands>())
        {
            Elements[command] = new ElementViewModel(this.japaneseCalculator.TranslateToJapanese(command));
        }

        Elements["SwitchKanjiType"] = new ElementViewModel(this.japaneseCalculator.TranslateToJapanese("SwitchKanjiType"));
    }

    private KanjiTypes CurrentKanjiType { get; set; } = KanjiTypes.CommonKanji;

    [RelayCommand]
    private void AppendNumeric(string numericName)
    {
        if (Enum.TryParse(numericName, out Numerics numeric) is true)
        {
            this.japaneseCalculator.AppendNumeric(numeric);
            (FirstOperand, MathOperator, SecondOperand) = this.japaneseCalculator.GetFormula();
            Result = string.Empty;
        }
    }

    [RelayCommand(CanExecute = nameof(CanAppendOperator))]
    private void AppendOperator(string operatorName)
    {
        if (Enum.TryParse(operatorName, out Operators @operator) is true)
        {
            this.japaneseCalculator.AppendOperator(@operator);
            (FirstOperand, MathOperator, SecondOperand) = this.japaneseCalculator.GetFormula();
            Result = string.Empty;
        }
    }

    [RelayCommand(CanExecute = nameof(CanAppendPoint))]
    private void AppendPoint()
    {
        this.japaneseCalculator.AppendNumeric(Numerics.Point);
        (FirstOperand, MathOperator, SecondOperand) = this.japaneseCalculator.GetFormula();
        Result = string.Empty;
    }

    [RelayCommand(CanExecute = nameof(CanCalculate))]
    private void Calculate()
    {
        this.japaneseCalculator.ProcessCommand(Commands.Calculate);
        (FirstOperand, MathOperator, SecondOperand) = this.japaneseCalculator.GetFormula();
        Result = this.japaneseCalculator.GetResult();
    }

    [RelayCommand]
    private void SwitchNumberKanjis()
    {
        this.japaneseCalculator.KanjiType = this.japaneseCalculator.KanjiType is KanjiTypes.CommonKanji
            ? KanjiTypes.FormalKanji
            : KanjiTypes.CommonKanji;

        foreach (KeyValuePair<string, ElementViewModel> element in Elements)
        {
            if (element.Value.IsNumeric is true)
            {
                element.Value.DisplayName = this.japaneseCalculator.TranslateToJapanese(element.Key);
            }
        }

        (FirstOperand, MathOperator, SecondOperand) = this.japaneseCalculator.GetFormula();
        Result = this.japaneseCalculator.GetResult();
    }

    [RelayCommand(CanExecute = nameof(CanAllClear))]
    private void AllClear()
    {
        this.japaneseCalculator.ProcessCommand(Commands.AllClear);
        (FirstOperand, MathOperator, SecondOperand) = this.japaneseCalculator.GetFormula();
        Result = this.japaneseCalculator.GetResult();
    }

    [RelayCommand(CanExecute = nameof(CanBackSpace))]
    private void BackSpace()
    {
        this.japaneseCalculator.ProcessCommand(Commands.BackSpace);
        (FirstOperand, MathOperator, SecondOperand) = this.japaneseCalculator.GetFormula();
        Result = this.japaneseCalculator.GetResult();
    }

    [RelayCommand(CanExecute = nameof(CanChangeSign))]
    private void ChangeSign()
    {
        this.japaneseCalculator.ProcessCommand(Commands.ChangeSign);
        (FirstOperand, MathOperator, SecondOperand) = this.japaneseCalculator.GetFormula();
    }

    private bool CanAppendOperator() => this.japaneseCalculator.CanAppendOperator();

    private bool CanAppendPoint() => this.japaneseCalculator.CanAppendPoint();

    private bool CanCalculate() => this.japaneseCalculator.CanCalculate();

    private bool CanChangeSign() => this.japaneseCalculator.CanChangeSign();

    private bool CanBackSpace() => this.japaneseCalculator.CanBackSpace();

    private bool CanAllClear() => this.japaneseCalculator.CanAllClear();
}