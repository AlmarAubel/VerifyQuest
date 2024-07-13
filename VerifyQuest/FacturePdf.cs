using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

public class FacturePdf
{
    public Document GenerateInvoice(string filePath)
    {
        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(12));

                page.Header()
                    .Height(100)
                    .Background(Colors.Grey.Lighten3)
                    .AlignCenter()
                    .Text("FACTURE")
                    .FontSize(36)
                    .Bold();

                page.Content().PaddingVertical(1, Unit.Centimetre).Column(column =>
                {
                    column.Item().Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text("Joanna Binet").Bold();
                            col.Item().Text("48 Coubertin");
                            col.Item().Text("31400 Paris");
                        });

                        row.ConstantItem(50);

                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text("FACTURÉ À").Bold();
                            col.Item().Text("Cendrillon Ayot");
                            col.Item().Text("69 rue Nations");
                            col.Item().Text("22000 Paris");
                        });

                        row.ConstantItem(50);

                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text("ENVOYÉ À").Bold();
                            col.Item().Text("Cendrillon Ayot");
                            col.Item().Text("46 Rue St Ferréol");
                            col.Item().Text("92360 Île-de-France");
                        });
                    });

                    column.Item().PaddingVertical(10);

                    column.Item().Table(x=>CreateTable(x));

                    column.Item().PaddingVertical(10);

                    column.Item().Row(row =>
                    {
                        row.RelativeItem();
                        row.ConstantItem(200).Column(col =>
                        {
                            col.Item().Text("Total HT").AlignRight();
                            col.Item().Text("145.00").AlignRight();

                            col.Item().Text("TVA 20.0%").AlignRight();
                            col.Item().Text("29.00").AlignRight();

                            col.Item().Text("TOTAL").Bold().AlignRight();
                            col.Item().Text("174.00 €").Bold().AlignRight();
                        });
                    });

                    column.Item().PaddingVertical(10);

                    column.Item().Text("CONDITIONS ET MODALITÉS DE PAIEMENT").Bold();
                    column.Item().Text("Le paiement est dû dans 15 jours");

                    column.Item().PaddingVertical(10);

                    column.Item().Text("Caisse d'Epargne").Bold();
                    column.Item().Text("IBAN: FR12 1234 5678");
                    column.Item().Text("SWIFT/BIC: ABCDFR1XXX");

                    column.Item().PaddingVertical(10);

                    column.Item().Text("Merci").FontSize(24).Bold().AlignCenter();
                });

                page.Footer()
                    .Height(50)
                    .AlignCenter()
                    .Text(text =>
                    {
                        text.DefaultTextStyle(x => x.FontSize(10));
                        text.Line("Joanna Binet").Bold();
                        text.Line("Signature");
                    });
            });
        });

        return document;
    }

    private static void CreateTable(TableDescriptor table)
    {
        table.ColumnsDefinition(columns =>
        {
            columns.ConstantColumn(40);
            columns.RelativeColumn();
            columns.ConstantColumn(80);
            columns.ConstantColumn(80);
        });

        table.Header(header =>
        {
            header.Cell().Element(CellStyle).Text("QTE");
            header.Cell().Element(CellStyle).Text("DÉSIGNATION");
            header.Cell().Element(CellStyle).Text("PRIX UNIT. HT");
            header.Cell().Element(CellStyle).Text("MONTANT HT");

            IContainer CellStyle(IContainer container)
            {
                return container.DefaultTextStyle(x => x.Bold()).Padding(5).Background(Colors.Grey.Lighten2);
            }
        });

        table.Cell().Element(CellStyle).Text("1");
        table.Cell().Element(CellStyle).Text("Grand brun escargot pour manger");
        table.Cell().Element(CellStyle).Text("100.00");
        table.Cell().Element(CellStyle).Text("100.00");

        table.Cell().Element(CellStyle).Text("2");
        table.Cell().Element(CellStyle).Text("Petit marinière uniforme en bleu");
        table.Cell().Element(CellStyle).Text("15.00");
        table.Cell().Element(CellStyle).Text("30.00");

        table.Cell().Element(CellStyle).Text("4");
        table.Cell().Element(CellStyle).Text("Facile à jouer accordéon");
        table.Cell().Element(CellStyle).Text("5.00");
        table.Cell().Element(CellStyle).Text("15.00");

        IContainer CellStyle(IContainer container)
        {
            return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten1).Padding(5);
        }
    }
}