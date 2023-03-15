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
        private bool isOperatorPerforemed = false;
        private bool isOperationFinihed = false;
        private readonly List<string> lsSymbols = new List<string>() { "+", "-", "*", "/" };

        public Calculator()
        {
            InitializeComponent();
        }

        private void Button_click(object sender, EventArgs e)
        {
            if (ctrlText.Text == "0" || isOperatorPerforemed || isOperationFinihed) {
                ctrlText.Clear();
            }

            var button = (Button)sender;

            if (isOperationFinihed) ctrlOperation.Text = string.Empty;

            isOperationFinihed = false;
            isOperatorPerforemed = lsSymbols.Contains(button.Text);

            if (ctrlText.Text == ".") ctrlText.Text = "0.";
            
            Helper helper = new Helper(ctrlOperation.Text, button.Text, lsSymbols);

            if (helper.ValidateOpertationText())
            {
                ctrlOperation.Text += button.Text;
                ctrlText.Text += button.Text;
            }
           
        }

        private void CEButton_click(object sender, EventArgs e)
        {
            Helper helper = new Helper(ctrlOperation.Text);
            ctrlOperation.Text = helper.RemoveLastValueFromOperationText();
            ctrlText.Text = "0";
        }

        private void CButton_click(object sender, EventArgs e)
        {
            ctrlText.Text = "0";
            ctrlOperation.Text = string.Empty;
        }

        private void EqualButton_click(object sender, EventArgs e)
        {
            Helper helper = new Helper(ctrlOperation.Text, lsSymbols);
            ctrlOperation.Text = helper.RemoveLastValueIfSymbolOrDot();

            DataTable table = new DataTable();
            var result = table.Compute(ctrlOperation.Text, "");
            ctrlText.Text = result.ToString();
            ctrlOperation.Text += "=";
            isOperationFinihed = true;
        }
    }
}
