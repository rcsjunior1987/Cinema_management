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

   public T[] GetAllStackElements()
   {
        T[] Elements = new T[Top];

        Array.Copy(VStack, 0, Elements, 0, Top);

        return Elements;
   }

    public override bool Equals(object obj)
    {
        return obj is Stack<T> stack &&
               Top == stack.Top;
    }

    public override string ToString()
    {
        return base.ToString();
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public int GetRandomCode(int minValues, int maxValues)
    {
        Random rd = new Random();
        return rd.Next(minValues, maxValues);
    }

}