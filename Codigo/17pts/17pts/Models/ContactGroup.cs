using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace _17pts.Models
{
   public class ContactGroupCollection : ObservableCollection<Contacts>
    {
        public ContactGroupCollection(string key)
        {
            Key = key;
        }
        public string Key { get; }
    }
}
