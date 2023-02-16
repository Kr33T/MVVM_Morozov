using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Navigation;
using System.Windows.Input;
using System.Collections;
using System;

namespace MVVM_Morozov
{
    internal class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> operCB_fill
        {
            get
            {
                return Model.operCB_Text;
            }
        }

        public int operCB_index
        {
            get
            {
                return Model.operCB_SelectedIndex;
            }
            set
            {
                Model.operCB_SelectedIndex = value;
                PropertyChanged(this, new PropertyChangedEventArgs("operSignTB_set"));
            }
        }

        public string operSignTB_set
        {
            get
            {
                return Model.operSignTB_Text[Model.operCB_SelectedIndex];
            }
        }

        public string firstTB
        {
            get
            {
                return Model.firstTB;
            }
            set
            {
                Model.firstTB = value;
            }
        }

        public string secondTB
        {
            get
            {
                return Model.secondTB;
            }
            set
            {
                Model.secondTB = value;
            }
        }

        public string resultTB
        {
            get
            {
                return Model.resultTB.ToString();
            }
            set
            {
                Model.resultTB = value;
            }
        }

        public RoutedCommand Command { get; set; } = new RoutedCommand();

        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                double first = Convert.ToDouble(Model.firstTB);
                double second = Convert.ToDouble(Model.secondTB);

                switch (Model.operCB_SelectedIndex)
                {
                    case 0:
                        Model.resultTB = (first + second).ToString();
                        break;
                    case 1:
                        Model.resultTB = (first - second).ToString();
                        break;
                    case 2:
                        Model.resultTB = (first * second).ToString();
                        break;
                    case 3:
                        if (second == 0)
                        {
                            Model.resultTB = "Деление на ноль невозможно";
                        }
                        else
                        {
                            Model.resultTB = (first / second).ToString();
                        }
                        break;
                }
            }
            catch
            {
                Model.resultTB = "Проверьте корректность введенных данных";
            }
            PropertyChanged(this, new PropertyChangedEventArgs("resultTB"));
        }

        public CommandBinding binding;

        public ViewModel()
        {
            binding = new CommandBinding(Command);
            binding.Executed += Command_Executed;
        }
    }
}
