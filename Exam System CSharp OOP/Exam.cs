namespace Exam_System_CSharp_OOP;

public abstract class Exam
{
    public int Time { get; set; }
    public int NumberOfQuestions { get; set; }

    public Exam(int time, int numberOfQuestions)
    {
        Time = time;
        NumberOfQuestions = numberOfQuestions;
    }
    
    public Question[] Questions { get; set; }

    public abstract void ShowExam();
    public abstract void CreateQuestions();
}

public class FinalExam : Exam
{
    public FinalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions)
    {
        
    }
    
    public override void ShowExam()
    {
        // print question and answers
        // ask user to choice answer
        int totalMarks = 0;
        int UserMarks = 0;
        for (int i = 0; i < NumberOfQuestions; i++)
        {
            Console.WriteLine(Questions[i].ToString());
            Console.WriteLine();
            int userAnswersId = Validator.GetValidInt("Enter answer id: ", 1, 4);
            if (userAnswersId == Questions[i].CorrectAnswerId)
                    UserMarks += Questions[i].Mark;
            totalMarks += Questions[i].Mark;
        }
        
        // after exam
        // show questions and their answers and grade
        for (int i = 0; i < NumberOfQuestions; i++)
        {
            Console.WriteLine(Questions[i].ToString());
            Console.WriteLine();
        }

        Console.WriteLine($"Grade: {UserMarks} of {totalMarks}");
    }
    public override void CreateQuestions()
    {
        // 1. initialize questions array
        Questions = new Question[NumberOfQuestions];

        for (int i = 0; i < NumberOfQuestions; i++)
        {
            Questions[i] = CreateQuestion();
            Questions[i].CreateAnswers();
        }
    }

    private Question CreateQuestion()
    {
        Question question;
        // 1. ask user for question type (1. MCQ, 2. TF)
        int Type = Validator.GetValidInt("Enter question type (1. MCQ, 2. TF)", 1, 2);
        string header = Validator.GetValidString("Enter the header of question", 3, 20);
        string body = Validator.GetValidString("Enter the body of question", 10, 20);
        int mark = Validator.GetValidInt("Enter the mark of question", 1, 10);

        if (Type == 1)
            question = new MCQQuestion(header, body, mark);
        else
            question = new TFQuestion(header, body, mark);

        return question;
    }
}

public class PracticalExam : Exam
{
    public PracticalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions)
    {
        
    }
    
    public override void ShowExam()
    {
        // print question and answers
        // ask user to choice answer
        for (int i = 0; i < NumberOfQuestions; i++)
        {
            Console.WriteLine(Questions[i].ToString());
            Console.WriteLine();
            int userAnswersId = Validator.GetValidInt("Enter answer id: ", 1, 4);
        }
        
        
        // after exam
        // show right answers
        for (int i = 0; i < NumberOfQuestions; i++)
        {
            Console.WriteLine(Questions[i].Answers[Questions[i].CorrectAnswerId-1]);
            Console.WriteLine();
        }
        
    }
    public override void CreateQuestions()
    {
        // 1. initialize questions array
        Questions = new MCQQuestion[NumberOfQuestions];

        for (int i = 0; i < NumberOfQuestions; i++)
        {
            Questions[i] = CreateQuestion();
            Questions[i].CreateAnswers();
        }
    }

    private MCQQuestion CreateQuestion()
    {
        string header = Validator.GetValidString("Enter the header of question", 3, 20);
        string body = Validator.GetValidString("Enter the body of question", 10, 20);
        int mark = Validator.GetValidInt("Enter the mark of question", 1, 10);
        
        return new MCQQuestion(header, body, mark);
    }
}