using System.Diagnostics;

namespace Exam_System_CSharp_OOP;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Subject subject = new Subject(10, "database");
        subject.CreateExam();
        
        int startExam = Validator.GetValidInt("Do u want to start the exam(1. YES, 2. NO):", 1, 2);
        if (startExam == 1)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            subject.Exam.ShowExam();
            stopwatch.Stop();
            Console.WriteLine($"Elapsed Time: {stopwatch.ElapsedMilliseconds / 1000} s");
        }
        else
            Console.WriteLine("Ok, thank you!");
        
        Console.Write("%");
    }
}