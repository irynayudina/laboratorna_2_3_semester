using System;
using System.Collections.Generic;
using System.Text;

namespace laboratorna_2_3_semester
{
    class TeamsJournal
    {
        public List<TeamsJournalEntry> ListOfChanges = new List<TeamsJournalEntry>();
        public void GraduateStudentsChangedHandler(object src, GraduateStudentsChangedEventArgs<string> args)
        {
            ListOfChanges.Add(new TeamsJournalEntry(args.nameOfCollection, args.CalledBy, args.PropertyChangedName, args.YearOfStudy));
        }
        public override string ToString()
        {
            string res = "";
            foreach(var v in ListOfChanges)
            {
                res += v + "\n";
            }
            return res;
        }
    }
}
