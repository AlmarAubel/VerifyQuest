using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

public static class PDFGenerator
{
   public  static IDocument GenerateDocument() =>
        Document.Create(container =>
        {
            container.Page(AddPage);
            container.Page(AddPage);
        });

   private  static void AddPage(PageDescriptor page)
    {
        page.Size(PageSizes.A4);
        page.Margin(1, Unit.Centimetre);
        page.PageColor(Colors.Grey.Lighten3);
        page.DefaultTextStyle(_ => _.FontSize(20));

        page.Header()
            .Text("Hello PDF!2")
            .SemiBold().FontSize(36);

        page.Content()
            .Column(_ => _.Item()
                .Text(Placeholders.LoremIpsum()));

        page.Footer()
            .AlignCenter()
            .Text(_ =>
            {
                _.Span("Page ");
                _.CurrentPageNumber();
            });
    }
}