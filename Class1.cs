using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Autodesk.Fabrication;
using Autodesk.Fabrication.UI;
using Autodesk.Fabrication.ApplicationServices;

namespace HelloFabricationCSharp
{
    public class Command : IExternalApplication
    {
        public Command()
        {
        }

        //Use Execute method to as the entry point to the Add-in
        public void Execute()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Fabrication API Execute Method Running");
            builder.AppendLine("Application Version Number: " + Autodesk.Fabrication.ApplicationServices.Application.VersionNumber);
            builder.AppendLine("Application Executable Name: " + Autodesk.Fabrication.ApplicationServices.Application.ExecutableName);
            builder.AppendLine("Number of Fabrication Items in Job: " + Job.Items.Count);
            MessageBox.Show(builder.ToString(), "Hello Fabrication");
        }

        //Use Terminate method to clean any resources used by the Add-in
        public void Terminate()
        {
            MessageBox.Show("Fabrication API Terminate Method Running", "Hello Fabrication");
        }
    }
}

