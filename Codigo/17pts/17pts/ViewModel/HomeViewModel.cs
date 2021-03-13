using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using _17pts.Models;
using Xamarin.Forms;

namespace _17pts.ViewModels
{
    public class HomeViewModel
    {
        public ObservableCollection<ContactGroupCollection> Contacts { get; }

        public ICommand DeleteCommand { get; }
        public ICommand AddCommand { get; }
        private ICommand SelectedContactsCommand { get; }
        private Contacts _contacts;


        public Contacts SelectedContacts 
        {
            get
            {
                return _contacts;
            }
            set
            {
                _contacts = value;
                if (_contacts != null)
                {
                    SelectedContactsCommand.Execute(_contacts);
                }
            }
        }
       

        public HomeViewModel()
        {
            AddCommand = new Command(OnAddContacts);
            DeleteCommand = new Command<Contacts>(OnDeleteContacts);

            Contacts = new ObservableCollection<ContactGroupCollection>()
            {
                new ContactGroupCollection("Favorito")
                {
                new Contacts ("Maria Pi","809232323"),
                new Contacts("Charlin Agramonte","809232323")
                },

                new ContactGroupCollection("Normales")
                {
                new Contacts("Jose Guzman","809738390")
                }
            };

            SelectedContactsCommand = new Command<Contacts>(OnContactsSelected);
        }

        private void OnDeleteContacts(Contacts contacts)
        {
            var ContactGroup = Contacts.FirstOrDefault(p => p.Contains(contacts));
            if (ContactGroup != null)
            {
                ContactGroup.Remove(contacts);
            }
        }

        private void OnAddContacts()
        {
            Contacts.Add(new ContactGroupCollection ("Normales")
            {
                new Contacts ("Gabriella", "809454545")
            });    
        }

        private async void OnContactsSelected(Contacts contacts)
        {
            await App.Current.MainPage.DisplayAlert("Contacto", contacts.Name, "Ok");
        }
    }
}
