// 22/05/2018 - RaulGogna, V.01 created constructor, and Properties
using System;

[Serializable]
class Contact : IComparable
{
    // Attributes

    public string Name { get; set; }

    public string Email { get; set; }

    public int Age { get; set; }

    public int Telephone { get; set; }

    public string Address { get; set; }

    public string Country { get; set; }

    public string Observations { get; set; }

    public Contact(string name, string email, int age, int telephone, 
        string adress, string country, string observations)
    {
        Name = name;
        Email = email;
        Age = age;
        Telephone = telephone;
        Address = adress;
        Country = country;
        Observations = observations;
    }

    public Contact()
    {

    }

    public int CompareTo(Object c2)
    {
        return (Name).CompareTo(
            ((Contact)c2).Name);
    }
}
