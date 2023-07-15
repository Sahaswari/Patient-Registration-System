using Patient_Registration_System.Model;
using Patient_Registration_System.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Patient_Registration_System.View
{
    /// <summary>
    /// Interaction logic for TestsWindow.xaml
    /// </summary>
    public partial class TestsWindow : UserControl
    {
        public ObservableCollection<Test> tests;
        private Test testselectedItem;
        private int testId;
        public TestsWindow()
        {
            InitializeComponent();
            tests = new ObservableCollection<Test>(TestData.GetTestFromDB());
            lstvtest.ItemsSource = tests;
            testselectedItem = null;
        }

        private void btntestadd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbtestid.Text) || string.IsNullOrEmpty(txbtestname.Text) ||
                string.IsNullOrEmpty(txbtestchargingrate.Text))
            {
                MessageBox.Show("Please fill all the fields.");
                return;
            }
            Test test = new Test
            {
                TestId = int.Parse(txbtestid.Text),
                TestName = txbtestname.Text,
                TestChargingRate = double.Parse(txbtestchargingrate.Text)

            };

            System.Windows.MessageBox.Show("Succesfully Added.");

            txbtestid.Text = null;
            txbtestname.Text = null;
            txbtestchargingrate.Text = null;

            tests.Add(test);
            lstvtest.ItemsSource = tests;

            TestData.AddTestToDB(test);
        }

        private void lstvtest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            testselectedItem = (Test)lstvtest.SelectedItem;
        }

        private void testedit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please Follow the Below Steps.\n  1) Please Update the Data.\n  2) Then Select Data Again. \n  3) Then Press Update Button.");
            Button? b = sender as Button;

            Test? test = b?.CommandParameter as Test;

            txbtestid.Text = test?.TestId.ToString();
            txbtestname.Text = test?.TestName;
            txbtestchargingrate.Text = test?.TestChargingRate.ToString();

            testId = test.TestId;
        }

        private void btntestupdate_Click(object sender, RoutedEventArgs e)
        {
            if (testselectedItem != null)
            {
                TestData.UpdateTestToDB(testId, txbtestname.Text, txbtestchargingrate.Text);

                System.Windows.MessageBox.Show("DataBase Is Succesfully Updated. Later Data Will Show.");
                txbtestid.Text = null;
                txbtestname.Text = null;
                txbtestchargingrate.Text = null;

                lstvtest.ItemsSource = tests;
            }

            else
            {
                MessageBox.Show("Please Select Data.");
            }
        }

        private void btntestdelete_Click(object sender, RoutedEventArgs e)
        {
            if (testselectedItem != null)
            {
                TestData.DeleteTestFromDB(testselectedItem.TestId);
                System.Windows.MessageBox.Show("Your Selected Data is Deleted Successfully. Later Data Will Show.");
            }
            else
            {
                MessageBox.Show("Please Select Data.");
            }
        }

       
    }
}
