namespace PruebaTecnicaAPI.Models
{
    public record SendBooks
    (
        int id,
        string title,
        string description,
        int pageCount,
        string excerpt,
        DateTime publishDate
    );
}
