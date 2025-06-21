class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Document Management System\n");

        DocumentFactory wordFactory = new WordDocumentFactory();
        IDocument wordDoc = wordFactory.CreateDocument();
        Console.WriteLine($"Created: {wordDoc.DocumentType}");
        wordDoc.Open();
        wordDoc.Save();

        DocumentFactory pdfFactory = new PdfDocumentFactory();
        IDocument pdfDoc = pdfFactory.CreateDocument();
        Console.WriteLine($"\nCreated: {pdfDoc.DocumentType}");
        pdfDoc.Open();
        pdfDoc.Save();

        Console.WriteLine("\nUsing ProcessDocument method:");
        DocumentFactory excelFactory = new ExcelDocumentFactory();
        excelFactory.ProcessDocument();

        Console.ReadKey();
    }
}