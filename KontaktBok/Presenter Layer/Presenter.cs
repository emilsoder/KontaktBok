using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KontaktBok.DataLayer2;
using System.ComponentModel;

namespace KontaktBok.Presenter_Layer
{
    public class Presenter
    {
        public IList<Contacts> _contacts;

        public Presenter()
        {
            GetData();
        }

        public IEnumerable<Contacts> GetContacts()
        {
            return _contacts;
        }

        private void GetData()
        {
            var db = new ContactBookDBDModel();
            var result = from c in db.Contacts
                         select c;

            List<Contacts> lista = result.ToList();

            _contacts = lista;
        }
    }
}