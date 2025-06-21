public class ExcelDocument : IDocument
{
    public string DocumentType => "Excel";

    public void Open()
    {
        Console.WriteLine("Opening Excel spreadsheet...");
    }

    public void Save()
    {
        Console.WriteLine("Saving Excel spreadsheet...");
    }
}