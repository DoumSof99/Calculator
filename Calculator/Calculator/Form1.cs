using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private bool shouldAddToListAndText = false;
        private bool isOperatorPerforemed = false;
        private List<string> lsSymbols = new List<string>() { "+", "-", "*", "/" };
        private List<string> lsValues = new List<string> ();
        public Calculator()
        {
            InitializeComponent();
        }

        private void Button_click(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (ctrlText.Text == "0" || isOperatorPerforemed) ctrlText.Clear();

            if (lsSymbols.Contains(button.Text))
            {
                ctrlText.Text = button.Text;
                isOperatorPerforemed = true;
                shouldAddToListAndText = false;
            }
            else
            {
                ctrlText.Text += button.Text;
                isOperatorPerforemed = false;
                shouldAddToListAndText = false;
            }

            // TODO: Not add dot after symbol, but if it is 0. then add
            // TODO: Fix bug with not adding 0 at all
            if (button.Text == "0")
            {
                string text = ctrlOperation.Text;
                string lastValueInText = text[text.Length - 1].ToString();

                foreach (var item in lsSymbols)
                {
                    if (!text.EndsWith(item) && item == lastValueInText)
                    {
                        shouldAddToListAndText = true;
                    }
                }
            }
            else
            {
                shouldAddToListAndText = true;
            }

            // DONE not to add operation after operation
            if (lsValues.Count > 0)
            {
                if (lsSymbols.Contains(button.Text) && lsSymbols.Contains(lsValues.Last()))
                {
                    shouldAddToListAndText = false;
                }
            }

            if (shouldAddToListAndText)
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
