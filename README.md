# Fabrication API ESTmep



Use the Autodesk Fabrication API and C# to create a Hello Fabrication program using the directions provided. The walkthrough below uses C# as the programming language, an equivalent example is provided in the SDK Samples folder using VB.net. 

The Hello Fabrication walkthrough covers the following topics:

This topic contains the following sections:

Create a New Project
Add References
Add Code
Build the Code
Debug the Addin
Create a New Project
The first step in writing a C# program with Visual Studio is to choose a project type and create a new Class Library.

From the File menu, select New > Project. 

In the Installed Templates frame, click Visual C#. 

In the right-hand frame, click Class Library (see Figure 1: Add New Project below). This walkthrough assumes that the project location is: C:\FabricationAPIExamples. 

In the Name field, type HelloFabricationCSharp as the project name. 

Click OK. 

Hello FabricationCSharp New Project
Figure 1: Create New Project
Add References
To add the FabricationAPI reference:

From the View menu select Solution Explorer if the Solution Explorer window is not open. 

In the Solution Explorer, right-click References to display a context menu. 

From the context menu, click Add Reference. The Add Reference dialog box appears. 

In the Add Reference dialog box, click the Browse tab. Locate the folder where the Autodesk Fabrication Product is installed and click the FabricationAPI.dll. For example, the installed folder location is usually C:\Program Files\Autodesk\Fabrication 2017\Fabrication Product Name\FabricationAPI.dll. Note: The Fabrication product name could be CADmep, CAMduct or ESTmep depending on the installed applications. 

Click OK to select the .dll and close the dialog box. FabricationAPI appears in the Solution Explorer reference tree. 

Note: You should always set the Copy Local property of FabricationAPI.dll to false for new projects. This saves disk space, and prevents the Visual Studio debugger from getting confused about which copy of the DLL to use. Right-click the FabricationAPI.dll, select Properties, and change the Copy Local setting from true (the default) to false.

Add Code
Add the following code to create the add-in:

C#
Copyusing System;
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
      //Use Execute method to as the entry point to the Addin
      public void Execute()
      {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("Fabrication API Execute Method Running");
        builder.AppendLine("Application Version Number: " + Autodesk.Fabrication.ApplicationServices.Application.VersionNumber);
        builder.AppendLine("Application Executable Name: " + Autodesk.Fabrication.ApplicationServices.Application.ExecutableName);
        builder.AppendLine("Number of Fabrication Items in Job: " + Job.Items.Count);
        MessageBox.Show(builder.ToString(), "Hello Fabrication");
      }

      //Use Terminate method to clean any resources used by the Addin
      public void Terminate()
      {
        MessageBox.Show("Fabrication API Terminate Method Running", "Hello Fabrication");
      }
    }
}
Tip: The Visual Studio Intellisense feature can create a skeleton implementation of an interface for you, adding stubs for all the required methods. After you add ":IExternalApplication" after Command in the example above, you can select "Implement IExternalApplication" from the Intellisense menu to get the code: 

Hello FabricationCSharp Implement Interface
Figure 2: Using Intellisense to Implement Interface
Every Fabrication add-in application must have an entry point class that implements the IExternalApplication interface, and you must implement the Execute() and Terminate() methods. The Execute() method is the entry point for the add-in application similar to the Main() method in other programs. The add-in entry point class definition is contained in an assembly. 

Build the Code
After completing the code, you must build the file. From the Build menu, click Build Solution. Output from the build appears in the Output window indicating that the project compiled without errors. 

Create a .addin manifest file

The HelloFabricationCSharp.dll file appears in the project output directory. If you want to invoke the application in Autodesk Fabrication, create a manifest file to register it into Autodesk Fabrication. 

To create a manifest file, create a new text file in Notepad. 

Add the following text: 

XML
Copy<?xml version="1.0" encoding="utf-8" standalone="no"?>
<FabricationAddIns>
  <AddIn Type="Application">
    <Name>Hello Fabrication CSharp</Name>
    <FullClassName>HelloFabricationCSharp.Command</FullClassName>
    <Assembly>C:\FabricationAPIExamples\HelloFabricationCSharp\bin\debug\HelloFabricationCSharp.dll</Assembly>
    <AddInId>B2E6C4DB-9CED-422F-BF5C-D9FADC677B65</AddInId>
    <VendorId>Fabrication</VendorId>
    <VendorDescription>Autodesk, Inc, www.autodesk.com</VendorDescription>
  </AddIn>
</FabricationAddIns>
Save the file as HelloFabricationCSharp.addin and put it in the following location: C:\ProgramData\Autodesk\Fabrication\Addins\2017\ 

Debug the Addin
Running a program in Debug mode uses breakpoints to pause the program so that you can examine the state of variables and objects. If there is an error, you can check the variables as the program runs to deduce why the value is not what you might expect. 

In the Solution Explorer window, right-click the HelloFabricationCSharp project to display a context menu. 

From the context menu, click Properties. The Properties window appears. 

Click the Debug tab. 

Under the Start Action section, click Start external program and browse to the ESTmepx64.exe file. By default, the file is located at the following path, C:\Program Files\Autodesk\Fabrication 2017\ESTmep\ESTmepx64.exe. 

Hello FabricationCSharp Debug
Figure 3: Set debug environment
Press F5 to start the debug procedure. 

Select Hello Fabrication CSharp from the Add-Ins menu. 

Hello FabricationCSharp Addin Menu
Figure 4: Select Addin from Menu
The following message appears when the Execute() method is run. 

Hello FabricationCSharp Execute
Figure 5: Addin Execute() Method
Click OK on the message box. 

The following message appears when the Terminate() method is run. 

Hello FabricationCSharp Terminate
Figure 6: Addin Terminate() Method
Click OK on the message box. 

Add Fabrication Items to the Job and re-run the Addin. 

Hello FabricationCSharp Items
Figure 7: Addin with Fabrication Job Items



The Autodesk Fabrication SDK will be installed with CADmep, CAMduct or ESTmep 2017. The SDK contains samples to help you get up and running uing the Autodesk Fabrication API. The samples are located in the SDK/Samples folder located in the Autodesk Fabrication Installation folder. 

Each of the provided Autodesk Fabrication samples contains both the source code and the compiled assemblies along with any dependencies required. Each sample contains a folder named "Compiled" containing all the files required to run the addin, without the need to build the code yourself. Refer to the Addin Integration section on how to run the addin. 

