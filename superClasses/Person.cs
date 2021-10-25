using System;

/*
    Class Person is extended by IComparable,
      which allows items to be stored in a SortedLinkedList.
        Each Person has a unique GUID to ensure there is no
          collision for people sharing the same name.
*/
 
public class Person : IComparable
{
    private string name;
    private Guid id;
    public string Name { get => name; set => name = value; } 
    public Guid Id { get => id; set => id = value; }

    public Person() { }

    public Person(string name)
    {
        this.name = name;
        this.id = Guid.NewGuid();
    }

    public override string ToString() {
        return " ID: " + this.Id
             + ", Name: " + this.Name;
    }

    public override bool Equals(object other)
    {
        if (other.GetType() == this.GetType())
        {
            var otherPerson = other as Person;
            return otherPerson.id == this.id;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public int CompareTo(object other)
    {
        if (other == null)
            return 1;

        var otherCustomer = other as Customer;

        // A Person is ordered based on last name first, then first name
        return this.Name.ToUpper().CompareTo(otherCustomer.Name.ToUpper());
    }
    
}