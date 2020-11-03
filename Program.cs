using System;
namespace laboratorna_2_3_semester
{
    public enum FormOfStudy
    {
        FullTime,
        PartTime,
        Distance
    }
    public enum Revision
    {
        Remove,
        Replace,
        Property
    }
    class Program
    {
        static string MakeKey(GraduateStudent g)
        {
            return g.Name;
        }
        static void Main(string[] args)
        {
            GraduateStudentCollection<string> coll1 = new GraduateStudentCollection<string>(MakeKey);
            GraduateStudentCollection<string> coll2 = new GraduateStudentCollection<string>(MakeKey);
            TeamsJournal journal = new TeamsJournal();
            coll1.Name = "firstCollection";
            coll2.Name = "secondCollection";
            coll1.GraduateStudentsChanged += journal.GraduateStudentsChangedHandler;
            coll2.GraduateStudentsChanged += journal.GraduateStudentsChangedHandler;
            coll1.AddDefaults(4);
            GraduateStudent g1 = new GraduateStudent();
            GraduateStudent g2 = new GraduateStudent();
            GraduateStudent g3 = new GraduateStudent();
            GraduateStudent g4 = new GraduateStudent();
            GraduateStudent g5 = new GraduateStudent();
            GraduateStudent g6 = new GraduateStudent();
            coll1.AddGraduateStudent(g1, g2, g3);
            coll2.AddGraduateStudent(g1, g2, g3);
            coll2.AddDefaults(3);
            g1.Speciality = "Specialty is changed";
            g4.Form = FormOfStudy.Distance;
            coll1.Remove(g2);
            g2.Form = FormOfStudy.PartTime;
            GraduateStudent g7 = new GraduateStudent(new Person(), new Person(), "pos", "spec", 0, 3);
            coll2.Replace(g3, g7);
            g3.Speciality = "Specialty is changed";
            Console.WriteLine(journal);
            //Person person1 = new Person();
            //Person person2 = new Person();
            //Console.WriteLine("Person2 and Person1 are the same instance: " + ReferenceEquals(person2, person1));
            //Console.WriteLine("Person2 equals Person1: " + person2.Equals(person1));
            //Console.WriteLine($"Person1 hash code: {person1.GetHashCode()}");
            //Console.WriteLine($"Person2 hash code: {person2.GetHashCode()}");
            //GraduateStudent graduate = new GraduateStudent();
            //Random rand = new Random();
            //Article[] a = new Article[3];
            //for (int i = 0; i < a.Length; i++)
            //{
            //    int y = rand.Next((DateTime.Today.Year - graduate.LearningYear + 1), DateTime.Today.Year);
            //    int m = rand.Next(1, 12);
            //    int d = rand.Next(1, 28);
            //    a[i] = new Article($"article{i + 1}", $"place{i + 1}", new DateTime(y, m, d));
            //}
            //graduate.AddArticles(a);
            //Notes[] n = new Notes[3];
            //for (int i = 0; i < n.Length; i++)
            //{
            //    int y = rand.Next((DateTime.Today.Year - graduate.LearningYear + 1), DateTime.Today.Year);
            //    int m = rand.Next(1, 12);
            //    int d = rand.Next(1, 28);
            //    n[i] = new Notes($"note{i + 1}", $"conference{i + 1}", new DateTime(y, m, d));
            //}
            //graduate.AddNotes(n);
            //Console.WriteLine("\n\n\n\n\n\n Original graduate student: \n\n\n\n\n\n");
            //Console.WriteLine(graduate);
            //Console.WriteLine("\n\n\n\n\n\n The value of 'Person' property of the original graduate student: \n\n\n\n\n\n");
            //Console.WriteLine(graduate.PersonProperty);
            //GraduateStudent graduate1 = (GraduateStudent)graduate.DeepCopy();
            //graduate.PersonProperty = new Person("Lidia", graduate.LastName, graduate.Date);
            //graduate.ArticlesPublished[0].Name = "**********************Name of this article has been changed******************";
            //Console.WriteLine("\n\n\n\n\n\n Deep copy of the graduate student: \n\n\n\n\n\n");
            //Console.WriteLine(graduate1);
            //Console.WriteLine("\n\n\n\n\n\n Original graduate student: \n\n\n\n\n\n");
            //Console.WriteLine(graduate);
            //Console.WriteLine("\n\n\n\n\n\n Attempt to assign incorrect value to learning year \n");
            //try
            //{
            //    graduate.LearningYear = 5;
            //}
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}


            //Console.WriteLine("\n\n\n\n\n\n Union of articles: \n\n\n\n\n\n");
            //foreach (var v in graduate.UnionOfArticlesAndNotes())
            //{
            //    Console.WriteLine(v);
            //}
            //Console.WriteLine("\n\n\n\n\n\n Recent articles: \n\n\n\n\n\n");
            //foreach (Article artic in graduate.RecentArticles(2))
            //{
            //    Console.WriteLine(artic);
            //}
        }
    }
}
