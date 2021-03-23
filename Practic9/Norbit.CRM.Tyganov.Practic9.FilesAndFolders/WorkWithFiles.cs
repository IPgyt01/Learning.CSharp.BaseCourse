using System.IO;

namespace Norbit.CRM.Tyganov.Practic9.FilesAndFolders
{
    public class WorkWithFiles
    {
        public static string ReadStringFromFile(string path)
        {
            Checker(path);
            return File.ReadAllText(path);
        }

        public static byte[] ReadByteArrayFromFile(string path)
        {
            Checker(path);
            return File.ReadAllBytes(path);
        }

        public void WriteStringInFile(string destination, string source)
        {
            Checker(destination);
            File.WriteAllText(destination, source);
        }

        public void WriteByteArrayInFile(string destination, byte[] source)
        {
            Checker(destination);
            File.WriteAllBytes(destination, source);
        }

        public void WriteIndoInEndFile(string destination, string source)
        {
            Checker(destination);
            File.AppendAllText(destination, source);
        }

        private static void Checker(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
        }
    }
}
