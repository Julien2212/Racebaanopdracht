using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class GenericGegevens<T> where T : iHelikopterview
    {
        private List<T> _list = new List<T>();
        public void FillList(T t)
        {
            _list.Add(t);
        }
    }
}
