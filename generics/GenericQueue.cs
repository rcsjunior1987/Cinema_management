using System;
using System.Collections;
using System.Collections.Generic;

public class GenericQueue<T> : Queue<T>
    {
        public GenericQueue() : base() { }

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
            base.Remove();
        }

        public override T GetHeadElement()
        {
            return base.GetHeadElement();
        }

    }