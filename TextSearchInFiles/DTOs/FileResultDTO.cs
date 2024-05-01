namespace TextSearchInFiles.DTOs
{
    /// <summary>
    /// Сделал так, чтобы можно было спокойно расширять сервис.
    /// Условно потребуется логика, где нам нужно проверять, что несколько 
    /// слов одновременно содержаться в файле, и выводить, только те файлы, где
    /// есть часть этих слов но не все. В таком случае  сюда до баяться доп. переменные, а
    /// фронт будет работать с тем же  
    /// </summary>
    public class FileResultDTO
    {
        public string FileName { get; set; }
        public bool IsFileContainsKeyWord { get; set; }
    }
}
