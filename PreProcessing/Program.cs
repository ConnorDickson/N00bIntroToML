using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PreProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            var csvBuilder = new StringBuilder();

            foreach (var directory in Directory.EnumerateDirectories(@"..\..\..\RawData"))
            {
                //The folders are broken down into their categories
                var categoryName = Path.GetFileName(directory);

                foreach(var file in Directory.EnumerateFiles(directory))
                {
                    var fileContent = File.ReadAllText(file);

                    //Remove the new lines from the content
                    fileContent = fileContent.Replace("\n", string.Empty).Replace(",", string.Empty);

                    csvBuilder.AppendLine($"{fileContent},{categoryName}");
                }
            }

            var csvFilePath = @"..\..\..\RawData\CleanBBCData.csv";
            File.Delete(csvFilePath);
            File.AppendAllText(csvFilePath, csvBuilder.ToString());
        }
    }
}
