using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private bool shouldAddValueToListAndText = true;
        private bool isOperatorPerforemed = false;
        private string lastValueInText = string.Empty;
        private List<string> lsSymbols = new List<string>() { "+", "-", "*", "/" };
        private List<string> lsValues = new List<string> ();
        private Regex textHasOnlyZeros = new Regex(@"^0+$"); 
        public Calculator()
        {
            InitializeComponent();
        }

        private void Button_click(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (ctrlText.Text == "0" || isOperatorPerforemed) // ctrlText.Text == "." || 
            {
                ctrlText.Clear();
            }

            Helper helper = new Helper();

            switch (button.Text.ToString())
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":

                    Numbers numbers = new Numbers(button.Text.ToString());
                    
                    ctrlText.Text += numbers.AddButtonValueToText();

                    isOperatorPerforemed = false;

                    break;

                case "+":
                case "/":
                case "-":
                case "*":

                    OperationSymbols symbols = new OperationSymbols(button.Text.ToString());

                    ctrlText.Text = symbols.AddButtonValueToText();

                    isOperatorPerforemed = true;

                    shouldAddValueToListAndText = symbols.ValidateOperationNotAddSymbolAfterDot(ctrlOperation.Text, lsSymbols);
                    shouldAddValueToListAndText = symbols.ValidateOperationNotAddSymbolAfterSymbol(lsValues, lsSymbols);

                    break;

                case "0":

                    break;

                case ".":

                    break;


                default:
                    break;
            }


            if (lsSymbols.Contains(button.Text))    
            {
                //ctrlText.Text = button.Text;
                //isOperatorPerforemed = true;
                //shouldAddValueToListAndText = true;
            }
            else
            {
                //ctrlText.Text += button.Text;
                //isOperatorPerforemed = false;
                //shouldAddValueToListAndText = true;
            }

            // TODO: Not add dot after symbol, but if it is 0. then add
            //string text = ctrlOperation.Text;
            
            lastValueInText = helper.GetlastValueFromOperationText(ctrlOperation.Text); //!string.IsNullOrEmpty(text) ? text[text.Length - 1].ToString(): null;

            if (button.Text == ".")
            {
                shouldAddValueToListAndText = !lsSymbols.Contains(lastValueInText);
            }

            if (button.Text == "0")
            {
                shouldAddValueToListAndText = textHasOnlyZeros.IsMatch(ctrlText.Text);
            }

            //if (lsSymbols.Contains(button.Text) && lastValueInText == ".")
            //{
            //    shouldAddValueToListAndText = false;
            //}

            // DONE not to add operation after operation
            if (lsValues.Count > 0)
            {
                if (button.Text == "." && button.Text == lsValues.Last()) //(lsSymbols.Contains(button.Text) && lsSymbols.Contains(lsValues.Last())
                {
                    shouldAddValueToListAndText = false;
                }
            }

            if (shouldAddValueToListAndText)
            {
                ctrlOperation.Text += button.Text;
                lsValues.Add(button.Text);
            }


        }

        // TODO: check if C or CE bt should delete the ctrl operationText and/or just the ctrlText
        private void CEButton_click(object sender, EventArgs e)
        {
            ctrlText.Text = "0";
        }

        private void CButton_click(object sender, EventArgs e)
        {
            ctrlText.Text = "0";
        }

        private void EqualButton_click(object sender, EventArgs e)
        {
            //TODO: 

        }

        // Good thinking, deploy
        //public void method2()
        //{
        //    List<string> inputList = new List<string> { "5", "5", "*", "4", "-", "2" };
        //    int index = 0;
        //    int operand1 = 0;
        //    int operand2 = 0;
        //    string operation = "";
        //    while (index < inputList.Count)
        //    {
        //        if (int.TryParse(inputList[index], out int num))
        //        {
        //            if (operand1 == 0)
        //            {
        //                operand1 = num;
        //            }
        //            else
        //            {
        //                operand2 = num;
        //                switch (operation)
        //                {
        //                    case "+":
        //                        operand1 += operand2;
        //                        break;
        //                    case "-":
        //                        operand1 -= operand2;
        //                        break;
        //                    case "*":
        //                        operand1 *= operand2;
        //                        break;
        //                    case "/":
        //                        operand1 /= operand2;
        //                        break;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            operation = inputList[index];
        //        }
        //        index++;
        //    }
        //    ctrlText.Text = Convert.ToString(operation);
        //}


    }
}
