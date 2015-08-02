using LMP.WPF.Admin.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMP.WPF.Admin
{
    public class AppBootstrapper : AutofacBootstrapper<ShellViewModel>
    {
        protected override void ConfigureBootstrapper() 
        {
            //  you must call the base version first!
            base.ConfigureBootstrapper();

            //  override namespace naming convention
            EnforceNamespaceConvention = false;
            //  change our view model base type
            ViewModelBaseType = typeof(IShell);
        }
    }
}
