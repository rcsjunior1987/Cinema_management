using System;
using System.Collections;
using System.Collections.Generic;

/*
    This class is a linear data structure in which the insertion and deletion of elements occur at one end only,
      rather than in the middle.
*/
public class Stack<T>
{ 
    private T[] vStack;
    int top;
    public T[] VStack { get => vStack; set => vStack = value; }
    public int Top { get => top; set => top = value; }

    public Stack()
    {
       this.Top = 0;
       this.vStack = new T[0];
    }

    public virtual void Push(T obj)
    {
        Array.Resize<T>(ref this.vStack, top+1);

        this.VStack[Top] = obj;
        ++this.Top;
   }

   public virtual T Pop()
   {
       T RemovedElement;

       if(Top > 0)
       {
             RemovedElement = VStack[--Top];

             Array.Resize<T>(ref this.vStack, Top);
             return RemovedElement;
       }
       return default(T);
   }

   public T PeepTop()
   {
        T topElement = default(T);

        if(Top > 0)
            topElement = VStack[Top-1];

       return topElement;
   }

    public override bool Equals(object obj)
    {
        return obj is Stack<T> stack &&
               Top == stack.Top;
    }

    public override string ToString()
    {
        string elements = "\n Movies from most recently inserted \n";

        for(int i = top-1; i >=0; i--) {
            elements += "   " + this.VStack[i].ToString().PadRight(15) + "\n";
        }

        return elements;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

}