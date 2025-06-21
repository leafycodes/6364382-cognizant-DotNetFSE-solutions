public interface IDocument
{
    void Open();
    void Save();
    string DocumentType { get; }
}