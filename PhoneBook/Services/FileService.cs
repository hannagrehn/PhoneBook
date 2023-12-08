using System;
using System.Diagnostics;
using System.IO;

namespace PhoneBook.Services
{
    public interface IFiles
    {
        bool SaveContentToFile(string content);
        string GetContentFromFile();
    }

    public class FileService : IFiles
    {
        private readonly string _filePath;

        public FileService(string filePath)
        {
            _filePath = filePath;
        }

        public bool SaveContentToFile(string content)
        {
            try
            {
                using (var sw = new StreamWriter(_filePath))
                {
                    sw.WriteLine(content);
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return false;
        }

        public string GetContentFromFile()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    using var sr = new StreamReader(_filePath);
                    return sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return null!;
        }
    }
}
