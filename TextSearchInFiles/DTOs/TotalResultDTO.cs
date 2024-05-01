namespace TextSearchInFiles.DTOs
{

    /// <summary>
    /// Эта штку нужна из-за условия в ReadMe 
    /// "Если при поиске произошла ошибка, то возвращаем ошибку и nil для списка файлов." - написано для GO, 
    /// но это просто бизнес логика, она может быть везде
    /// </summary>
    public class TotalResultDTO
    {
       public List<FileResultDTO> FilesResults { get; set; }

        public string ErrorDiscribe { get; set; }

        public TotalResultDTO()
        {
            FilesResults= new List<FileResultDTO>();
        }
    }
}
