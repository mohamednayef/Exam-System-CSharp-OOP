namespace Exam_System_CSharp_OOP;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Subject(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }
    public Exam Exam { get; set; }

    public void CreateExam()
    {
        // 1. ask user for exam type (final/practical)
        int examType = Validator.GetValidInt("Enter exam type (1. final, 2. practical)", 1, 2);
        
        // 2. enter basic data of the exam (time, number of questions)
        int time = Validator.GetValidInt("Enter exam time in minutes", 30, 180);
        int numberOfQuestions = Validator.GetValidInt("Enter exam number of questions", 1, 10);

        if (examType == 1)
        {
            Exam = new FinalExam(time, numberOfQuestions);
        }
        else if (examType == 2)
        {
            Exam = new PracticalExam(time, numberOfQuestions);
        }
        
        // 3. create questions, answers
        Exam.CreateQuestions();
        
        // 4. show exam result
    }
}