public abstract class DocumentFactory
{
    public abstract IDocument CreateDocument();

    public void ProcessDocument()
    {
        var doc = CreateDocument();
        Console.WriteLine($"Processing {doc.DocumentType} document");
        doc.Open();
        doc.Save();
    }
}