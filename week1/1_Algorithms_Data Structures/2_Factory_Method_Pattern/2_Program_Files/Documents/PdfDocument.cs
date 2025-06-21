public class PdfDocument : IDocument
{
    public string DocumentType => "PDF";

    public void Open()
    {
        Console.WriteLine("Opening PDF document...");
    }

    public void Save()
    {
        Console.WriteLine("Saving PDF document...");
    }
}