//23/05/2018 - RaulGogna, V.01 Implemented Constructor, and Properties
using System;
[Serializable]
class Note : IComparable
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Confidential { get; set; }
    public bool Done { get; set; }

    public Note(string title,string description, string category,
        string confidential, bool done)
    {
        Title = title;
        Description = description;
        Category = category;
        Confidential = confidential;
        Done = done;
    }

    public Note()
    {

    }

    public int CompareTo(Object n2)
    {
        return (Title).CompareTo(((Note)n2).Title);
    }
}
