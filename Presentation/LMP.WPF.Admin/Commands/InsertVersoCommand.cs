using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents.RichTextBoxCommands;

namespace LMP.WPF.Admin.Commandss
{


    public class RichTextBoxCommands2 : INotifyPropertyChanged
    {

        
        public virtual InsertVersoCommand InsertVersoCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class RichTextBox2 : RadRichTextBox
    {
        public RichTextBox2()
        {
            Comandos = new RichTextBoxCommands2();
            Comandos.InsertVersoCommand = new InsertVersoCommand(this);
        }
        public RichTextBoxCommands2 Comandos;
        
    }

    public class InsertVersoCommand :RichTextBoxCommandBase
    {
        public InsertVersoCommand(RadRichTextBox editor)
            : base(editor)
        {

        }

        protected override void ExecuteOverride(object parameter)
        {
            throw new NotImplementedException();
        }
    }

    public class InsertVerso2Command : InsertTextCommand
    {

        public InsertVerso2Command(RadRichTextBox editor)
            : base(editor)
        {
            
        }

        protected override void ExecuteOverride(object parameter)
        {
            throw new NotImplementedException();
        }

        

        protected override CanExecuteBehaviorInProtectedDocument CanExecuteBehaviorInProtectedDocument
        {
            get
            {
                return base.CanExecuteBehaviorInProtectedDocument;
            }
        }
    }
}
