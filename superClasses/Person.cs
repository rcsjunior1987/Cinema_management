using System;

/*
    Class Person is extended by IComparable,
      which allows items to be stored in a LinkedList.
        Each Person has a unique GUID to ensure there is no
          collision for people sharing the same name.
*/
 
public class Person : IComparable
{
    /* Name of Person */
    private string name;
    public string Name { get => name; set => name = value; } 

    /* GUID attribute */
    private Guid id;
    public Guid Id { get => id; set => id = value; }

    public Person() { }

    public Person(string name)
    {
        this.name = name;
        this.id = Guid.NewGuid();
    }

    /* Returns the string with the object attributes */
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

        // A Person is ordered by its name
        return this.Name.ToUpper().CompareTo(otherCustomer.Name.ToUpper());
    }
    
}