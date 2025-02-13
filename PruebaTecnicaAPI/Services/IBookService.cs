using PruebaTecnicaAPI.Models;

namespace PruebaTecnicaAPI.Services
{
    public interface IBookService
    {
        //Por si hay cambios en el api, admita cualquier tipo de objeto
        public Task<Response<dynamic>> GetBooks();
        public Task<Response<dynamic>> GetBooksByID(int id);

        public Task<Response<dynamic>> SendBooks(SendBooks book);
        public Task<Response<dynamic>> DeleteBooks(int id);
        public Task<Response<dynamic>> UpdateBooks(int id, SendBooks book);
    }
}

