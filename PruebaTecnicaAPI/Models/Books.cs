namespace PruebaTecnicaAPI.Models
{
    public record Books
    (
        int id,
        string title,
        string description,
        int pageCount,
        string excerpt
     );
}
