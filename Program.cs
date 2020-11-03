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
            return g.LastName;
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
            GraduateStudent g1 = new GraduateStudent(new Person("Anna", "Fedorova", new DateTime()), new Person("Anna", "Fedorova", new DateTime()), "pos", "spec", 0, 3);
            GraduateStudent g2 = new GraduateStudent(new Person("Zain", "Cherry", new DateTime()), new Person("Zain", "Cherry", new DateTime()), "pos", "spec", 0, 3);
            GraduateStudent g3 = new GraduateStudent(new Person("Kimberley", "Harmon", new DateTime()), new Person("Kimberley", "Harmon", new DateTime()), "pos", "spec", 0, 3);
            GraduateStudent g4 = new GraduateStudent(new Person("Kairon", "Sharp", new DateTime()), new Person("Kairon", "Sharp", new DateTime()), "pos", "spec", 0, 3);
            GraduateStudent g5 = new GraduateStudent(new Person("Gurveer", "Fulton", new DateTime()), new Person("Gurveer", "Fulton", new DateTime()), "pos", "spec", 0, 3);
            GraduateStudent g6 = new GraduateStudent(new Person("Catrina", "Allen", new DateTime()), new Person("Catrina", "Allen", new DateTime()), "pos", "spec", 0, 3);
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
            Console.WriteLine($"Max learning year:\n{coll1.MaxLearningYear}");
            Console.WriteLine($"Tution form full time:\n{coll1.TuitionForm(FormOfStudy.FullTime)}");
            Console.WriteLine($"Grouped by form of study:\n{coll1.Grouped}");
        }
    }
}
