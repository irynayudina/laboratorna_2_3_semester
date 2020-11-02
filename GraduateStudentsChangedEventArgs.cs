using System;
using System.Collections.Generic;
using System.Text;

namespace laboratorna_2_3_semester
{
    class GraduateStudentsChangedEventArgs<TKey> 
    {
        public string nameOfCollectionOfOccuredEvent { get; set; }
        public string typeOfChangesInTheCollection { get; set; }
        public int numberOfElementThatWasChangedOrAdded { get; set; }
        public GraduateStudentListHandlerEventArgs()
        {
            nameOfCollectionOfOccuredEvent = "default";
            typeOfChangesInTheCollection = "default";
            numberOfElementThatWasChangedOrAdded = 0;
        }
        public GraduateStudentListHandlerEventArgs(string name, string type, int number)
        {
            nameOfCollectionOfOccuredEvent = name;
            typeOfChangesInTheCollection = type;
            numberOfElementThatWasChangedOrAdded = number;
        }
        override public string ToString()
        {
            return ($"\n Name of the collection: {nameOfCollectionOfOccuredEvent}\n Type of changes: {typeOfChangesInTheCollection}\n" +
                $" Number of the element that was changed or added: {numberOfElementThatWasChangedOrAdded}\n");
        }
    }
}
