// See https://aka.ms/new-console-template for more information

using Microsoft.Office.Interop.Excel;
using System;
using System.CodeDom;
using System.Reflection;
using System.Text;

Console.WriteLine("Hello, World!");

Application xlApp;
Workbook xlWorkBook;
Worksheet xlWorkSheet;


xlApp = new Application();
xlWorkBook = xlApp.Workbooks.Open(@"D:\Develop\deleteme\Jul2023\GstIndia\PreProcess\Government Schema - Managed\Generate E-Invoice (IRP Schema) Ver 1.xlsx");
xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
Console.WriteLine($" {xlWorkSheet.Name} :  {xlWorkSheet.UsedRange.Columns.Count} : {xlWorkSheet.UsedRange.Rows.Count} :");
//var range = xlWorkSheet.get_Range(xlWorkSheet.Cells[2,7], xlWorkSheet.Cells[2,7]);
//Console.WriteLine(xlWorkSheet.UsedRange.ToString());


var rw = xlWorkSheet.UsedRange.Rows.Count;
var cl = xlWorkSheet.UsedRange.Columns.Count;
var mainClass = NameClassFromFileName("Generate E-Invoice (IRP Schema) Ver 1");
var codeCompileUnit = new CodeCompileUnit();
CodeNamespace nameSpace;
nameSpace = new CodeNamespace("GeneratedDtos");
nameSpace.Imports.Add(new CodeNamespaceImport("System"));
AddClass(nameSpace,  mainClass);

var previousComment = string.Empty;
for (var rCnt = 1; rCnt <= rw; rCnt++)
{
    StringBuilder sb = new StringBuilder();
    for (var cClnt = 1; cClnt <= cl; cClnt++)
    {
        if (cClnt == 1 && !string.IsNullOrWhiteSpace(xlWorkSheet.UsedRange.Cells[rCnt, cClnt])
            && string.IsNullOrWhiteSpace(xlWorkSheet.UsedRange.Cells[rCnt, 2])
            )
        {
            previousComment = xlWorkSheet.UsedRange.Cells[rCnt, cClnt];
            continue;
        }

        if (cClnt == 2 && !string.IsNullOrWhiteSpace(xlWorkSheet.UsedRange.Cells[rCnt, 2]))
        {

        }
        var format = $"[{rCnt}, {cClnt}]: {(xlWorkSheet.UsedRange.Cells[rCnt, cClnt]).Value2}, ";
        sb.Append(format);
        
    }
    Console.WriteLine(sb.ToString());
    Console.ReadLine();
}
codeCompileUnit.Namespaces.Add(nameSpace);

string NameClassFromFileName(string fileName)
{
    return String.Join("", fileName.Split('@', ' ', '.', '(', ')', '-', '_'));
}

///
/// https://learn.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/how-to-create-a-class-using-codedom
/// 
void AddClass(CodeNamespace nameSpace, string className)
{
    var targetClass = new CodeTypeDeclaration(className);
    targetClass.IsClass = true;
    targetClass.TypeAttributes =
        TypeAttributes.Public | TypeAttributes.Sealed;
    nameSpace.Types.Add(targetClass);

}

void AddProperty(string propertyName, Type propertyType, string comment)
{
    Type typeIs;
    typeIs = typeof(bool);
}

