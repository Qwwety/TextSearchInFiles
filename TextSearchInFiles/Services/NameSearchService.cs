using System.Linq;
using System.Text;
using TextSearchInFiles.DTOs;

namespace TextSearchInFiles.Services
{
    public interface INameSearchService
    {
        public Task<TotalResultDTO> GetFilesWithKeyWord(string KeyWord);
    }


    public class NameSearchService: INameSearchService
    {
        private string DefaultFilePath = "INFO\\examples\\";

        public async Task<TotalResultDTO> GetFilesWithKeyWord(string KeyWord)
        {
            var result = new TotalResultDTO();

            try
            {
                string[] files = Directory.GetFiles(DefaultFilePath);

                Task[] tasks = new Task[files.Length];

                //Паралельность сдела так, мог через Paralele async, но его использует гораздо меньше
                //чем мой вариант
                var filesData = await Task.WhenAll(files.Select(p => IsFileContainsKeyWord(p, KeyWord)));

                result.FilesResults = filesData.Where(x => x.IsFileContainsKeyWord)
                                        .Select(a => a).ToList();
                return result;
            }
            catch (Exception ex)
            {
                result.ErrorDiscribe = ex.Message;

                return result;
            }
        }

        private async Task<FileResultDTO> IsFileContainsKeyWord(string fileName, string KeyWord)
        {
            var result = new FileResultDTO();

            var fileData = await File.ReadAllTextAsync(fileName);

            var splitted = fileData.Split(' ', '.', ',');

            // одим из доп условий был поиск за O(1), на сколько я заню 
            // в шарпах единственный вар, как это сделать, через  HashSet
            // из-за их механизма работы
            var LogHashSet = new HashSet<string>(splitted);


            if (LogHashSet.Contains(KeyWord))
            {
                result.IsFileContainsKeyWord = true;
                result.FileName = Path.GetFileName(fileName);
            }

            return result;
        }

    }
}
