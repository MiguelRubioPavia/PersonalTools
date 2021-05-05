using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomControls
{
    public class NumericTextbox : TextBox
    {
        private string _decimalSeparator { get => CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator; }
        private string _thousandSeparator { get => CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator; }

        public NumericTextbox() : base()
        {
            CommandBinding command = new CommandBinding
            {
                Command = ApplicationCommands.Paste
            };
            command.Executed += OnPaste;
            CommandBindings.Add(command);
        }

        // To simplify the process, when pasting, we replace the whole text (if the content in the clipboard is a valid value)
        // We have to take into account the possible culture differences in decimal and thousands separators, so
        // we try to "guess" what is a decimal separator and what is a thousands separator
        private void OnPaste(object sender, ExecutedRoutedEventArgs e)
        {
            if (!Clipboard.ContainsText()) return;

            string clipboard = Clipboard.GetText().Trim();

            // Check if it's a number. Note that the pattern is not perfect and some invalid cases will still pass
            // specially cases related with the decimal and thousand separator symbol
            if (!Regex.IsMatch(clipboard, @"^-?[\d\.\,]*$")) return;

            int countDecimalSeparator = 0;
            int countThousandSeparator = 0;
            foreach (char c in clipboard)
            {
                if (c == _decimalSeparator[0])
                    countDecimalSeparator++;
                if (c == _thousandSeparator[0])
                    countThousandSeparator++;
            }

            if (countDecimalSeparator > 0 && countThousandSeparator > 0)
            {
                // Invalid
                if (countDecimalSeparator > 1 && countThousandSeparator > 1)
                    return;
                // Simply remove the thousand separator
                else if (countThousandSeparator > 1)
                    clipboard = clipboard.Replace(_thousandSeparator, "");
                // Decimal and thousand separator are swapped, so we interchange them and delete the thousand separator
                else if (countDecimalSeparator > 1)
                {
                    clipboard = clipboard.Replace(_decimalSeparator, "");
                    clipboard = clipboard.Replace(_thousandSeparator, _decimalSeparator);
                }
                else
                {
                    // We take the symbol most at the right as the decimal separator
                    if (clipboard.IndexOf(_thousandSeparator) < clipboard.IndexOf(_decimalSeparator))
                        clipboard = clipboard.Replace(_thousandSeparator, "");
                    else
                    {
                        clipboard = clipboard.Replace(_decimalSeparator, "");
                        clipboard = clipboard.Replace(_thousandSeparator, _decimalSeparator);
                    }
                }
            }
            // The decimal separator is actually a thousand separator, so we remove it
            else if (countDecimalSeparator > 1)
                clipboard = clipboard.Replace(_decimalSeparator, "");
            // If there is only one thousand separator, we take it as a decimal separator, otherwise, if there are multiple, we remove it
            else if (countThousandSeparator > 0)
                clipboard = clipboard.Replace(_thousandSeparator, countThousandSeparator == 1 ? _decimalSeparator : "");

            // Last check to make sure that is a valid number
            if (decimal.TryParse(clipboard, out decimal _))
            {
                Text = clipboard;
                SelectionStart = clipboard.Length;
            }
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space || e.Key == Key.Tab;

            base.OnPreviewKeyDown(e);
        }

        protected override void OnTextInput(TextCompositionEventArgs e)
        {
            // To discard letters or symbols that don't belong in numbers
            if (!Regex.IsMatch(e.Text, @"[\d\.\,\-]")) 
                e.Handled = true;
            // Control for the decimal and thousands separator
            else if (e.Text == _thousandSeparator || e.Text == _decimalSeparator)
            {
                // If the number already has a decimal separator, the input is discarded
                if (Text.Contains(_decimalSeparator))
                    e.Handled = true;
                // If the decimal symbol would be put at the start of the number (so the current value would be all decimals), we add a 0 as the integer
                else if (SelectionStart == (Text.StartsWith("-") ? 1 : 0))
                {
                    if (Text.StartsWith("-"))
                        Text = "-0" + _decimalSeparator + (Text.Length > 1 ? Text.Substring(1) : string.Empty);
                    else
                        Text = "0" + _decimalSeparator + Text;
                    SelectionStart = Text.Length;
                    e.Handled = true;
                }
                // If the input is the thousands separator, is converted into a decimal separator. This is done for convenience in case that
                // the decimal separator in the user's keyboard number pad and the decimal separator of the system doesn't match
                else if (e.Text == _thousandSeparator)
                {
                    AppendText(_decimalSeparator);
                    SelectionStart++;
                    e.Handled = true;
                }
            }
            // Control for the negative symbol
            else if (e.Text == "-")
            {
                // Instead of adding the symbol at the caret position, we toggle the negative symbol at the start of the number
                if (Text.StartsWith("-"))
                    Text = Text.Length > 1 ? Text.Substring(1) : string.Empty;
                else
                    Text = "-" + Text;

                SelectionStart = Text.Length;
                e.Handled = true;
            }

            base.OnTextInput(e);
        }
    }
}
