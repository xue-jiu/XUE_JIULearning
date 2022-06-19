using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] _data;
        int currentIndex;

        public MyList(int length)
        {
            this._data = new T[length];
            currentIndex = 0;
        }

        public void Add(T obj)
        {
            _data[currentIndex] = obj;
            //currentIndex = currentIndex + 1;
            currentIndex++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(_data);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
