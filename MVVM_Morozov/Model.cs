using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MVVM_Morozov
{
    internal class Model
    {
        public static string firstTB;
        public static string secondTB;

        public static List<string> operCB_Text = new List<string>() { "Сложение", "Вычитание", "Умножение", "Деление" };
        public static List<string> operSignTB_Text = new List<string>() { "+", "-", "*", "/" };

        public static int operCB_SelectedIndex = 0;
        public static string resultTB = "";
    }
}
