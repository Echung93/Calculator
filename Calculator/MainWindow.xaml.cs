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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        string number;
        string number1;
        string number2;
        string function;
        string function1 = null;
        double n;
        double n1;
        double resultNum;
        bool check = true;


        public MainWindow()
        {
            InitializeComponent();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Num_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            function1 = null;
            number = button.Content.ToString();  // 현재 입력한 버튼 숫자          
            if (text.Text == "0")
            {
                text.Text = number;
                number1 = number;
            }

            else if (check == false)
            {
                text.Text = null;
                number1 = null;
                text.Text += number;
                check = true;
                number1 += number;
            }

            else
            {
                text.Text += number;
                number1 += number;
            }

            n = double.Parse(number1);
            if (number1.Length < 16 && number1.Contains("."))
            {
                text.Text = string.Format("{0:N0}", n);
            }

            else if(number1.Length < 16)
            {
                text.Text = string.Format("{0:N0}", n);
            }
            else
                text.Text = n.ToString();


        }
        private void Negative_Click(object sender, RoutedEventArgs e)
        {
            if (text.Text != null && text.Text != "")
            {
                n1 = double.Parse(text.Text) * (-1);
                text.Text = n1.ToString();
                number2 = text.Text;
            }
        }

        private void Point_Click(object sender, RoutedEventArgs e)
        {
            if (!text.Text.Contains("."))
            {
                text.Text += ".";
                number1 += ".";
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            check = false;
            if (number2 =="")
            {
                number2 = "0";
            }

            if (function1 == null)
            {
                switch (function)
                {
                    case " + ":
                        if (number1 == null)
                        {
                            n = double.Parse(number2);
                            n1 = double.Parse(number2);
                            resultNum = n1 + n;
                        }

                        else
                        {

                            n = double.Parse(number1);
                            n1 = double.Parse(number2);
                            resultNum = n1 + n;
                        }

                        number2 = resultNum.ToString();
                        //text.Text = string.Format("{0:N0}", resultNum);
                        if (number2.Length < 16)
                        {
                            text.Text = string.Format("{0:N0}", resultNum);
                        }
                        else
                            text.Text = number2;
                        function1 = function;

                        break;

                    case " - ":
                        if (number1 == null)
                        {
                            n = double.Parse(number2);
                            n1 = double.Parse(number2);
                            resultNum = n1 - n;
                        }

                        else
                        {
                            n = double.Parse(number1);
                            if (number2 == "")
                            {
                                n1 = 0;
                            }

                            else
                            {
                                n1 = double.Parse(number2);
                            }
                            resultNum = n1 - n;
                        }

                        number2 = resultNum.ToString();
                        if (number2.Length < 16)
                        {
                            text.Text = string.Format("{0:N0}", resultNum);
                        }
                        else
                            text.Text = number2;
                        function1 = function;
                        break;

                    case " × ":
                        if (number1 == null)
                        {
                            n = double.Parse(number2);
                            n1 = double.Parse(number2);
                            resultNum = n1 * n;
                        }

                        else
                        {
                            n = double.Parse(number1);
                            n1 = double.Parse(number2);
                            resultNum = n1 * n;
                        }

                        number2 = resultNum.ToString();
                        if (number2.Length < 16)
                        {
                            text.Text = string.Format("{0:N0}", resultNum);
                        }
                        else
                            text.Text = number2;
                        function1 = function;
                        break;

                    case " ÷ ":
                        if (number1 == null)
                        {
                            n = double.Parse(number2);
                            n1 = double.Parse(number2);
                            resultNum = n1 / n;
                        }

                        else
                        {
                            n = double.Parse(number1);
                            n1 = double.Parse(number2);
                            resultNum = n1 / n;
                        }

                        number2 = resultNum.ToString();
                        if (number2.Length < 16)
                        {
                            text.Text = string.Format("{0:N0}", resultNum);
                        }
                        else
                            text.Text = number2;
                        function1 = function;
                        break;
                }
            }

            else
            {
                string check = text.Text.Replace(",", "");
                switch (function)
                {
                    case " + ":
                        if (number2 == check)
                        {
                            n1 = double.Parse(number2);
                            n1 += n;
                            number2 = n1.ToString();
                        }
                        //text.Text = string.Format("{0:N0}", int.Parse(number2));
                        if (number2.Length < 16)
                        {
                            text.Text = string.Format("{0:N0}", double.Parse(number2));
                        }
                        else
                            text.Text = number2;
                        break;

                    case " - ":
                        if (number2 == check)
                        {
                            n1 = double.Parse(number2);
                            n1 -= n;
                            number2 = n1.ToString();
                        }
                        if (number2.Length < 16)
                        {
                            text.Text = string.Format("{0:N0}", double.Parse(number2));
                        }
                        else
                            text.Text = number2;
                        break;

                    case " × ":
                        if (number2 == check)
                        {
                            n1 = double.Parse(number2);
                            n1 *= n;
                            number2 = n1.ToString();
                        }
                        if (number2.Length < 16)
                        {
                            text.Text = string.Format("{0:N0}", double.Parse(number2));
                        }
                        else
                            text.Text = number2;
                        break;

                    case " ÷ ":
                        if (number2 == check)
                        {
                            n1 = double.Parse(number2);
                            n1 /= n;
                            number2 = n1.ToString();
                        }
                        if (number2.Length < 16)
                        {
                            text.Text = string.Format("{0:N0}", double.Parse(number2));
                        }
                        else
                            text.Text = number2;
                        break;
                }
            }


        }

        private void Function_Click(object sender, RoutedEventArgs e)
        {
            if (text.Text.Contains(" X ") || text.Text.Contains(" ÷ ") || text.Text.Contains(" - ") || text.Text.Contains(" + "))
            {

            }
            else
            {
                number1 = text.Text;
                Button button = sender as Button;
                function = button.Content.ToString();
                if (function1 == null)
                {
                    text.Text += function;
                    number2 = number1;
                }

                else
                {
                    n = double.Parse(number2);
                    function1 = function;
                    text.Text += function;
                }

                number1 = null;
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (text.Text.Length == 0)
            {

            }
            else
            {
                if (function == null && number1 == null)
                {
                }

                else if(function == null)
                {
                    number1 = number1.Substring(0, (number1.Length - 1));
                    text.Text = number1;
                    number2 = text.Text;
                }

                else 
                {
                    number1 = text.Text.Substring(0, (text.Text.Length - 1));
                    text.Text = number1;
                    number2 = text.Text;
                    function1 = null;
                }
            }
        }

        private void Per_Click(object sender, RoutedEventArgs e)
        {
            if (number1 != null)
            {
                n1 = double.Parse(number1) / 100;
                number2 = n1.ToString();
                text.Text = number2;
                number1 = null;
            }

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            number = "0";
            number1 = "0";
            number2 = "0";
            text.Text = "";
            function = null;
            function1 = null;
            n = 0;
            n1 = 0;
            resultNum = 0;

        }
    }
}
