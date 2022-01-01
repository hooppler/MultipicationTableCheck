using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

using TablicaMnozenjaApp.Model;

namespace TablicaMnozenjaApp.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MarkDialogBox : Window
    {
        public MarkDialogBox(AppModel appModel, TestDataModel test)
        {
            InitializeComponent();
            this.txtMark.Text = "Tvoja ocena je: " + test.TestMark.ToString();
            //this.txtCorrectVsUncorrect.Text = string.Format("Od ukupno {0} primera bilo je {1} tačnih i {2} netačnih odgovora.", test.NumberOfExcersises, appModel.GetCorrectNo(test), test.NumberOfExcersises - appModel.GetCorrectNo(test));
            this.txtCorrect.Text = string.Format("Tačni odgovori: {0}", appModel.GetCorrectNo(test));
            this.txtIncorrect.Text = string.Format("Netačni odgovori: {0}", test.NumberOfExcersises - appModel.GetCorrectNo(test));
            this.txtTotal.Text = string.Format("Ukupan broj testova: {0}", test.NumberOfExcersises);
        }
    }
}
