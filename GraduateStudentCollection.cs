using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;

namespace laboratorna_2_3_semester
{
    
    class GraduateStudentCollection<TKey> //: IEnumerable
    {
        public delegate TKey KeySelector<TKey>(GraduateStudent st);
        public delegate void GraduateStudentsChangedHandler<TKey>(object sender, GraduateStudentsChangedEventArgs<TKey> args);

        public event GraduateStudentsChangedHandler<TKey> GraduateStudentsChanged;

        public String Name { get; set; }
        private Dictionary<TKey, GraduateStudent> GraduateStudentsDictionaryCollection = new Dictionary<TKey, GraduateStudent>();
        private KeySelector<TKey> theKey;
        public GraduateStudentCollection(KeySelector<TKey> t)
        {
            theKey = t;
            GraduateStudentsDictionaryCollection = new Dictionary<TKey, GraduateStudent>();
        }
        public void AddDefaults(int size)
        {
            for (int i = 0; i < size; i++)
            {
                GraduateStudent grd = new GraduateStudent();
                grd.LastName = grd.LastName + i;
                TKey k = theKey(grd);
                GraduateStudentsDictionaryCollection.Add(k, grd);
            }
        }
        public void AddGraduateStudent(params GraduateStudent[] p)
        {
            if(theKey== null){
                throw new Exception("Исключение вызвано нулевым  ключем");
            }
            else
            {
                foreach(var v in p)
                {
                    GraduateStudentsDictionaryCollection.Add(theKey(v), v);
                    v.PropertyChanged += GraduateStudentPropertyChanged;
                }
            }
        }
        public override string ToString()
        {
            string res = "";
            foreach (KeyValuePair<TKey, GraduateStudent> kvp in GraduateStudentsDictionaryCollection)
            {
                res += "Key: " + kvp.Key + "\n" + "Value: " + "\n" + kvp.Value.ToString() + "\n\n\n";
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
            if (GraduateStudentsDictionaryCollection.ContainsValue(rt))
            {
                foreach (KeyValuePair<TKey, GraduateStudent> kvp in GraduateStudentsDictionaryCollection)
                {
                    if (kvp.Value == rt)
                    {
                        kvp.Value.PropertyChanged -= GraduateStudentPropertyChanged;
                        GraduateStudentsDictionaryCollection.Remove(kvp.Key);
                        GraduateStudentsChanged?.Invoke(kvp.Value, new GraduateStudentsChangedEventArgs<TKey>(Name, Revision.Remove, "", kvp.Value.LearningYear));
                        return true;
                    }
                }
            }                
            return false;
        }
        public bool Replace(GraduateStudent gsold, GraduateStudent gsnew)
        {
            if (GraduateStudentsDictionaryCollection.ContainsValue(gsold))
            {
                foreach (KeyValuePair<TKey, GraduateStudent> kvp in GraduateStudentsDictionaryCollection)
                {
                    if (kvp.Value == gsold)
                    {
                        kvp.Value.PropertyChanged -= GraduateStudentPropertyChanged;
                        GraduateStudentsDictionaryCollection.Remove(kvp.Key);
                        GraduateStudentsDictionaryCollection.Add(theKey(gsnew), gsnew);
                        GraduateStudentsChanged?.Invoke(kvp.Value, new GraduateStudentsChangedEventArgs<TKey>(Name, Revision.Replace, "", kvp.Value.LearningYear));
                        return true;
                    }
                }
            }
                
            return false;
        }
        public void GraduateStudentPropertyChanged(object obj, PropertyChangedEventArgs ar)
        {
            GraduateStudentsChanged?.Invoke(obj, new GraduateStudentsChangedEventArgs<TKey>(Name, Revision.Property, ar.PropertyName, (obj as GraduateStudent).LearningYear));
        }

        public int MaxLearningYear
        {
            get
            {
                if(GraduateStudentsDictionaryCollection.Count == 0) { return 0; }
                return GraduateStudentsDictionaryCollection.Values.Max(GraduateStudent => GraduateStudent.LearningYear);
            }
        }
        public IEnumerable<KeyValuePair<TKey, GraduateStudent>> TuitionForm(FormOfStudy value)
        {
            return GraduateStudentsDictionaryCollection.Where(el => el.Value.Form == value);
        }
        public IEnumerable<IGrouping<FormOfStudy, KeyValuePair<TKey,GraduateStudent>>> Grouped 
        {
            get 
            {
                return GraduateStudentsDictionaryCollection.GroupBy(el => el.Value.Form);
            }
        }
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