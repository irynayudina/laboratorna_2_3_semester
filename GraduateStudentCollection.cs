using System;
using System.Collections.Generic;
using System.Security;
using System.Text;


namespace laboratorna_2_3_semester
{
    
    class GraduateStudentCollection<TKey>
    {
        public delegate TKey KeySelector<TKey>(GraduateStudent st);//student is lecturer
        public KeySelector<TKey> CalculateKey()
        {

        }
        /*Метод, который используется для вычисления ключа при добавлении элемента
GraduateStudent в коллекцию класса GraduateStudentCollection &lt;TKey&gt;, отвечает делегату
KeySelector&lt;TKey&gt; и передается GraduateStudentCollection &lt;TKey&gt; через параметр
единственного конструктора класса.*/
        public String Name { get; set; }
        private Dictionary<TKey, GraduateStudent> GraduateStudentsDictionaryCollection = new Dictionary<TKey, GraduateStudent>();
        private KeySelector<TKey> theKey;
        GraduateStudentCollection(KeySelector<TKey>)
        {

        }
        public void AddDefaults(int Size)
        {
            int size = 7;
            GraduateStudent[] p = new GraduateStudent[size];
            for (int i = 0; i < size; i++)
            {
                GraduateStudent grd = new GraduateStudent();
                grd.LastName = grd.LastName + i;
                p[i] = grd;
                GraduateStudentsDictionaryCollection.Add(TKey, grd);
            }            
        }
        public void AddGraduateStudent(params GraduateStudent[] )
        {

        }
        public override string ToString()
        {
            string res = "";
            foreach(KeyValuePair <TKey, GraduateStudent> kvp in GraduateStudentsDictionaryCollection)
            {
                res += "Key: " +kvp.Key + "\n" + "Value: " + "\n" + kvp.Value.ToString() + "\n\n\n";
            }
            return res;
        }
        public string ToShortString()
        {
            string res = "";
            foreach (KeyValuePair<TKey, GraduateStudent> kvp in GraduateStudentsDictionaryCollection)
            {
                res += "Key: " + kvp.Key + "\n" + "Value: " + "\n" + kvp.Value.ToShortString() + "\n\n\n";
            }
            return res;
        }
        public bool Remove(GraduateStudent rt)
        {
            foreach (KeyValuePair<TKey, GraduateStudent> kvp in GraduateStudentsDictionaryCollection)
            {
                if(kvp.Value == rt)
                {
                    GraduateStudentsDictionaryCollection.Remove(kvp.Key);
                    return true;
                }
            }
            return false;
        }
        public bool Replace(GraduateStudent gsold, GraduateStudent gsnew)
        {
            foreach (KeyValuePair<TKey, GraduateStudent> kvp in GraduateStudentsDictionaryCollection)
            {
                if (kvp.Value == gsold)
                {
                    
                    GraduateStudentsDictionaryCollection.Remove(kvp.Key);
                    GraduateStudentsDictionaryCollection[kvp.Key] = gsnew;
                    return true;
                }
            }
            return false;
        }
        event GraduateStudentsChangedHandler<TKey> GraduateStudentsChanged;
        ////////////////////////////////////////////////////////////////System.Linq.Enumerable
        int MaxLearningYear 
        { get { return 0; } }
    }
}
/*
 using System;
using System.Collections.Generic;

namespace laboratorna4
{
    class GraduateStudentCollection
    {
        private List<GraduateStudet> ListOfStudents = new List<GraduateStudet>();
        public string nameOfTheCollection { get; set; }
        public delegate void GraduateStudentListHandler(object source, GraduateStudentListHandlerEventArgs args);
        public event GraduateStudentListHandler GraduateStudentAdded;
        public void AddDefaults()
        {
            /*c допомогою якого можна додати деяке число елементів
              * типу GraduateStudent для ініціалізації колекції за замовчуванням; */
/*int sizedef = 7;
GraduateStudet[] p = new GraduateStudet[sizedef];
            for (int i = 0; i<sizedef; i++)
            {
                GraduateStudet grd = new GraduateStudet();
grd.LastName = grd.LastName + i;
                p[i] = grd;
            }
            ListOfStudents.AddRange(p);

        }
        void InsertAt(int j, GraduateStudet gs)
{
    if (ListOfStudents[j] != null)
    {
        ListOfStudents.Insert(j - 1, gs);
        //GraduateStudentAdded.Invoke
    }
    else
    {
        ListOfStudents.Add(gs);
    }
}
public GraduateStudet this[int index]
{
    get
    {
        return ListOfStudents[index];
    }
    set
    {
        ListOfStudents[index] = value;
    }
}
public event GraduateStudentListHandler GraduateStudentAdded;

public void AddGraduateStudents(params GraduateStudet[] p)
{
    ListOfStudents.AddRange(p);
}
public override string ToString()
{
    string res = "";
    foreach (GraduateStudet g in ListOfStudents)
    {
        res += g.ToString();
    }
    return res;
}
public string ToShortString()
{
    string res = "";
    foreach (GraduateStudet g in ListOfStudents)
    {
        res += g.ToShortString();
    }
    return res;
}
public void SortByLastName()
{
    ListOfStudents.Sort();
}
public void SortByBirthday()
{
    ListOfStudents.Sort(new Person());
}
public void SortByLearningYear()
{
    ListOfStudents.Sort(new GraduateStudet.YearComparer());
}
    }
}



 */