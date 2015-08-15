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
                currentParagraph.Inlines.AddBefore(currentInline, new Span("Okey"));
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

        public void DeleteMusicFragment(EventArgs args, RadRichTextBox control)
        {
            DocumentPosition startPosition = new DocumentPosition(control.Document.CaretPosition);
            var currentParagraph = startPosition.GetCurrentParagraphBox().AssociatedParagraph;
            //DocumentPosition endPosition = new DocumentPosition(startPosition);

            if (startPosition.GetCurrentInline().PreviousSibling.GetType() == typeof ( ReadOnlyRangeStart))
            {
                control.DeleteReadOnlyRange();
                var spanLost = currentParagraph.EnumerateChildrenOfType<Inline>().Where(x => x == startPosition.GetCurrentInline()).SingleOrDefault();
                currentParagraph.Inlines.Remove(spanLost);
            }

            

            //ReadOnlyRangeStart start = currentParagraph.EnumerateChildrenOfType<ReadOnlyRangeStart>().FirstOrDefault();//start = control.Document.EnumerateChildrenOfType<ReadOnlyRangeStart>().Where(x => x.Tag == "ReadOnly").FirstOrDefault();
            //if (start != null)
            //{




            //    control.Document.Sections.FirstOrDefault().Blocks.Remove(currentParagraph);

            //    control.Document.UpdateLayout();
            //    //control.UpdateLayout();
            //    //NotifyOfPropertyChange(() => control.Document);

            //}



            //control.DeleteReadOnlyRange();

            //var startt = currentParagraph.EnumerateChildrenOfType<ReadOnlyRangeStart>().FirstOrDefault();



            //control.Document = control.Document;
            //startPosition.MoveToFirstPositionInParagraph();
            //endPosition.MoveToLastPositionInParagraph();
            //control.Document.Selection.SetSelectionStart(startPosition);
            //control.Document.Selection.AddSelectionEnd(endPosition);
        }
    }
}
