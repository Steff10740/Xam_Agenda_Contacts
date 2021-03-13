using System;
using System.Collections.Generic;
using System.Text;

namespace _17pts.Models
{
   public class Contacts
    {
        public Contacts(string name, string telefono)
        {
            Name = name;
            Telefono = telefono;
        }

        public string Name { get; }
        public string Telefono { get; }
        public string Title => Name;
        public string Detail => Telefono;
    }
}
