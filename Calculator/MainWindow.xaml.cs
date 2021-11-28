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


        public MainWindow()
        {
            InitializeComponent();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void num_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            function1 = null;
            number = button.Content.ToString();  // 현재 입력한 버튼 숫자          
            if (text.Text == "0")
            {
                text.Text = number;
            }

            else
            {
                text.Text += number;
                number1 += number;
            }

            if (number1 == "\0")
            {
                if (number1.Contains("."))
                {
                    n = double.Parse(number1);
                }

                else
                {
                    n = double.Parse(text.Text);
                    text.Text = string.Format("{0:N0}", n);
                }
            }

        }
        private void negative_Click(object sender, RoutedEventArgs e)
        {
            if (text.Text != null)
            {
                n1 = double.Parse(text.Text) * (-1);
                text.Text = n1.ToString();
                number1 = text.Text;
            }
        }

        private void point_Click(object sender, RoutedEventArgs e)
        {
            if (!text.Text.Contains("."))
                text.Text += ".";
        }

        private void equals_Click(object sender, RoutedEventArgs e)
        {
            if (function1 == null)
            {
                switch (function)
                {
                    case "+":
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
                        text.Text = resultNum.ToString();
                        function1 = "+";
                        break;

                    case "-":
                        if (number1 == null)
                        {
                            n = double.Parse(number2);
                            n1 = double.Parse(number2);
                            resultNum = n1 - n;
                        }

                        else
                        {
                            n = double.Parse(number1);
                            n1 = double.Parse(number2);
                            resultNum = n1 - n;
                        }

                        number2 = resultNum.ToString();
                        text.Text = resultNum.ToString();
                        function1 = "-";
                        break;

                    case "×":
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
                        text.Text = resultNum.ToString();
                        function1 = "×";
                        break;

                    case "÷":
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
                        text.Text = resultNum.ToString();
                        function1 = "÷";
                        break;
                }
            }

            else
            {
                switch (function)
                {
                    case "+":
                        if (number2 == text.Text)
                        {
                            n1 = double.Parse(number2);
                            n1 += n;
                            number2 = n1.ToString();
                        }
                        text.Text = number2;
                        break;

                    case "-":
                        if (number2 == text.Text)
                        {
                            n1 = double.Parse(number2);
                            n1 -= n;
                            number2 = n1.ToString();
                        }
                        text.Text = number2;
                        break;

                    case "×":
                        if (number2 == text.Text)
                        {
                            n1 = double.Parse(number2);
                            n1 *= n;
                            number2 = n1.ToString();
                        }
                        text.Text = number2;
                        break;

                    case "÷":
                        if (number2 == text.Text)
                        {
                            n1 = double.Parse(number2);
                            n1 /= n;
                            number2 = n1.ToString();
                        }
                        text.Text = number2;
                        break;
                }
            }


        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            function = "+";
            if (function1 == null)
            {
                number2 = text.Text;
                text.Text += "+";
            }

            else
            {
                n = double.Parse(number2);
                function1 = "+";
                text.Text += "+";
            }

            number1 = null;
        }

        private void subtract_Click(object sender, RoutedEventArgs e)
        {
            function = "-";
            if (function1 == null)
            {
                number2 = text.Text;
                text.Text += "-";
            }

            else
            {
                n = double.Parse(number2);
                function1 = "-";
                text.Text += "-";
            }

            number1 = null;
        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            function = "×";
            if (function1 == null)
            {
                number2 = text.Text;
                text.Text += "*";
            }

            else
            {
                n = double.Parse(number2);
                text.Text += "*";
                function1 = "×";
            }

            number1 = null;
        }

        private void dividing_Click(object sender, RoutedEventArgs e)
        {
            function = "÷";

            if (function1 == null)
            {
                number2 = text.Text;
                text.Text += "÷";
            }

            else
            {
                n = double.Parse(number2);
                text.Text += "÷";
                function1 = "÷";
            }

            number1 = null;
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            if (text.Text.Length == 0)
            {

            }
            else
            {
                text.Text = text.Text.Substring(0, (text.Text.Length - 1));
                if(number1 != null)
                    number1 = number1.Substring(0, (number1.Length - 1));
            }
        }

        private void per_Click(object sender, RoutedEventArgs e)
        {
            if (number1 != null)
            {
                n1 = double.Parse(number1) / 100;
                number2 = n1.ToString();
                text.Text = number2;
                number1 = null;
            }

        }

        private void reset_Click(object sender, RoutedEventArgs e)
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
