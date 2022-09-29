namespace JapaneseCalculatorApp.Core;

public partial class JapaneseCalculator
{
    public enum KanjiTypes
    {
        CommonKanji,
        FormalKanji,
    }

    public Dictionary<KanjiTypes, Dictionary<string, string>> Dictionary { get; } = new()
    {
        {
            KanjiTypes.CommonKanji,
            new Dictionary<string, string>()
            {
                { "0", "零" },
                { "1", "一" },
                { "2", "二" },
                { "3", "三" },
                { "4", "四" },
                { "5", "五" },
                { "6", "六" },
                { "7", "七" },
                { "8", "八" },
                { "9", "九" },
                { ".", "点" },
                { "-", "負の" },
                { "Zero", "零" },
                { "One", "一" },
                { "Two", "二" },
                { "Three", "三" },
                { "Four", "四" },
                { "Five", "五" },
                { "Six", "六" },
                { "Seven", "七" },
                { "Eight", "八" },
                { "Nine", "九" },
                { "Point", "点" },
                { "Minus", "負の" },
                { "None", "" },
                { "Add", "足す" },
                { "Subtract", "引く" },
                { "Multiply", "掛ける" },
                { "Divide", "割る" },
                { "Calculate", "は" },
                { "ChangeSign", "正負" },
                { "AllClear", "全削除" },
                { "BackSpace", "戻る" },
            }
        },
        {
            KanjiTypes.FormalKanji,
            new Dictionary<string, string>()
            {
                { "0", "零" },
                { "1", "壱" },
                { "2", "弐" },
                { "3", "参" },
                { "4", "肆" },
                { "5", "伍" },
                { "6", "陸" },
                { "7", "漆" },
                { "8", "捌" },
                { "9", "玖" },
                { ".", "点" },
                { "-", "負の" },
                { "Zero", "零" },
                { "One", "一" },
                { "Two", "二" },
                { "Three", "三" },
                { "Four", "四" },
                { "Five", "五" },
                { "Six", "六" },
                { "Seven", "七" },
                { "Eight", "八" },
                { "Nine", "九" },
                { "Point", "点" },
                { "Minus", "負の" },
                { "None", "" },
                { "Add", "足す" },
                { "Subtract", "引く" },
                { "Multiply", "掛ける" },
                { "Divide", "割る" },
                { "Calculate", "は" },
                { "ChangeSign", "正負" },
                { "AllClear", "全削除" },
                { "BackSpace", "戻る" },
            }
        }
    };
}