using KontaktBok.DataLayer2;
using KontaktBok.Model_Layer;
using KontaktBok.Presenter_Layer;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace KontaktBok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainView
    {
        #region Interface implementation (IMainView)
        public Contacts SelectedContact { get; set; }
        public string searchValue
        {
            get { return txtSearch.Text; }
        }

        public string homePhone
        {
            get
            {
                return txtHomePhone.Text;
            }
        }

        public string workPhone
        {
            get
            {
                return txtWorkPhone.Text;
            }
        }

        public string mobilePhone
        {
            get
            {
                return txtMobilePhone.Text;
            }
        }

        public string homeAddress
        {
            get
            {
                return txtHomeAddress.Text;
            }
        }

        public string workAddress
        {
            get
            {
                return txtWorkPhone.Text;
            }
        }

        public string otherAddress
        {
            get
            {
                return txtOtherAddress.Text;
            }
        }

        public string newHomePhone
        {
            get
            {
                return txtHomePhoneAdd.Text;
            }
        }

        public string newWorkPhone
        {
            get
            {
                return txtWorkPhoneAdd.Text;
            }
        }

        public string newMobilePhone
        {
            get
            {
                return txtMobilePhoneAdd.Text;
            }
        }

        public string newHomeAddress
        {
            get
            {
                return txtHomeAddressAdd.Text;
            }
        }

        public string newWorkAddress
        {
            get
            {
                return txtWorkAddressAdd.Text;
            }
        }

        public string newOtherAddress
        {
            get
            {
                return txtOtherAddressAdd.Text;
            }
        }

        public string newFirstName
        {
            get
            {
                return txtFirstNameAdd.Text;
            }
        }

        public string newLastName
        {
            get
            {
                return txtLastNameAdd.Text;
            }
        }

        #region Interface Design Impl.
        public Brush txtFirstNameBorderBrush
        {
            get
            {
                return txtFirstNameAdd.BorderBrush;
            }
            set
            {
                txtFirstNameAdd.BorderBrush = value;
                if (value == Brushes.Red)
                {
                    txtFirstNameAdd.BorderThickness = new Thickness(4);
                    errorLabelVisibility = Visibility.Visible;
                }
                else if (value == Brushes.Green)
                {
                    errorLabelVisibility = Visibility.Hidden;
                }
                else
                {
                    txtFirstNameAdd.BorderThickness = new Thickness(1);
                    errorLabelVisibility = Visibility.Hidden;
                }
            }
        }
        public Brush txtLastNameBorderBrush
        {
            get
            {
                return txtLastNameAdd.BorderBrush;
            }
            set
            {
                txtLastNameAdd.BorderBrush = value;
                if (value == Brushes.Red)
                {
                    txtLastNameAdd.BorderThickness = new Thickness(4);
                    errorLabelVisibility = Visibility.Visible;
                }
                else if (value == Brushes.Green)
                {
                    errorLabelVisibility = Visibility.Hidden;
                }
                else
                {
                    txtLastNameAdd.BorderThickness = new Thickness(1);
                    errorLabelVisibility = Visibility.Hidden;
                }
            }
        }
        public Visibility errorLabelVisibility
        {
            get
            {
                return ErrorLabel.Visibility;
            }
            set
            {
                ErrorLabel.Visibility = value;
            }
        }
        #endregion

        #endregion

        private IModel m;
        public MainWindow()
        {
            InitializeComponent();
            var p = new Presenter();
            this.lbContacts.ItemsSource = p.GetContacts();
            m = new Model(this);
            this.MinWidth = 460;
        }

        public void UpdateListView()
        {
            var p = new Presenter();
            this.lbContacts.ItemsSource = p.GetContacts();
        }

        private void GotoDetails(object sender, MouseButtonEventArgs e)
        {
            var element = sender as FrameworkElement;
            var contact = element.DataContext as Contacts;

            if (contact == null)
                return;

            SelectionManager.SelectedContact = contact;
            if (SelectionManager.SelectedContact != null)
            {
                SelectedContact = SelectionManager.SelectedContact;
            }
            this.DataContext = SelectedContact;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ChangeBrushes(Brushes.WhiteSmoke, Brushes.Gray, Visibility.Visible, true);
            btnEdit.Visibility = Visibility.Hidden;
        }

        private void btnConfirmEdit_Click(object sender, RoutedEventArgs e)
        {
            ChangeBrushes(Brushes.Transparent, Brushes.Transparent, Visibility.Hidden, false);
            btnEdit.Visibility = Visibility.Visible;
            m.EditContact();
        }

        private void btnCancelEdit_Click(object sender, RoutedEventArgs e)
        {
            ChangeBrushes(Brushes.Transparent, Brushes.Transparent, Visibility.Hidden, false);
            btnEdit.Visibility = Visibility.Visible;
        }

        public void ChangeBrushes(Brush txtBrush, Brush borderBrush, Visibility visible, bool _boolValue)
        {
            btnConfirmEdit.Visibility = visible;
            btnCancelEdit.Visibility = visible;

            txtFullName.Focusable = _boolValue;
            txtFullName.Background = txtBrush;
            txtFullName.BorderBrush = borderBrush;

            txtMobilePhone.Focusable = _boolValue;
            txtMobilePhone.Background = txtBrush;
            txtMobilePhone.BorderBrush = borderBrush;

            txtWorkPhone.Focusable = _boolValue;
            txtWorkPhone.Background = txtBrush;
            txtWorkPhone.BorderBrush = borderBrush;

            txtHomePhone.Focusable = _boolValue;
            txtHomePhone.Background = txtBrush;
            txtHomePhone.BorderBrush = borderBrush;

            txtHomeAddress.Focusable = _boolValue;
            txtHomeAddress.Background = txtBrush;
            txtHomeAddress.BorderBrush = borderBrush;

            txtWorkAddress.Focusable = _boolValue;
            txtWorkAddress.Background = txtBrush;
            txtWorkAddress.BorderBrush = borderBrush;

            txtOtherAddress.Focusable = _boolValue;
            txtOtherAddress.Background = txtBrush;
            txtOtherAddress.BorderBrush = borderBrush;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbShowAddView", uccGrid);
        }

        private void ShowHideMenu(string Storyboard, StackPanel pnl)
        {
            Storyboard sb = Resources[Storyboard] as Storyboard;
            sb.Begin(pnl);

            if (Storyboard == "sbShowAddView")
            {
                btnDeleteContact.Visibility = Visibility.Hidden;
                                
                BrushConverter bc = new BrushConverter();
                Brush brush = (Brush)bc.ConvertFrom("#72777D");
                brush.Freeze(); scrollViewer.Background = brush;

                mainGrid.Background = brush;
            }
            else if (Storyboard == "sbHideAddView")
            {
                btnDeleteContact.Visibility = Visibility.Visible;

                BrushConverter bc = new BrushConverter();
                Brush brush = (Brush)bc.ConvertFrom("#007ACC");
                brush.Freeze(); scrollViewer.Background = brush;

                mainGrid.Background = brush;
            }
        }

        private void HidePanel_Add()
        {
            ShowHideMenu("sbHideAddView", uccGrid);
        }

        private void btnCancelAdd_Click(object sender, RoutedEventArgs e)
        {
            HidePanel_Add();
            ClearTextBoxes();
        }

        private void btnConfirmAdd_Click(object sender, RoutedEventArgs e)
        {
            if (newFirstName != "".Trim() && newLastName != "".Trim())
            {
                txtLastNameBorderBrush = Brushes.LightGray;
                txtFirstNameBorderBrush = Brushes.LightGray;

                HidePanel_Add();
                m.AddContact();
            }
            else
            {
                txtFirstNameBorderBrush = Brushes.Red;
                txtLastNameBorderBrush = Brushes.Red;
            }
        }

        public void ClearTextBoxes()
        {
            txtFirstNameAdd.Text = "";
            txtLastNameAdd.Text = "";

            txtHomePhoneAdd.Text = "";
            txtWorkPhoneAdd.Text = "";
            txtMobilePhoneAdd.Text = "";

            txtHomeAddressAdd.Text = "";
            txtWorkAddressAdd.Text = "";
            txtOtherAddressAdd.Text = "";

            txtFirstNameBorderBrush = Brushes.LightGray;
            txtLastNameBorderBrush = Brushes.LightGray;
        }

        private void txtFirstNameAdd_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((newFirstName != "" && newLastName != "") || (newFirstName != "" && newLastName == ""))
            {
                txtFirstNameBorderBrush = Brushes.Green;
                txtLastNameBorderBrush = Brushes.LightGray;
            }
            else
            {
                txtLastNameBorderBrush = Brushes.Red;
                txtFirstNameBorderBrush = Brushes.Red;
            }
        }

        private void txtLastNameAdd_TextChanged(object sender, TextChangedEventArgs e)
        {

            if ((newLastName != "" && newFirstName != "") || (newLastName != "" && newFirstName == ""))
            {
                txtLastNameBorderBrush = Brushes.Green;
                txtFirstNameBorderBrush = Brushes.LightGray;
            }
            else
            {
                txtLastNameBorderBrush = Brushes.Red;
                txtFirstNameBorderBrush = Brushes.Red;
            }
        }

        private void btnDeleteContact_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Är du säker på att ta bort kontakten?", "Varning!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
                m.DeleteContact();
            else
            {
                return;
            }
            lbContacts.SelectedIndex = 0;

        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text != "".Trim())
            {
                try
                {
                    this.lbContacts.ItemsSource = m.SearchResult;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                UpdateListView();
        }
    }
}
