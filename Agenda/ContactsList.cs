//22-05-2018 - RaulGogna, V.01 Implemented methods
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
class ContactsList
{
    public List<Contact> Contacts { get; set; }
    public int Count { get; set; }

    public ContactsList()
    {
        Load();
        Count = Contacts.Count;
    }
    public void Add(Contact contactToAdd)
    {
        Contacts.Add(contactToAdd);
        Count++;
    }
    public Contact Get(int index)
    {
        try
        {
            return Contacts[index - 1];
        }
        catch (Exception)
        {
            return null;
        }
    }

    public void Set(int n, Contact contact)
    {
        if (n >= Count || n < 0)
        {
            return;
        }
        else
        {
            Contacts[n] = contact;
            Save();
        }
    }

    public void Delete(int o)
    {
        try
        {
            Contacts.RemoveAt(o);
            Count--;
            Contacts.Sort();
        }
        catch (Exception)
        {
            return;
        }
    }

    public void Save()
    {
        try
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Contacts.dat", FileMode.Create,
                FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, Contacts);
            stream.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        
    }

    public void Load()
    {
        if (File.Exists("Contacts.dat"))
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Contacts.dat", FileMode.Open, 
                    FileAccess.Read, FileShare.Read);
                Contacts = (List<Contact>)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Read fail");
            }
        }
        else
        {
            Contacts = new List<Contact>();
        }
    }
}
