//28-05-2018 - RaulGogna, V.02 Implemented method of save files
//22-05-2018 - RaulGogna, V.01 Implemented methods
using System;
using System.Collections.Generic;
using System.IO;
class ContactsList
{
    public List<Contact> Contacts { get; set; }
    public int Count { get; set; }

    public ContactsList()
    {
        Contacts = new List<Contact>();
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
            StreamWriter contactsOutput = new StreamWriter("Contacts.dat");
            foreach (Contact c in Contacts)
            {
                contactsOutput.WriteLine("Contacts:" + c.Name + ";" + c.Email
                    + ";" + c.Age + ";" + c.Telephone + ";" + c.Address +
                    ";" + c.Country + ";" + c.Observations + ";\n");
            }
            contactsOutput.Close();
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("Error: path too long");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: file not found");
        }
        catch (IOException e)
        {
            Console.WriteLine("I/O Error: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }

    public void Load()
    {
        try
        {
            StreamReader contactsInput = new StreamReader("Contacts.dat");
            string line = "";
            string[] contacts;
            do
            {
                line = contactsInput.ReadLine();
                if (line != null)
                {
                    line = line.Substring(line.IndexOf(":") + 1);
                    contacts = line.Split(';');
                    Add(new Contact(
                        contacts[0], contacts[1],
                        Convert.ToInt32(contacts[2]),
                        contacts[3], contacts[4],
                        contacts[5], contacts[6]));
                    line = contactsInput.ReadLine();
                }
            } while (line != null);
            contactsInput.Close();
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("Error: path too long");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: file not found");
        }
        catch (IOException e)
        {
            Console.WriteLine("I/O Error: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}
