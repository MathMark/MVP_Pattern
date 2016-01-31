using System.IO;
using System.Text;

namespace MVP_Patt
{
    public interface IFileManager
    {
        bool IsExist(string filePath);
        string GetContent(string filePath);
        void SaveContent(string content, string filePath);
        int GetSymbolCount(string content);
        
    }
    public class FileManager:IFileManager
    {
        public bool IsExist(string filePath)
        {
            return File.Exists(filePath);
        }

        private readonly Encoding defaultEncoding = Encoding.GetEncoding(1251);

        public string GetContent(string filePath, Encoding encoding)
        {
            return File.ReadAllText(filePath, encoding);
        }

        public string GetContent(string filePath)
        {
            return File.ReadAllText(filePath, defaultEncoding);
        }

        public void SaveContent(string content,string filePath)
        {
            SaveContent(content, filePath, defaultEncoding);
        }

        public void SaveContent(string content,string filePath, Encoding encoding)
        {
            File.WriteAllText(filePath, content, encoding);
        }

        public int GetSymbolCount(string content)
        {
            return content.Length;
        }


    }
}
