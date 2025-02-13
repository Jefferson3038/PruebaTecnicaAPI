using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaAPI.Models;
using PruebaTecnicaAPI.Services;

namespace PruebaTecnicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <remarks>
        /// Busca todos los libros sin parametro
        /// </remarks>
        /// <summary>
        /// Realizar busqueda de todos los libros
        /// </summary>
        /// <response code="200">Retorna la información correctamente.</response>
        /// <response code="400">Responde si la consulta no se encuentra.</response>
        [HttpGet("GetBooks")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Response<List<Books>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ErrorMessage>), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> GetBooks()
        {
            try
            {
                Response<dynamic> result = await _bookService.GetBooks();
                return Ok(result);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <remarks>
        /// Busca libros por parametro
        /// </remarks>
        /// <summary>
        /// Realizar busqueda de libro por ID
        /// </summary>
        /// <param name="id">Id del libro a buscar.</param>
        /// <response code="200">Retorna la información correctamente.</response>
        /// <response code="400">Responde si la consulta no se encuentra.</response>
        [HttpGet("GetBooksById/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Response<Books>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ErrorMessage>), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> GetBooksById(int id)
        {
            try
            {
                Response<dynamic> result = await _bookService.GetBooksByID(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <remarks>
        /// Registra el libro
        /// </remarks>
        /// <summary>
        /// Realizar el registro del libro
        /// </summary>
        /// <param name="books">Libro a crear.</param>
        /// <response code="200">Retorna la información correctamente.</response>
        /// <response code="400">Responde si la consulta no se encuentra.</response>
        [HttpPost("SendBooks")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Response<SendBooks>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ErrorMessage>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendBooks(SendBooks books)
        {
            try
            {
                Response<dynamic> result = await _bookService.SendBooks(books);
                return Ok(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <remarks>
        /// Elimina el libro
        /// </remarks>
        /// <summary>
        /// Realizar la eliminación del libro
        /// </summary>
        /// <param name="id">Libro a eliminar.</param>
        /// <response code="200">Retorna la información correctamente.</response>
        /// <response code="400">Responde si la consulta no se encuentra.</response>
        [HttpDelete("DeleteBooks/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Response<>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ErrorMessage>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBooks(int id)
        {
            try
            {
                Response<dynamic> result = await _bookService.DeleteBooks(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <remarks>
        /// Actualizar el libro
        /// </remarks>
        /// <summary>
        /// Realizar la actualizacion del libro
        /// </summary>
        /// <param name="id">Libro a actualizar.</param>
        /// <response code="200">Retorna la información correctamente.</response>
        /// <response code="400">Responde si la consulta no se encuentra.</response>
        [HttpPut("UpdateBooks/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Response<SendBooks>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ErrorMessage>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBooks(int id, SendBooks books)
        {
            try
            {
                Response<dynamic> result = await _bookService.UpdateBooks(id, books);
                return Ok(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
