//18-05-2018 - RaulGogna, V.01 Implemented methods
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

class TasksList
{
    public List<Task> Tasks { get; set; }
    public int Count { get; set; }

    public TasksList()
    {
        Load();
        Count = Tasks.Count;
    }
    public void Add(Task taskToAdd)
    {
        Tasks.Add(taskToAdd);
        Count++;
    }
    public Task Get(int index)
    {
        try
        {
            return Tasks[index - 1];
        }
        catch (Exception)
        {
            return null;
        }
    }

    public void Set(int n, Task task)
    {
        if (n >= Tasks.Count || n < 0)
        {
            return;
        }
        else
        {
            Tasks[n - 1] = task;
            Save();
        }
    }

    public void Delete(int o)
    {
        try
        {
            Tasks.RemoveAt(o);
            Count--;
            Tasks.Sort();
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
            Stream stream = new FileStream("Tasks.dat", FileMode.Create, 
                FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, Tasks);
            stream.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Write fail ERROR: " + e.Message);
        }
    }

    public void Load()
    {
        if (File.Exists("Tasks.dat"))
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Tasks.dat", FileMode.Open, 
                    FileAccess.Read, FileShare.Read);
                Tasks = (List<Task>)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Read fail");
            }
        }
        else
        {
            Tasks = new List<Task>();
        }
    }

}
