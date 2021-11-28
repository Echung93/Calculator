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
        string number1 = "0";
        string number2;
        string function;
        string function1 = null;
        string function2;
        double n;
        double n1;
        double resultNum;
        bool check = true;
        bool check1 = false;
        bool check2;
        string s ;
        int i = 0;


        public MainWindow()
        {
            InitializeComponent();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Num_Click(object sender, RoutedEventArgs e)
        {
            check2 = false;
            check1 = false;
            Button button = sender as Button;
            //function1 = null;
            number = button.Content.ToString();  // 현재 입력한 버튼 숫자          
            if (number1.Length < 17)
            {
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

                //if (number1.Length < 17 && number1.Contains("."))
                //{
                //    text.Text = string.Format("{0:N0}", n);
                //}
                if (number1.Contains("."))
                {
                    ++i;   
                    s = "{0:N"+ i + "}";
                    text.Text = string.Format(s, double.Parse(number1));
                    number1 = text.Text;
                }

                else if (number1.Length < 17)
                {
                    text.Text = string.Format("{0:N0}", double.Parse(number1));
                    number1 = text.Text;
                }

                
                //else
                //{
                //    n = long.Parse(number1);
                //    text.Text = n.ToString();
                //    number1 = text.Text;
                //}
            }

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
            i = 1;
            Function();       
        }

        private void Function_Click(object sender, RoutedEventArgs e)
        {
            i = 1;
            check1 = false;
            Button button = sender as Button;
            function = button.Content.ToString();
            if (function2 == function && number2 != null && number1 != "0")
            {
                Function();
                number1 = "0";
            }

            else if (function2 != null)
            {
                Function();
                number1 = "0";
            }

            else if (text.Text.Contains(" × ") || text.Text.Contains(" ÷ ") || text.Text.Contains(" - ") || text.Text.Contains(" + "))
            {
                if ((function1 == button.Content.ToString()) && (number1 != "0"))
                {
                    Function();
                }

                else
                {
                    number1 = text.Text.Substring(0, (text.Text.Length - 3));
                    text.Text = number1 + function;                   
                }

                number2 = number1;
                number1 = "0";
            }

            else
            {
                number1 = text.Text;               
                if (function1 == null)
                {
                    text.Text += function;
                    number2 = number1;
                    n = double.Parse(number2);
                }

                else
                {
                    n = double.Parse(number2);
                    function1 = function;
                    text.Text += function;
                }
                number1 = "0";
            }

            function2 = function;
            
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {   
            if (i > 1)
            {
                i--;
            }
            
            if (text.Text.Length == 0)
            {

            }

            else if (check1 == true)
            {
                number2 = null;
                text.Text = number2;
            }

            else
            {
                if (function == null && number1 == null)
                {
                }

                else if (function == null)
                {
                    number1 = number1.Substring(0, (number1.Length - 1));
                    text.Text = number1;
                    number2 = text.Text;
                }

                else
                {
                    if (number1 == null)
                    {
                        number1 = text.Text.Substring(0, (text.Text.Length - 3));
                        text.Text = number1;
                        function = null;
                        function1 = null;
                    }
                    else
                    {
                        number1 = number1.Substring(0, (number1.Length - 1));
                        text.Text = number1;
                    }
                }
            }
        }

        private void ClearEnty_Click(object sender, RoutedEventArgs e)
        {
            
            if (function != null && check1 == true)
            {
                number2 = number1;
                number1 = "0";
                text.Text = number1;
                check2 = true;
            }

            else
            {
                number1 = "0";
                number2 = "0";                
                text.Text = number1;
            }

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            i = 1;
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

        public void Function()
        {
            check = false;
            check1 = true;

            if (check2 == true)
            {
                number2 = "0";
            }

            if (function1 == null)
            {
                switch (function)
                {
                    case " + ":
                        if (number1 == "0")
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
                        if (number2.Length < 17 && !number2.Contains("E"))
                        {
                            //text.Text = string.Format("{0:N5}", resultNum);
                            if (s == null)
                                text.Text = string.Format("{0:N0}", resultNum);
                            else
                                text.Text = string.Format(s, resultNum);
                        }
                        else
                            text.Text = number2;
                        function1 = function;

                        break;

                    case " - ":
                        if (number1 == "0")
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
                        if (number2.Length < 17 && !number2.Contains("E"))
                        {
                            if (s == null)
                                text.Text = string.Format("{0:N0}", resultNum);
                            else
                                text.Text = string.Format(s, resultNum);
                        }
                        else
                            text.Text = number2;
                        function1 = function;
                        break;

                    case " × ":
                        if (number1 == "0")
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
                        if (number2.Length < 17 && !number2.Contains("E"))
                        {
                            if (s == null)
                                text.Text = string.Format("{0:N0}", resultNum);
                            else
                                text.Text = string.Format(s, resultNum);
                        }
                        else
                            text.Text = number2;
                        function1 = function;
                        break;

                    case " ÷ ":
                        if (number1 == "0")
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
                        if (number2.Length < 17 && !number2.Contains("E"))
                        {
                            if (s == null)
                                text.Text = string.Format("{0:N0}", resultNum);
                            else
                                text.Text = string.Format(s, resultNum);
                            //text.Text = string.Format(s, resultNum);
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

                        else
                        {
                            n1 = double.Parse(number2);
                            n1 += double.Parse(check);
                            number2 = n1.ToString();
                        }
                        //text.Text = string.Format("{0:N0}", int.Parse(number2));
                        if (number2.Length < 17 && !number2.Contains("E"))
                        {
                            if (s == null)
                             text.Text = string.Format("{0:N0}", double.Parse(number2));
                            else
                            text.Text = string.Format(s, double.Parse(number2));
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

                        else
                        {
                            n1 = double.Parse(number2);
                            n1 -= double.Parse(check);
                            number2 = n1.ToString();
                        }

                        if (number2.Length < 17 && !number2.Contains("E"))
                        {
                            if (s == null)
                                text.Text = string.Format("{0:N0}", double.Parse(number2));
                            else
                                text.Text = string.Format(s, double.Parse(number2));
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

                        else
                        {
                            n1 = double.Parse(number2);
                            n1 *= double.Parse(check);
                            number2 = n1.ToString();
                        }


                        if (number2.Length < 17 && !number2.Contains("E"))
                        {
                            if (s == null)
                                text.Text = string.Format("{0:N0}", double.Parse(number2));
                            else
                                text.Text = string.Format(s, double.Parse(number2));
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

                        else
                        {
                            n1 = double.Parse(number2);
                            n1 /= double.Parse(check);
                            number2 = n1.ToString();
                        }

                        if (number2.Length < 17 && !number2.Contains("E"))
                        {
                            if (s == null)
                                text.Text = string.Format("{0:N0}", double.Parse(number2));
                            else
                                text.Text = string.Format(s, double.Parse(number2));
                        }
                        else
                            text.Text = number2;
                        break;
                }
            }

            function2 = null;
        }
    }
}
