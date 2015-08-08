using Caliburn.Micro;
using LMP.WPF.Admin.Commandss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;
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


        public void AddCoro()
        {

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

                s2.Text = "This is my text";
                paragraph.Inlines.Add(s2);
                section.Blocks.Add(paragraph);
                rd.Sections.Add(section);
                
                //control.Insert(FormattingSymbolLayoutBox.ENTER);
                control.Document = rd;
            }

        }


    }
}
