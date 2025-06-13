using System.Reflection.PortableExecutable;
using System;
namespace examinitaion
{
    enum statuse
    {
        starting,
        finishing
    }
    class Question
    {
        public Question(string body, string header, int marks)
        {
            this.body = body;
            this.header = header;
            this.marks = marks;
        }
        public Question ()
        {
        }
        public string? body {  get;  set; }
        public string? header { get;  set; }
        public int marks { get;  set; }
    }
    class TrueOrFalse : Question
    {
        public TrueOrFalse(string answer , string body, string header, int marks) : base (body , header , marks)
        {
            this.answer = answer;
        }
        public string answer {  get; set; }
    }
    class ChooseOne : Question
    {
        public ChooseOne(string answer, List<string> options, string body, string header, int marks) : base(body, header, marks)
        {
            this.answer = answer;
            this.options = options;
        }
        public string answer {  get; set; }
        public List<string> options { get; set; }= new List<string>();
        public void PrintOptions()
        {
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i+1}-"+options[i]+"  ");
            }
            Console.WriteLine("\n");
        }
    }
    class Exam
    {
        public Exam()
        {
        }
        public Exam(List<TrueOrFalse> qustion1, List<ChooseOne> qustion2)
        {
            Qustion1 = qustion1;
            Qustion2 = qustion2;   
        }
        public List<TrueOrFalse>? Qustion1 { get; set; }= new List<TrueOrFalse>();
        public List<ChooseOne>? Qustion2 { get; set; } = new List<ChooseOne>();   
        public void AddQustion1(string ans,string body, string header , int mark)
        {
            TrueOrFalse ex = new TrueOrFalse(ans,body,header,mark);
            Qustion1.Add(ex);
        }
        public void AddQustion2(string ans , List<string>options , string body, string header,int mark)
        {
            ChooseOne ex = new ChooseOne( ans , options, body,header,mark);
            Qustion2.Add(ex);
        }
        public void Exam1(Exam exam)
        {
            int num,marks;
            string header, body, ans;
            Console.WriteLine("enter the number of the Qustions you want to enter ");
            num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("NOW enter thehead , the body , marks and the answer of the question ");
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("enter the head of the qustion \n");
                header = Console.ReadLine();
                Console.WriteLine("enter the body of the Question \n");
                body = Console.ReadLine();
                Console.WriteLine("enter tne marks of the question \n");
                marks = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter the answer of the qustion \n");
                ans = Console.ReadLine();
                exam.AddQustion1(ans, body, header, marks);
            }
            string answer;
            int total = 0;
            Console.WriteLine("the exam starts now good luck \n-------------\n");
            for (int i = 0; i < exam.Qustion1.Count(); i++)
            {
                Console.WriteLine(exam.Qustion1[i].header + "\n" + exam.Qustion1[i].body);
                answer = Console.ReadLine();
                if (string.Equals(answer, exam.Qustion1[i].answer, StringComparison.OrdinalIgnoreCase))
                    total += exam.Qustion1[i].marks;
                Console.WriteLine("------------------------\n");
            }
            Console.WriteLine($"your totle marks is {total}\n");
        }
        public void exam2(Exam exam)
        {
            int num, marks;
            string header, body, ans;
            Console.WriteLine("enter the number of the questons you want to enter \n");
            num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("NOW enter the head  , the body , the marks , the answer and the options \n");
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("enter the head of the qustion \n");
                header = Console.ReadLine();
                Console.WriteLine("enter the body of the Question \n");
                body = Console.ReadLine();
                Console.WriteLine("enter tne marks of the question \n");
                marks = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter the correct answer of the qustion \n");
                ans = Console.ReadLine();
                Console.WriteLine("enter 4 options to the Questions the correct answer is one of them \n");
                List<string> options = new List<string>();
                for (int j = 0; j < 4; j++)
                {
                    options.Add(Console.ReadLine());
                }
                exam.AddQustion2(ans, options, body, header, marks);
            }
            string answer;
            int total = 0;
            Console.WriteLine("the exam starts now good luck \n-------------\n");
            for (int i = 0; i < exam.Qustion2.Count(); i++)
            {
                Console.WriteLine(exam.Qustion2[i].header + "\n" + exam.Qustion2[i].body);
                exam.Qustion2[i].PrintOptions();
                answer = Console.ReadLine();
                if (string.Equals(answer, exam.Qustion2[i].answer, StringComparison.OrdinalIgnoreCase))
                    total += exam.Qustion2[i].marks;
            }
            Console.WriteLine($"your total marks is {total}\n");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Exam exam=new Exam();
            string choice;
            Console.WriteLine("if you want the exam to be true or false press T \n" +
                    "if you want thr exam to be choose one press C" +
                    "if you want to Quit press Q\n");
            do
            {
                choice = Console.ReadLine();
                if (choice.ToUpper() == "T")
                {
                    exam.Exam1(exam);
                    break;
                }
                else if (choice.ToUpper() == "C")
                {
                    exam.exam2(exam);
                    break;
                }
                else if (choice.ToUpper() == "Q")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("incorrect value\n");
                    continue;
                }
            }while (true);
            Console.WriteLine("thenk you \n");
        }
    }
}
