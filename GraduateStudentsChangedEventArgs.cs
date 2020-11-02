using System;
using System.Collections.Generic;
using System.Text;

namespace laboratorna_2_3_semester
{
    class GraduateStudentsChangedEventArgs<TKey> 
    {
        public string nameOfCollection { get; set; }
        public Revision CalledBy { get; set; }
        public string PropertyChangedName { get; set; }
        public int YearOfStudy { get; set; }
        public GraduateStudentsChangedEventArgs(string name, Revision cb, string pcn, int year)
        {
            nameOfCollection = name;
            CalledBy = cb;
            PropertyChangedName = pcn;
            YearOfStudy = year;
        }
        public override  string ToString()
        {
            return ($"\n Name of the collection: {nameOfCollection} \n Revision {CalledBy }\n Type of changes: {PropertyChangedName}\n" +
                $"Year of study : {YearOfStudy}\n");
        }
    }
}
