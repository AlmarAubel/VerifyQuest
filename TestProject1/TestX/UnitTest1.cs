using System.Runtime.CompilerServices;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace TestProject1;

public class UnitTest1
{
    
    [ModuleInitializer]
    internal static void Init()
    {
        VerifyTests.VerifyQuestPdf.Initialize();
        QuestPDF.Settings.License = LicenseType.Community;
    }

    [Fact]
    public Task Test12()
    {
        var document = PDFGenerator.GenerateDocument();
        //document.GeneratePdfAndShow();
        
        return Verify(document).UseDirectory("snapshot");
        
       
    }
    
    [Fact]
    public Task Test123()
    {
        var document = new FacturePdf().GenerateInvoice("X");
        document.GeneratePdfAndShow();
        
        return Verify(document).UseDirectory("snapshot");
    }
}