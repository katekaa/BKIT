using FigureCollections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FigureCollections
{
    class SimpleStack<T>: SimpleList<T> where T : IComparable
    {
        
        public void Push(T element) {            
           this.Add(element);
        }
        
        public T Pop() {
            T res = default(T);
            if (this.Count == 1)
            {
                res = this.first.data;
                this.first = null;
                this.last = null;
                this.Count--;
            }
            else if (this.Count > 1)
            {
                res = this.last.data;
                this.last = this.GetItem(this.Count - 2);
                this.Count--;
            }
            return res;
            }
        public T Peek() {
            if (this.last == null) return default(T);
            return this.last.data;
        }

        }
}

    

