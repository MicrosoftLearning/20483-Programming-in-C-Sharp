using System;
using System.IO;
using Microsoft.Office.Interop.Word;

namespace Grades.Utilities
{
    public class WordWrapper
    {
        // TODO: Exercise 1: Task 1a: Create a dynamic variable called _word for activating Word

        /// <summary>
        /// Creates an instance of the WordWrapper class.
        /// </summary>
        public WordWrapper()
        {
            // TODO: Exercise 1: Task 1b: Instantiate _word as a new Word Application object

        }

        /// <summary>
        /// Creates blank word document.
        /// </summary>
        public void CreateBlankDocument()
        {
            // TODO: Exercise 1: Task 1c: Create a new Word document

        }

        /// <summary>
        /// Appends text to the end of the current word document.
        /// </summary>
        /// <param name="text">The text to append.</param>
        /// <param name="bold">Indicate whether the text should be bold.</param>
        /// <param name="underLine">Indicate whether the text should be underlined.</param>
        public void AppendText(string text, bool bold, bool underLine)
        {
            var currentLocation = this.GetEndOfDocument();

            currentLocation.Bold = bold ? 1 : 0;
            currentLocation.Underline = underLine ? WdUnderline.wdUnderlineSingle : WdUnderline.wdUnderlineNone;
            currentLocation.InsertAfter(text);
        }

        /// <summary>
        /// Appends text with the Heading 1 style to the end of the current word document.
        /// </summary>
        /// <param name="text">The text to append.</param>
        public void AppendHeading(string text)
        {
            var currentLocation = this.GetEndOfDocument();

            currentLocation.InsertAfter(text);
            currentLocation.set_Style(WdBuiltinStyle.wdStyleHeading1);
            currentLocation.InsertParagraphAfter();
        }

        /// <summary>
        /// Inserts a carriage return to the end of the document.
        /// </summary>
        public void InsertCarriageReturn()
        {
            var currentLocation = this.GetEndOfDocument();
            currentLocation.InsertBreak(WdBreakType.wdLineBreak);
        }

        /// <summary>
        /// Inserts a page break to the end of the document.
        /// </summary>
        public void InsertPageBreak()
        {
            var currentLocation = this.GetEndOfDocument();
            currentLocation.InsertBreak(WdBreakType.wdPageBreak);
        }

        /// <summary>
        /// Saves the current document.
        /// </summary>
        /// <param name="filePath">The absolute file path.</param>
        public void SaveAs(string filePath)
        {
            // TODO: Exercise 1: Task 1d: Save the document using the specified filename.

            // TODO: Exercise 1: Task 1e: Close the document

        }

        private Range GetEndOfDocument()
        {
            // Find the end of the document
            return this._word.ActiveDocument.Range(this._word.ActiveDocument.Content.End - 1);
        }
    }
}
