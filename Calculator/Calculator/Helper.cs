using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Calculator
{
    public class Helper
    {
        private List<string> _lsSymbols;
        private string _operationText;
        private string _button;
        public Helper(string operationText, string button, List<string> lsSymbols)
        {
            _operationText = operationText;
            _button = button;
            _lsSymbols = lsSymbols;
        }

        public Helper(string operationText, List<string> lsSymbols)
        {
            _operationText = operationText;
            _lsSymbols = lsSymbols;
        }

        public Helper(string operationText)
        {
            _operationText=operationText;
        }

        public string RemoveLastValueFromOperationText()
        {
            return !string.IsNullOrEmpty(_operationText) ? _operationText.Substring(0, _operationText.Length - 1) : _operationText;
        }

        private string LastValueFromOperationText()
        {
            return !string.IsNullOrEmpty(_operationText) ? _operationText.Substring(_operationText.Length - 1)[0].ToString() : string.Empty;
        }

        public bool ValidateOpertationText()
        {
            return CheckForSymbolAfterSymbol() && CheckForSymbolAfterDotAndReverse();
        }

        private bool CheckForSymbolAfterSymbol()
        {
            string lastValueInOperationText = LastValueFromOperationText();
            return _lsSymbols.Contains(_button) && _lsSymbols.Contains(lastValueInOperationText) 
                ? false : true;
        }

        private bool CheckForSymbolAfterDotAndReverse()
        {
            string lastValueInOperationText = LastValueFromOperationText();
            return (_lsSymbols.Contains(_button) && lastValueInOperationText == ".")
                || (_lsSymbols.Contains(lastValueInOperationText) && _button == ".")
                ? false : true;
        }

        public string RemoveLastValueIfSymbolOrDot ()
        {
            string value = _operationText;
            string lastValue = LastValueFromOperationText();
            if (lastValue == "." || _lsSymbols.Contains(lastValue)) value = RemoveLastValueFromOperationText();
            return value;
        }

    }
}
