using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Threading;
using System.Configuration;

using TablicaMnozenjaApp.SpeechEngine;
using TablicaMnozenjaApp.Model;
using TablicaMnozenjaApp.Views;

namespace TablicaMnozenjaApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private SpeechEng spe = new SpeechEng();
        private NumberGeneratorModel ngm = new NumberGeneratorModel();
        private DispatcherTimer timer = new DispatcherTimer();

        private AppModel appModel = new AppModel();
        private TestDataModel test = null;
        private ExcersiseDataModel prevExcersise = null;
        private bool flag = false;
        private int excersisesNo;
        private int timeIntervalBetweenTests;

        public MainWindowViewModel()
        {
            GetConfigurationValues();
            BtnColor = "Gray";
            BtnContent = "START";
            timer.Interval = TimeSpan.FromSeconds(timeIntervalBetweenTests);
            timer.Tick += OnTimerTick;
            timer.Stop();
        }

        private ICommand buttonClickCommand;

        private string result;
        private string btnColor;
        private string btnContent;

        public ICommand ButtonClickCommand
        {
            get { return buttonClickCommand ?? (buttonClickCommand = new RelayCommand(param => ButtonClickCommandExecute(param))); }
        }

        public string Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
                OnPropertyChanged("Result");
            }
        }

        public string BtnColor
        {
            get
            {
                return btnColor;
            }
            set
            {
                btnColor = value;
                OnPropertyChanged("BtnColor");
            }
        }

        public string BtnContent
        {
            get
            {
                return btnContent;
            }
            set
            {
                btnContent = value;
                OnPropertyChanged("BtnContent");
            }
        }

        private void ButtonClickCommandExecute(object param)
        {
            if (!flag)
            {
                BtnColor = "Red";
                BtnContent = "STOP";
                this.test = appModel.CreateTest(excersisesNo);
                PlayTest();
                timer.Start();
                flag = true;
            }
            else
            {
                BtnColor = "Gray";
                BtnContent = "START";
                MessageBox.Show("Test je prekinut!", "Test info");
                timer.Stop();
                flag = false;
            }

        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            PlayTest();
        }

        private void PlayTest()
        {
            if (prevExcersise != null)
            {
                if (Result != "")
                {
                    prevExcersise.Result = int.Parse(Result);
                }
                else
                {
                    prevExcersise.Result = 0;
                }

            }
            Result = "";

            if (appModel.IsExcersisesExceededGiven(this.test))
            {
                ExcersiseDataModel excersise = appModel.NewExcersise(this.test);
                spe.OpenFile(excersise.x, excersise.y);
                spe.Play();
                this.prevExcersise = excersise;
            }
            else
            {
                timer.Stop();
                int mark = appModel.CalculateMark(this.test);
                test.TestMark = mark;

                MarkDialogBox markDialog = new MarkDialogBox(this.appModel, this.test);
                markDialog.ShowDialog();
                BtnColor = "Gray";
                BtnContent = "START";
            }
        }

        private void GetConfigurationValues()
        {
            excersisesNo = int.Parse(ConfigurationManager.AppSettings["ExcersisesNo"]);
            timeIntervalBetweenTests = int.Parse(ConfigurationManager.AppSettings["TimeIntervalBetweenTests"]);
        }
    }
}
