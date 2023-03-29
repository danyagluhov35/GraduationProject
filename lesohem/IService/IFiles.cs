

using lesohem.DataBase;

public interface IFiles
{
    Task<string> GetPath(IFormFile fileName);
    void CreatePath(string path);
    void FileWrite(string text,string path);
    Task<string> FileRead(IFormFile file,string path);
    void SaveContent(TableContent content);
    List<TableContent> GetContent();
}

