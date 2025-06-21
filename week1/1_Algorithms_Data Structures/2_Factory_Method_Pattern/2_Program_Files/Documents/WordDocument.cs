public class WordDocument : IDocument
{
    public string DocumentType => "Word";

    public void Open()
    {
        Console.WriteLine("Opening Word document...");
    }

    public void Save()
    {
        Console.WriteLine("Saving Word document...");
    }
}