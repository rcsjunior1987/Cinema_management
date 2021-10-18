using System;
using System.Collections;
using System.Collections.Generic;

public class RepairBikesStack : GenericStack<Bike>
{
    public RepairBikesStack() : base() { }

    public override string ToString()
    {
        string returnString = "";

        foreach (Bike bike in this.VStack)
        {
            returnString += bike.ToString().PadRight(15) + "\n";
        }

        return returnString;
    }

}