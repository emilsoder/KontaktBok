using System;
using System.Linq;
using System.Collections.Generic;
using KontaktBok.DataLayer2;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace KontaktBok
{
    public interface IMainView
    {
        Contacts SelectedContact { get; set; }
        string homePhone { get; }
        string workPhone { get; }
        string mobilePhone { get; }

        string homeAddress { get; }
        string workAddress { get; }
        string otherAddress { get; }

        string newFirstName { get; }
        string newLastName { get; }
        string newHomePhone { get; }
        string newWorkPhone { get; }
        string newMobilePhone { get; }

        string newHomeAddress { get; }
        string newWorkAddress { get; }
        string newOtherAddress { get; }

        Brush txtFirstNameBorderBrush { get; set; }
        Brush txtLastNameBorderBrush { get; set; }
        Visibility errorLabelVisibility { get; set; }

        void UpdateListView();
        void ClearTextBoxes();

        string searchValue { get; }
    }
}