﻿namespace HelloWord
{
    public class Nullable<T> where T : struct
    {
        public Nullable() { }

        private object _value;

        public Nullable(T value)
        {
            _value = value;
        }

        public bool HasValue
        {
            get
            {
                return _value != null;
            }
        }

        public T GetValueOrDefault()
        {
            if (HasValue)
            {
                return (T)_value;
            }
            return default(T);
        }
    }
}

