using System;
using System.Collections.Generic;
using System.Text;

namespace laboratorna_2_3_semester
{
    class TeamsJournalEntry
    {
        public string nameOfCollection { get; set; }
        public Revision typeOfEvent { get; set; }
        public string causedByProperty { get; set; }
        public int YearOfStudy { get; set; }
        public TeamsJournalEntry(string name, Revision tof, string cbp, int year)
        {
            nameOfCollection = name;
            typeOfEvent = tof;
            causedByProperty = cbp;
            YearOfStudy = year;
        }
        public override string ToString()
        {
            return ($"\n Name of the collection: {nameOfCollection} \n Type of changes: {typeOfEvent }\n Property thst caused change: {causedByProperty}\n" +
                $"Year of study : {YearOfStudy}\n");
        }
    }
}
