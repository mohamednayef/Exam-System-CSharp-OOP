using System.Text;

namespace Exam_System_CSharp_OOP;

public abstract class Question
{
    public int numberOfMCQAnswers = 4;
    public int numberOfTFAnswers = 2;
    public string Header { get; set; }
    public string Body { get; set; }
    public int Mark { get; set; }

    public Question(string header, string body, int mark)
    {
        Header = header;
        Body = body;
        Mark = mark;
    }
    
    public Answer[] Answers { get; set; }
    public int CorrectAnswerId { get; set; }
    public abstract void CreateAnswers();

    public override string ToString()
    {
        StringBuilder result = new($"Header: {Header}\nBody: {Body}\nMark: {Mark}\n");
        for (int i = 0; i < Answers.Length; i++)
        {
            result.Append($"{i+1}. {Answers[i].ToString()}\n");
        }
        return result.ToString();
    }
}

public class MCQQuestion : Question
{
    public MCQQuestion(string header, string body, int mark) : base(header, body, mark)
    {
        
    }

    public override void CreateAnswers()
    {
        Answers = new Answer[numberOfMCQAnswers];
        for (int i = 0; i < numberOfMCQAnswers; i++)
        {
            string text = Validator.GetValidString($"Enter answer {i + 1} text", 1, 50);
            Answers[i] = new Answer(i+1, text);
        }
        CorrectAnswerId = Validator.GetValidInt("Enter correct answer id:", 1, numberOfMCQAnswers);
    }
}

public class TFQuestion : Question
{
    public TFQuestion(string header, string body, int mark) : base(header, body, mark)
    {
        
    }

    public override void CreateAnswers()
    {
        Answers = new Answer[numberOfTFAnswers];
        Answers[0] = new Answer(1, "True");
        Answers[1] = new Answer(2, "False");
        CorrectAnswerId = Validator.GetValidInt("Enter correct answer id:", 1, numberOfTFAnswers);
    }
}