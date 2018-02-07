using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
// TODO: 01: Bring the Microsoft.Office.Interop.Word namespace into scope.
using Microsoft.Office.Interop.Word;


namespace FourthCoffee.ExceptionLogger
{
    /// <summary>
    /// Represents the <see cref="FourthCoffee.ExceptionLogger.ExceptionCombiner" /> class in the object model.
    /// </summary>
    public class ExceptionCombiner
    {
        string _outputFilePath;
        IEnumerable<ExceptionEntry> _exceptions;
        // TODO: 02: Declare a global object to encapsulate Microsoft Word.
        dynamic _word;

        public ExceptionCombiner(string outputFilePath, IEnumerable<ExceptionEntry> exceptions)
        {
            if (exceptions == null)
                throw new NullReferenceException("exceptions");

            this._outputFilePath = outputFilePath;
            this._exceptions = exceptions;
        }

        public void WriteToWordDocument()
        {
            if (this._exceptions.Count() == 0)
                return;

            // TODO: 03: Instantiate the _word object.
            this._word = new Application();

            this.GenerateWordDocument();

            this._word.Quit();
        }

        private void GenerateWordDocument()
        {
            this.CreateDocument();

            this.AppendText("Exception Report", true, true);

            this.InsertCarriageReturn();

            var count = 1;
            foreach (var exception in this._exceptions)
            {
                this.AppendText(
                    string.Format("{0}) {1}", count, exception.Title), 
                    true, 
                    false);

                this.InsertCarriageReturn();
                this.AppendText(exception.Details, false, false);
                this.InsertCarriageReturn();
                this.InsertCarriageReturn();
                count++;
            }

            this.Save();          
        }

        private void CreateDocument()
        {
            // TODO: 04: Create a blank Word document.
            this._word.Documents.Add().Activate();
        }

        private void AppendText(string text, bool bold, bool underLine)
        {
            var currentLocation = this.GetEndOfDocument();

            currentLocation.Bold = bold ? 1 : 0;
            currentLocation.Underline = underLine ? WdUnderline.wdUnderlineSingle : WdUnderline.wdUnderlineNone;
            currentLocation.InsertAfter(text);
        }

        private void InsertCarriageReturn()
        {
            var currentLocation = this.GetEndOfDocument();

            currentLocation.InsertBreak(WdBreakType.wdLineBreak);
        }

        private void Save()
        {
            if (File.Exists(this._outputFilePath))
                File.Delete(this._outputFilePath);

            var currentDocument = this._word.ActiveDocument;

            currentDocument.SaveAs(this._outputFilePath);
            currentDocument.Close();
        }

        private Range GetEndOfDocument()
        {
            var endOfDocument = this._word.ActiveDocument.Content.End - 1;
            return this._word.ActiveDocument.Range(endOfDocument);
        }
    }
}
