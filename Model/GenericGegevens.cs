using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class GenericGegevens<T> where T : iHelikopterview
    {
        private List<iHelikopterview> _list = new List<iHelikopterview>();
        public void FillList(T t)
        {
            t.Add(_list);
        }

        public string ListCheck()
        { 
            if (_list.Count == 0)
            {
                return " ";
            }
            else
            {
                return _list[0].BesteDeelnemer(_list);
            }
        }

        public List<iHelikopterview> GetData()
        {
            return _list;
        }
    }
}
