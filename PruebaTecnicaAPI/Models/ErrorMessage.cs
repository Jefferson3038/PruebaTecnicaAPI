namespace PruebaTecnicaAPI.Models
{
    public record ErrorMessage
    (
        string type,
        string title,
        int status,
        string traceId
    );
}
