//2 23/05/2018 - RaulGogna, V.01 Functions save and load and get, set of properties
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


class GlobalListNotes
{
    public List<NotesList> GlobalList { get; set; }
    public int Count { get; set; }
    public GlobalListNotes()
    {
        Load();
        Count = GlobalList.Count;
    }

    public void Add(NotesList notesToAdd)
    {
        GlobalList.Add(notesToAdd);
        Count++;
    }

    public NotesList Get(int index)
    {
        try
        {
            return GlobalList[index - 1];
        }
        catch (Exception)
        {
            return null;
        }
    }

    public void Set(int n, NotesList listNotes)
    {
        if (n >= Count || n < 0)
        {
            return;
        }
        else
        {
            GlobalList[n] = listNotes;
            Save();
        }
    }
    public void Save()
    {
        try
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("GlobalNotes.dat", FileMode.Create,
                FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, GlobalList);
            stream.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
    public void Load()
    {
        if (File.Exists("GlobalNotes.dat"))
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("GlobalNotes.dat", FileMode.Open,
                    FileAccess.Read, FileShare.Read);
                GlobalList = (List<NotesList>)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Read fail");
            }
        }
        else
        {
            GlobalList = new List<NotesList>();
        }
    }
}
