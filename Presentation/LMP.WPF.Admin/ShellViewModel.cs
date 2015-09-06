using Caliburn.Micro;
using LMP.WPF.Admin.Commandss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents;
using Telerik.Windows.Documents.FormatProviders.Html;
using Telerik.Windows.Documents.FormatProviders.Xaml;
using Telerik.Windows.Documents.Layout;
using Telerik.Windows.Documents.Model;
using System.IO;

namespace LMP.WPF.Admin
{
    public class ShellViewModel : Conductor<Screen>.Collection.OneActive, IShell
    {
        #region Lyrics Editor
        public void DeleteMusicFragment(EventArgs args, RadRichTextBox control)
        {
            DocumentPosition currentPosition = new DocumentPosition(control.Document.CaretPosition);
            var NextSiblingType = currentPosition.GetCurrentInline().NextSibling.GetType();
            var PreviousSiblingType = currentPosition.GetCurrentInline().PreviousSibling.GetType();
            if (NextSiblingType == typeof(ReadOnlyRangeEnd))
            {
                control.Document.CaretPosition.MoveToPreviousInline();
                control.Document.CaretPosition.MoveToNext();
                currentPosition = new DocumentPosition(control.Document.CaretPosition);
                PreviousSiblingType = currentPosition.GetCurrentInline().PreviousSibling.GetType();
            }
            else if (currentPosition.GetCurrentInlineBox().AssociatedInline.GetType() == typeof(ReadOnlyRangeStart))
            {
                control.Document.CaretPosition.MoveToNext();
                currentPosition = new DocumentPosition(control.Document.CaretPosition);
                PreviousSiblingType = currentPosition.GetCurrentInline().PreviousSibling.GetType();
            }
            else if (PreviousSiblingType == typeof(ReadOnlyRangeEnd))
            {
                return;

            }

            var test = currentPosition.GetCurrentInlineBox();
            var currentParagraph = currentPosition.GetCurrentParagraphBox().AssociatedParagraph;

            NextSiblingType = currentPosition.GetCurrentInline().NextSibling.GetType();

            if (PreviousSiblingType == typeof(ReadOnlyRangeStart))
            {
                if (control.Document.Selection.IsEmpty == false)
                {
                    control.Document.Selection.Clear();
                }
                var ro = (ReadOnlyRangeStart)currentPosition.GetCurrentInline().PreviousSibling;
                var spanLost = currentParagraph.EnumerateChildrenOfType<Span>().Where(x => x == currentPosition.GetCurrentInline()).SingleOrDefault();
                currentPosition.MoveToNextInline();
                var spanEnter = currentParagraph.EnumerateChildrenOfType<Span>().Where(x => x == currentPosition.GetCurrentInline()).SingleOrDefault();


                currentParagraph.Inlines.Remove(spanLost);
                currentParagraph.Inlines.Remove(spanEnter);
                control.DeleteReadOnlyRange(ro);


                control.UpdateEditorLayout();
            }





        }

        public void AddCoro(EventArgs args, RadRichTextBox control)
        {
            if (control != null)
            {

                DocumentPosition currentPosition = new DocumentPosition(control.Document.CaretPosition);
                var currentParagraph = currentPosition.GetCurrentParagraphBox().AssociatedParagraph;
                var currentInline = currentPosition.GetCurrentInline();

                ReadOnlyRangeStart rangeStart = new ReadOnlyRangeStart();
                ReadOnlyRangeEnd rangeEnd = new ReadOnlyRangeEnd();
                rangeEnd.PairWithStart(rangeStart);


                currentParagraph.Inlines.AddBefore(currentInline, rangeStart);

                ////currentPosition.MoveToPreviousInline();
                //currentInline = currentPosition.GetCurrentInline();
                //currentParagraph.Inlines.AddBefore(currentInline, new Span(FormattingSymbolLayoutBox.LINE_BREAK));
                currentParagraph.Inlines.AddBefore(currentInline, new Span("  ----  Coro   ----"));
                currentParagraph.Inlines.AddBefore(currentInline, new Span(FormattingSymbolLayoutBox.LINE_BREAK));


                //currentPosition.MoveToPreviousInline();
                //currentInline = currentPosition.GetCurrentInline();

                currentParagraph.Inlines.AddBefore(currentInline, rangeEnd);



                control.UpdateEditorLayout();
            }
            //currentPosition.moveto
        }

        public void AddVerso(EventArgs args, RadRichTextBox control)
        {
            if (control != null)
            {

                DocumentPosition currentPosition = new DocumentPosition(control.Document.CaretPosition);
                var currentParagraph = currentPosition.GetCurrentParagraphBox().AssociatedParagraph;
                var currentInline = currentPosition.GetCurrentInline();

                ReadOnlyRangeStart rangeStart = new ReadOnlyRangeStart();
                ReadOnlyRangeEnd rangeEnd = new ReadOnlyRangeEnd();
                rangeEnd.PairWithStart(rangeStart);
                currentParagraph.Inlines.AddBefore(currentInline, rangeStart);


                currentParagraph.Inlines.AddBefore(currentInline, new Span("  ----  Verso   ----"));
                currentParagraph.Inlines.AddBefore(currentInline, new Span(FormattingSymbolLayoutBox.LINE_BREAK));

                currentParagraph.Inlines.AddBefore(currentInline, rangeEnd);

                control.UpdateEditorLayout();
            }
        }

        private void DeleteReadOnlyRange(ReadOnlyRangeStart readOnlyRange, RadRichTextBox editor)
        {
            DocumentPosition startOfSelection = new DocumentPosition(editor.Document.DocumentLayoutBox, true);
            DocumentPosition endOfSelection = new DocumentPosition(editor.Document.DocumentLayoutBox, true);

            startOfSelection.MoveToInline(readOnlyRange.FirstLayoutBox as InlineLayoutBox, 0);
            startOfSelection.MoveToNext();
            endOfSelection.MoveToInline(readOnlyRange.End.FirstLayoutBox as InlineLayoutBox, 0);
            endOfSelection.MoveToNextInline();
            editor.DeleteReadOnlyRange(readOnlyRange);
            editor.Document.Selection.SetSelectionStart(startOfSelection);
            editor.Document.Selection.AddSelectionEnd(endOfSelection);
            editor.Delete(false);
            startOfSelection.Dispose();
            endOfSelection.Dispose();
        }
        #endregion

        #region Lyrics Manager

        public void SaveLyrics(EventArgs args, RadRichTextBox control)
        {
            //XamlFormatProvider provider = new XamlFormatProvider();
            var provider = new XamlFormatProvider();
            var ok = provider.Export(control.Document);
            File.WriteAllText(@"E:\dev\LMP\canciontest.xaml", ok);
        }

        public void LoadLyrics(EventArgs args, RadRichTextBox control)
        {
            var provider = new XamlFormatProvider();
            var html = File.ReadAllText(@"E:\dev\LMP\canciontest.xaml");

            control.Document = provider.Import(html);
        }
        #endregion



        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);   
        }

       
        public override void TryClose(bool? dialogResult = null)
        {
            base.TryClose(dialogResult);
        }
        
    }
}
