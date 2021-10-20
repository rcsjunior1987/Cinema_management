using System;
using System.Collections;
using System.Collections.Generic;

public class GenericStack<T> : Stack<T>
    {
        public GenericStack() : base() { }

        public override void Push(T obj)
        { 
            base.Push(obj);
        }

        public override T Pop()
        {
            return base.Pop();
        }


    }