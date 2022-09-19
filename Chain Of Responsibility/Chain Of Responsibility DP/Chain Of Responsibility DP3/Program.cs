using System;
using System.Collections.Generic;
using System.Linq;

namespace Chain_Of_Responsibility_DP3
{
    class Program
    {
        static void Main(string[] args)
        {
            IParticipant p3 = new Participant(null) { Name = "Raja" };
            IParticipant p2 = new Participant(p3) { Name = "Sree" };
            IParticipant p1 = new Participant(p2) { Name = "Sumesh" };
            p3.NextParticipent = p1;
            List<IParticipant> participents = new List<IParticipant>() { p1, p2, p3 };



            IQuestion q1 = new Question("Is CPU a part of computer?", "Yes");
            IQuestion q2 = new Question("Is IAS a computer course?", "No");
            IQuestion q3 = new Question("Is computer an electronic device?", "Yes");
            List<IQuestion> questions = new List<IQuestion>() { q1, q2, q3 };


            QuizHost myQuiz = new QuizHost(questions, participents);
            myQuiz.StartEvent();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
    class QuizHost
    {
        private List<IQuestion> _questions;
        private List<IParticipant> _participents;

        public QuizHost(List<IQuestion> questions, List<IParticipant> participents)
        {
            _questions = questions;
            _participents = participents;
        }

        public void StartEvent()
        {
            Console.WriteLine("Start of quiz. Welcome All.\n");

            IParticipant currentParticipent = _participents.First();

            foreach (var q in _questions)
            {
                q.Owner = currentParticipent;
                currentParticipent.DoAnswer(q);
                currentParticipent = currentParticipent.NextParticipent;
            }

            Console.WriteLine("\nEnd of quiz. Score card.");
            foreach (var p in _participents)
            {
                Console.WriteLine(p.Name + " : " + p.Score);
            }

            Console.WriteLine("\nThanks for participating.");
        }
    }

    interface IQuestion
    {
        string Question1 { get; set; }
        IParticipant Owner { get; set; }
        bool CheckAnswer(string ans);
    }

    class Question : IQuestion
    {
        public string Question1 { get; set; }
        public IParticipant Owner { get; set; }
        private string Answer;

        public Question(string q, string a)
        {
            Question1 = q;
            Answer = a;
        }

        public bool CheckAnswer(string ans)
        {
            return ans.Equals(Answer, StringComparison.InvariantCultureIgnoreCase);
        }
    }

    interface IParticipant
    {
        string Name { get; set; }
        int Score { get; set; }
        IParticipant NextParticipent { get; set; }
        void DoAnswer(IQuestion question);
    }

    class Participant : IParticipant
    {
        public IParticipant NextParticipent { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }

        public Participant(IParticipant nextParticipent)
        {
            NextParticipent = nextParticipent;
            Score = 0;
        }

        public void DoAnswer(IQuestion question)
        {
            Console.WriteLine("Hi " + Name + ", Please answer for the question " + question.Question1);
            string ans = Console.ReadLine();

            if (question.CheckAnswer(ans))
            {
                Console.WriteLine("Correct Answer");
                this.Score += 1;
            }
            else if (NextParticipent != question.Owner)
            {
                Console.WriteLine("Wrong Answer. Pass on to next participent.");
                NextParticipent.DoAnswer(question);
            }
            else
            {
                Console.WriteLine("No one answered");
            }
        }
    }
}
