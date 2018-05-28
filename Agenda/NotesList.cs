// 23/05/2018 - RaulGogna, V.01 Implemented methods,constructors,and properties
// 24/05/2018 - RaulGogna, V.02 Improve some functions
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

class NotesList
{
    public List<Note> Notes { get; set; }
    public int NumPages { get; set; }
    public int Count { get; set; }

    public NotesList()
    {
        Notes = new List<Note>();
        Load();
        Count = Notes.Count;
    }
    public void Add(Note noteToAdd)
    {
        Notes.Add(noteToAdd);
        Count++;
        NumPages = Count;
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
            Save();
        }
    }
    public void Delete(int o)
    {
        try
        {
            Notes.RemoveAt(o);
            Count--;
        }
        catch (Exception)
        {
            return;
        }
    }
    public void Load()
    {
        if (File.Exists("Notes.dat"))
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Notes.dat", FileMode.Open,
                    FileAccess.Read, FileShare.Read);
                Notes = (List<Note>)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        else
        {
            Console.WriteLine("Not file found");
        }
    }
    public void Save()
    {
        try
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Notes.dat", FileMode.Create,
                FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, Notes);
            stream.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}
