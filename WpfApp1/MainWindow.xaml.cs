using System;
using System.Windows;
using System.Windows.Controls;

namespace CalculatorApp
{
    public partial class MainWindow : Window
    {
        private string currentOperator;
        private double firstOperand;
        private bool isNewCalculation;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (isNewCalculation)
            {
                ResultTextBox.Text = "";
                isNewCalculation = false;
            }

            Button button = (Button)sender;
            ResultTextBox.Text += button.Content.ToString();
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string newOperator = button.Content.ToString();

            if (double.TryParse(ResultTextBox.Text, out double result))
            {
                if (currentOperator != null)
                {
                    double secondOperand = result;
                    switch (currentOperator)
                    {
                        case "+":
                            result = firstOperand + secondOperand;
                            break;
                        case "-":
                            result = firstOperand - secondOperand;
                            break;
                        case "*":
                            result = firstOperand * secondOperand;
                            break;
                        case "/":
                            if (secondOperand != 0)
                            {
                                result = firstOperand / secondOperand;
                            }
                            else
                            {
                                MessageBox.Show("Cannot divide by zero!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            break;
                    }
                }

                firstOperand = result;
                ResultTextBox.Text = result.ToString();
                isNewCalculation = true;
                currentOperator = newOperator;
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultTextBox.Text, out double secondOperand))
            {
                if (currentOperator != null)
                {
                    switch (currentOperator)
                    {
                        case "+":
                            secondOperand = firstOperand + secondOperand;
                            break;
                        case "-":
                            secondOperand = firstOperand - secondOperand;
                            break;
                        case "*":
                            secondOperand = firstOperand * secondOperand;
                            break;
                        case "/":
                            if (secondOperand != 0)
                            {
                                secondOperand = firstOperand / secondOperand;
                            }
                            else
                            {
                                MessageBox.Show("Cannot divide by zero!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            break;
                    }

                    ResultTextBox.Text = secondOperand.ToString();
                    isNewCalculation = true;
                    currentOperator = null;
                }
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Text = "";
            currentOperator = null;
            firstOperand = 0;
            isNewCalculation = false;
        }
    }
}