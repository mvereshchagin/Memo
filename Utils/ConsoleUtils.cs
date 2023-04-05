namespace Utils;

public class ConsoleUtils
{
    private readonly IConsole _console; 
    public ConsoleUtils(IConsole console)
    {
        _console = console;
    }

    public int ReadInt(
        string question, 
        string answerIfNotNumber = "A value must be a number",
        string answerIfIncorrectRange = "Incorrect value", 
        int? minValue = Int32.MinValue, 
        int? maxValue = Int32.MaxValue)
    {
        minValue = minValue ?? int.MinValue;
        maxValue = maxValue ?? int.MaxValue;

        int answer;

        do
        {
            _console.WriteLine(question);

            var strAnswer = _console.ReadLine();
            if (!Int32.TryParse(strAnswer, out answer))
            {
                _console.WriteLine(answerIfNotNumber);
                continue;

            }

            if (answer < minValue || answer > maxValue)
            {
                _console.WriteLine(answerIfIncorrectRange);
                continue;
            }

            break;
        }
        while (true);

        return answer;
    }

    public string? ReadString(
        string question, 
        bool allowEmpty = true, 
        string answerIfEmpty = "Empty is not allowed")
    {
        do
        {
            _console.WriteLine(question);
            var answer = _console.ReadLine();
            if (!allowEmpty && String.IsNullOrEmpty(answer))
            {
                _console.WriteLine(answerIfEmpty);
                continue;
            }

            return answer;
        }
        while (true);
    }
}
