using System;

namespace laboratorna_2_3_semester
{
    interface IDateAndCopy
    {
        public abstract object DeepCopy();
        public abstract DateTime Date { get; set; }
    }
}
