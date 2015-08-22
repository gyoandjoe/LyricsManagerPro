using Caliburn.Micro;
using LMP.WPF.Admin.Commandss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents;
using Telerik.Windows.Documents.Layout;
using Telerik.Windows.Documents.Model;

namespace LMP.WPF.Admin
{
    public class ShellViewModel : Conductor<Screen>.Collection.OneActive, IShell
    {
        //public ShellViewModel()
        //{

        //}


        private RadRichTextBox _radRichTextBox2;

        public RadRichTextBox radRichTextBox2
        {
            get { return _radRichTextBox2; }
            set { _radRichTextBox2 = value; }
        }


        public RadRichTextBox radRichTextBox22 { get; set; }

        private string _text = @"<h1>Solo Texto</h1>";

        public string Texto
        {
            get { return _text; }
            set { _text = value; this.NotifyOfPropertyChange(() => Texto); }
        }


        private string _Contenido = @"<h1>mI CONTENIDO 2</h1> <p>Documentacion </p> <h2 class=""Interesante""> Titulo 2 </h2>";
        public string Contenido
        {
            get { return _Contenido; }
            set {
                _Contenido = value;
                this.NotifyOfPropertyChange(() => Contenido);
            }
        }

        private string _body;

        public string Body
        {
            get { return _body; }
            set { _body = value; this.NotifyOfPropertyChange(() => Body); }
        }
        private InsertVersoCommand _comandok;

        public InsertVersoCommand comandok
        {
            get { return _comandok; }
            set { _comandok = value; this.NotifyOfPropertyChange(() => comandok); }
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            string testText = @"V1
 Is it just me or the walls closing in?
 I can't be the only one feeling this
 So lets tear down brick by brick
 Cause it's not helping anyone
 Lets get out from under this
 Or we'll watch it fall on us all

Chorus
 Can you feel the urgency now
 Its time for us to love out loud
 Take what we know and live it out

V2
 So am I part of the cure or part of the disease
 I think its time we fall down on our knees
 And ask God for clarity
 To wash away our memories of the old way
 Yeah, and pray that the walls break

Chorus 2
 Can you feel the urgency now
 Its time for us to love out loud
 Take what we know and live it out
 This could be the start of a new day
 We could be the change
 If we take this love and live it out

Bridge
 We are lost and broken people
 Turned our crosses into steeples
 Lets take them down and put them on our backs now
 Keep your love on track now
 Cause this is an emergency
";
        }

        public virtual void Test()
        {

            Texto = @"<h1>Interesante</h1>";

            string plainTxt = @"{\rtf1\ansi\deff0
 {\colortbl;\red0\green0\blue0;\red255\green0\blue0;}
 This line is the default color\line
 \cf2
 This line is red\line
 \cf1
 This line is the default color
 }";
            //Contenido = plainTxt;


            string html = @"<h1>Title</h1> <p>jaja</p>";
            //Body = html;
        }
        public override void TryClose(bool? dialogResult = null)
        {
            base.TryClose(dialogResult);
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
                currentParagraph.Inlines.AddBefore(currentInline, new Span("  ----  Coro   ----" ));
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
                RadDocument rd = new RadDocument();
                //rd = control.Document;
                Section section = new Section();
                Paragraph paragraph = new Paragraph();
                Span s2 = new Span();
                s2.Text = "This is my text editable" ;
                paragraph.Inlines.Add(s2);
                section.Blocks.Add(paragraph);
                //paragraph.Inlines.Add(new Span(FormattingSymbolLayoutBox.ENTER));
                
                Span span = new Span("  ----  Verso   ----");

                Paragraph paragraph2 = new Paragraph();
                ReadOnlyRangeStart rangeStart = new ReadOnlyRangeStart();
                ReadOnlyRangeEnd rangeEnd = new ReadOnlyRangeEnd();
                rangeEnd.PairWithStart(rangeStart);
                paragraph2.Inlines.Add(rangeStart);
                paragraph2.Inlines.Add(span);
                paragraph2.Inlines.Add(rangeEnd);
                section.Blocks.Add(paragraph2);

                rd.Sections.Add(section);

                //control.Insert(FormattingSymbolLayoutBox.ENTER);
                control.Document = rd;
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
                //if (control.Document.Selection.IsEmpty == false)
                //{
                //    control.Document.Selection.Clear();
                //}
                //control.Document.CaretPosition.MoveToPreviousInline();
                //control.Document.CaretPosition.MoveToPreviousInline();
                //control.Document.CaretPosition.MoveToNext();
                //currentPosition = new DocumentPosition(control.Document.CaretPosition);
                //PreviousSiblingType = currentPosition.GetCurrentInline().PreviousSibling.GetType();
                //if (PreviousSiblingType == typeof(ReadOnlyRangeEnd))
                //{
                //    control.Document.CaretPosition.MoveToPreviousSpanBox();
                //    control.Document.CaretPosition.MoveToNext();
                //    currentPosition = new DocumentPosition(control.Document.CaretPosition);
                //    PreviousSiblingType = currentPosition.GetCurrentInline().PreviousSibling.GetType();
                //}
            }            

            var test = currentPosition.GetCurrentInlineBox();
            var currentParagraph = currentPosition.GetCurrentParagraphBox().AssociatedParagraph;
            
            NextSiblingType = currentPosition.GetCurrentInline().NextSibling.GetType();

            if (PreviousSiblingType == typeof(ReadOnlyRangeStart)  )
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
    }
}
