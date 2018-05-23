// 23/05/2018 - RaulGogna, V.01 Implemented methods,constructors,and properties
using System;
using System.Collections.Generic;

[Serializable]
class NotesList : IComparable
{
    public List<Note> Notes { get; set; }
    public GlobalListNotes Global = new GlobalListNotes();
    public string Title { get; set; }
    public int Count { get; set; }

    public NotesList()
    {
        Global.Load();
        Notes = new List<Note>();
        Count = Notes.Count;
    }
    public void Add(Note noteToAdd)
    {
        Notes.Add(noteToAdd);
        Title = noteToAdd.Title;
        Count++;
    }

    public Note Get(int index)
    {
        try
        {
            return Notes[index - 1];
        }
        catch (Exception)
        {
            return null;
        }
    }

    public void Set(int n, Note note)
    {
        if (n >= Count || n < 0)
        {
            return;
        }
        else
        {
            Notes[n] = note;
            Global.Save();
        }
    }

    public int CompareTo(Object n2)
    {
        return (String.Compare(Title, ((NotesList)n2).Title, true));
    }
}
