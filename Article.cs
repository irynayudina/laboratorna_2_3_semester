﻿using System;

namespace laboratorna_2_3_semester
{
    class Article : IDateAndCopy
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }
        public Article(string name, string place, DateTime date)
        {
            Name = name;
            Place = place;
            Date = date;
        }
        public Article()
        {
            Name = "Basics of OOP";
            Place = "DNU";
            Date = new DateTime(2019, 03, 20);
        }
        public override string ToString()
        {
            return ($"\n Name of the article: {Name}\n" +
                $" Date of publishing: {Date}\n" +
                $" Place of publishing: {Place}");
        }
        public virtual object DeepCopy()
        {
            Article a = (Article)this.MemberwiseClone();
            a.Name = new string(Name); //String.Copy(Name);
            a.Place = new string(Place); //String.Copy(Place);
            a.Date = new DateTime(Date.Year, Date.Month, Date.Day);
            return a;
        }
    }
}
