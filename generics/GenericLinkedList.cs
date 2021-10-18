using System;
using System.Collections;
using System.Collections.Generic;

/*
    It is a generic implimentation of a sorted LinkedList class.
     It is extended from IComparable. That is, any object that can be
       compared to another with the CompareTo() method, which is used
        to compare elements to be able to sort them.
*/    

public class GenericList<T> : LinkedList<T> where T : IComparable
    {
        public GenericList() : base() {}

        public override void Add(T obj)
        {
            base.Add(obj);
        }

        public void InsertSort(T obj)
        {
            base.Add(obj);
        }

        public virtual void Remove(T obj)
        {
            this.current = base.Find(obj);
            base.Remove();
        }

    }