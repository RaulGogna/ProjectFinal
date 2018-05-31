//18/05/2018 - RaulGogna, V.01 Implemented constructor
using System;
[Serializable]
class Task : IComparable
{
    public string Description { get; set; }
    public string DateStart { get; set; }
    public string DateDue { get; set; }
    public string Category { get; set; }
    public int Priority { get; set; }
    public bool Confidential { get; set; }

    public Task(string description, string dateStart, string dateDue, 
        string category, int priority, bool confidential)
    {
        Description = description;
        DateStart = dateStart;
        DateDue = dateDue;
        Category = category;
        Priority = priority;
        Confidential = confidential;
    }
    public Task()
    {

    }

    public int CompareTo(Object t2)
    {
        return (Priority).CompareTo(
            ((Task)t2).Priority);
    }
}
