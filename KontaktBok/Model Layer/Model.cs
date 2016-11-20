using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KontaktBok.DataLayer2;
using KontaktBok.Presenter_Layer;
using System.Windows;
using System.Windows.Media;
using System.Data.SqlClient;

namespace KontaktBok.Model_Layer
{
    public class Model : IModel
    {
        private IMainView v;

        public Model(IMainView _view)
        {
            v = _view;
        }

        public void AddContact()
        {
            ContactBookDBDModel db = new ContactBookDBDModel();

            Contacts contact = new Contacts();

            contact.FirstName = v.newFirstName;
            contact.LastName = v.newLastName;
            contact.HomePhone = v.newHomePhone;
            contact.WorkPhone = v.newWorkPhone;
            contact.MobilePhone = v.newMobilePhone;
            contact.HomeAddress = v.newHomeAddress;
            contact.WorkPhone = v.newWorkAddress;
            contact.OtherAddress = v.newOtherAddress;
            db.Contacts.Add(contact);
            db.SaveChanges();
            v.UpdateListView();
        }

        public void DeleteContact()
        {
            try
            {
                ContactBookDBDModel db = new ContactBookDBDModel();

                Contacts contact = new Contacts();
                contact.ContactID = v.SelectedContact.ContactID;
                var t = Task.Factory.StartNew(() => db.Contacts.Attach(contact));
                t.Wait();
                var t1 = Task.Factory.StartNew(() => db.Contacts.Remove(contact));
                t1.Wait();
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Något gick fel, kunde inte ta bort kontakten. " + ex.Message, "Felmeddelande");
            }
            v.UpdateListView();
        }

        public void EditContact()
        {
            try
            {
                ContactBookDBDModel db = new ContactBookDBDModel();

                if (v.SelectedContact.ContactID <= 0) return;
                var t = Task<Contacts>.Factory.StartNew(() =>
                {
                    return (from emp in db.Contacts
                            where emp.ContactID == v.SelectedContact.ContactID
                            select emp).Single();
                });

                t.Wait();
                t.Result.HomePhone = v.homePhone;
                t.Result.WorkPhone = v.workPhone;
                t.Result.MobilePhone = v.mobilePhone;

                t.Result.HomeAddress = v.homeAddress;
                t.Result.WorkAddress = v.workAddress;
                t.Result.OtherAddress = v.otherAddress;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            v.ClearTextBoxes();
        }

        public List<Contacts> SearchResult
        {
            get
            {
                using (var db = new ContactBookDBDModel())
                {
                    try
                    {
                        SqlParameter p = new SqlParameter("@UserInput", v.searchValue);
                        List<Contacts> result = db.Contacts.SqlQuery("SearchContactsSP @UserInput", p).ToList();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                        return null;
                    }
                }
            }
        }
    }
    public interface IModel
    {
        void EditContact();
        void AddContact();
        void DeleteContact();
        List<Contacts> SearchResult { get; }
    }
}
