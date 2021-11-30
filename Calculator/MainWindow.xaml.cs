using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        protected string number;
        protected string number1 = "0";
        protected string number2 = "0";
        protected string number3 = "0";
        protected string function;
        protected string function1 = null;
        protected string function2 = null;
        protected string function3 = null;
        protected bool check = true;
        protected bool check1 = false;
        protected bool check2 = false;
        protected bool check3;
        protected bool numCheck = false;
        protected int i = 0;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Num_Click(object sender, RoutedEventArgs e)
        {
            string a;
            string s;
            check3 = false;
            Button button = sender as Button;
            number = button.Content.ToString();  // 현재 입력한 버튼 숫자     
            if (check1 && number1 != "0.")
            {
                number1 = "0";
                check1 = false;
            }
            if (number1 == null)
            {
                number1 = "0";
            }

            if (check2 && number1 != "0" && number1 != "0.")
            {
                number2 = number1;
                number1 = "0";
                check2 = false;
            }


            a = number1.Replace(",", "").Replace(".", "");
            if (a.Length < 16)
            {
                if (result.Text == "0")
                {
                    result.Text = PrintResult(number);
                    number1 = number;
                    function1 = function;
                }

                else if (check == false)
                {
                    result.Text = null;
                    number1 = null;
                    check = true;
                    number1 += number;
                }

                else
                {
                    if (number1 == "0")
                        number1 = number;
                    else
                        number1 += number;

                }

                if (number1.Contains("."))
                {
                    ++i;
                    s = "{0:N" + i + "}";
                    number1 = string.Format(s, double.Parse(number1));
                    result.Text = PrintResult(number1);
                }

                else if (a.Length < 16)
                {
                    number1 = string.Format("{0:N0}", double.Parse(number1));
                    result.Text = PrintResult(number1);
                }

                if (numCheck == true)
                {
                    text.Text = PrintResult(number2) + function; /*+ number1;*/
                }
            }
        }
        private void Negative_Click(object sender, RoutedEventArgs e)
        {
            double n1;
            if (check2)
            {
                n1 = double.Parse(number2) * (-1);
                number2 = n1.ToString();
            }

            else if (text.Text != null && text.Text != "0")
            {
                if (function == null && number1 != "0")
                {
                    n1 = double.Parse(number1) * (-1);
                    number1 = n1.ToString();
                }

                else
                {
                    n1 = double.Parse(number1) * (-1);
                    number1 = n1.ToString();
                }

            }

            if (number2 == "0")
            {
                n1 = double.Parse(number1) * (-1);
                number1 = n1.ToString();
                result.Text = PrintResult(number1);
            }

            else
            {
                result.Text = PrintResult(number1);
                text.Text = PrintResult(number2) + function + PrintResult(number1);
            }
        }

        private void Point_Click(object sender, RoutedEventArgs e)
        {
            if (number1 == null)
            {
                number1 = "0.";
                result.Text = number1;
                i = 0;
            }

            else if (check2)
            {
                number2 = number1;
                number1 = "0.";
                result.Text = number1;
                check1 = false;
                check2 = false;
                i = 0;
            }

            else if (!number1.Contains("."))
            {
                result.Text += ".";
                number1 += ".";
            }



        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (check3)
            {
                number1 = "0";
            }

            if (number1 == "0.")
            {
                number1 = "0";
            }

            if (number1 == "0" && number2 == "0")
            {
                text.Text = "0";
                result.Text = "0";
            }
            else
            {
                check1 = true;
                check2 = true;
                i = 1;
                Function();
                if (check3)
                {
                    number1 = number2;
                    check3 = false;
                }

                function1 = function;
                if (number2 != "0")
                    text.Text = PrintResult(number2) + function + PrintResult(number1) + " = ";
                else
                    text.Text = PrintResult(number3);
                number2 = number3;
            }
        }

        private void Function_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            function = button.Content.ToString();
            i = 0;
            if (number1 == "0.")
            {
                number1 = "0";
            }

            numCheck = true;
            if (check1 && number2 == "0")
            {
                number2 = number1;
                function1 = function;
            }

            else if (check1)
            {
                number1 = number2;
                text.Text = PrintResult(number3) + function;
                function1 = function;
                function2 = function;
                if (check2)
                {
                    number1 = number2;
                    check2 = false;
                }
            }

            else if (function1 != null && number1 != "0" && check == false)
            {
                Function();
                number1 = "0";
                function = function2;
                function1 = function;
                text.Text = number3 + function;
                number2 = number3;
                function2 = null;
                check1 = false;
            }

            else if (number1 == "0" || number1 == null)
            {
                if (text.Text.Contains(" + ") || text.Text.Contains(" - ") || text.Text.Contains(" × ") || text.Text.Contains(" ÷ "))
                {
                    if (function2 == function)
                    {
                        function1 = function;
                        text.Text = PrintResult(number2) + function1;
                    }

                    else
                    {
                        function1 = function;
                        text.Text = PrintResult(number2) + function1;
                    }
                }

                else
                {
                    text.Text = number1 + function;
                }
                check1 = false;
            }

            else
            {
                if (function1 != null)
                {
                    Function();
                    number2 = result.Text;
                    function = function2;
                }

                else
                {
                    number2 = number1;
                }
                if (!text.Text.Contains(" + ") && !text.Text.Contains(" - ") && !text.Text.Contains(" × ") && !text.Text.Contains(" ÷ "))
                {
                    text.Text += function;
                }

                function1 = function;
                function2 = function;
                text.Text = PrintResult(number2) + function1;
                number1 = null;
                check1 = false;
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (i > 1)
            {
                i--;
            }

            if (check2)
            {
                text.Text = "";
            }
            else if (number1 == null)
            {

            }

            else if (number1 != "0" && number1 != "")
            {
                int j = number1.Length - 1;

                if (j == 0)
                    number1 = "0";

                else
                    number1 = number1.Substring(0, j);
                result.Text = number1;
            }

            else
            {
                number1 = "0";
            }

        }

        private void ClearEnty_Click(object sender, RoutedEventArgs e)
        {
            if (function != null && check1 == true)
            {
                number2 = number1;
                text.Text = number2;
                result.Text = number2;
                check3 = true;
            }

            else
            {
                number1 = "0";
                result.Text = number1;
                check3 = true;
            }

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            i = 0;
            number1 = "0";
            number2 = "0";
            number3 = "0";
            text.Text = "0";
            result.Text = "0";
            function = null;
            function1 = null;
            function2 = null;
            numCheck = false;
            check1 = false;
            check2 = false;
        }


        public void Function()
        {
            if (function1 != function)
            {
                function2 = function;
                function = function1;
            }

            else if (check1)
            {
                function2 = function;
                function = function1;
            }

            if (number1 == null && check3 == false)
            {
                number1 = number2;
            }

            double n1 = double.Parse(number2);
            double n = double.Parse(number1);

            switch (function)
            {
                case " + ":
                    n1 += n;
                    number3 = n1.ToString();
                    result.Text = PrintResult(number3);
                    text.Text = PrintResult(number3);
                    function1 = null;
                    break;

                case " - ":
                    n1 -= n;
                    number3 = n1.ToString();
                    result.Text = PrintResult(number3);
                    text.Text = PrintResult(number3);
                    function1 = null;
                    break;

                case " × ":
                    n1 *= n;
                    number3 = n1.ToString();
                    result.Text = PrintResult(number3);
                    text.Text = PrintResult(number3);
                    function1 = null;
                    break;

                case " ÷ ":
                    n1 /= n;
                    number3 = n1.ToString();
                    result.Text = PrintResult(number3);
                    text.Text = PrintResult(number3);
                    function1 = null;
                    break;
            }

            text.Text = result.Text + function3;
        }

        private static string PrintResult(string resultNum)
        {
            int count;
            string a = resultNum.Replace(".", "").Replace(",", "");
            if (a.Length < 17)
            {
                if (resultNum.Contains("."))
                {
                    count = resultNum.Length - resultNum.IndexOf('.');

                    if (count == 1)
                        return resultNum;

                    string resultNum1 = "{0:N" + (count - 1) + "}";
                    resultNum = string.Format(resultNum1, double.Parse(resultNum));
                }
                else
                    resultNum = string.Format("{0:N0}", double.Parse(resultNum));
            }

            else if (a.Length < 19)
            {
                resultNum = string.Format("{0:N0}", double.Parse(resultNum));
            }

            return resultNum;
        }
    }
}
