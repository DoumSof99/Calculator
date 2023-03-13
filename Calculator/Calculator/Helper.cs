using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Calculator
{
    public class Helper
    {
        public string _button { get; set; }

        public Helper()
        {
            
        }

        public string AddButtonValueToText()
        {
            return _button;
        }

        public string GetlastValueFromOperationText(string operationText)
        {
            return !string.IsNullOrEmpty(operationText) ? operationText[operationText.Length - 1].ToString() : null;
        }
    }

    public class Numbers : Helper
    {

        public Numbers(string button)
        {
            _button = button;
        }

    }

    public class OperationSymbols : Helper
    {
        public OperationSymbols(string button)
        {
            _button = button;
        }

        public bool ValidateOperationNotAddSymbolAfterDot(string operationText, List<string> lsSymbols)
        {
            string lastValueInText = GetlastValueFromOperationText(operationText);
            return lsSymbols.Contains(_button) && lastValueInText == "." ? false : true;
        }

        public bool ValidateOperationNotAddSymbolAfterSymbol(List<string> lsValues, List<string> lsSymbols)
        {
            bool value = true;
            if (lsValues.Count > 0)
            {
                value = lsSymbols.Contains(_button) && lsSymbols.Contains(lsValues.Last()) ? false : true;
            }
            return value;
        }
    }
}
