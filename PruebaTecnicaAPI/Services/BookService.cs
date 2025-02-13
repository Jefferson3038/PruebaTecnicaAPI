using Newtonsoft.Json;
using PruebaTecnicaAPI.Models;
using System.Net;
using System.Text;

namespace PruebaTecnicaAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;


        public BookService(IHttpClientFactory httpcClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpcClientFactory;
            _configuration = configuration;
        }

        public async Task<Response<dynamic>> GetBooks()
        {
            var httpClient = _httpClientFactory.CreateClient("ApiUrl");
            var pathResource = _configuration["ApiUrl:Resources:Books:GetBooks"];
            var response = await httpClient.GetAsync(pathResource);
            var result = new Response<object>();

            if (response.StatusCode.Equals(HttpStatusCode.NotFound)
               || response.StatusCode.Equals(HttpStatusCode.Unauthorized)
               || response.StatusCode.Equals(HttpStatusCode.BadRequest))
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                result.StatusCode = response.StatusCode;

                result.StatusCodeMessage = response.StatusCode.ToString();
                result.IsSuccess = response.IsSuccessStatusCode;
                result.Message = $"Error";
                result.Data = errorJson;
                return result;
            }
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var responseJSON = JsonConvert.DeserializeObject<List<Books>>(json);
            result.StatusCode = response.StatusCode;
            result.StatusCodeMessage = HttpStatusCode.OK.ToString();
            result.IsSuccess = response.IsSuccessStatusCode;
            result.Message = $"Busqueda exitosa";
            result.Data = responseJSON;
            return result;
        }

        public async Task<Response<dynamic>> GetBooksByID(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("ApiUrl");
            var pathResource = _configuration["ApiUrl:Resources:Books:BooksById"];
            var url = string.Format(pathResource, id);
            var response = await httpClient.GetAsync(url);
            var result = new Response<object>();

            if (response.StatusCode.Equals(HttpStatusCode.NotFound)
               || response.StatusCode.Equals(HttpStatusCode.Unauthorized)
               || response.StatusCode.Equals(HttpStatusCode.BadRequest))
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                result.StatusCode = response.StatusCode;
                var errorJSONS = JsonConvert.DeserializeObject<ErrorMessage>(errorJson);
                result.StatusCodeMessage = response.StatusCode.ToString();
                result.IsSuccess = response.IsSuccessStatusCode;
                result.Message = $"Error";
                result.Data = errorJSONS;
                return result;
            }
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var responseJSON = JsonConvert.DeserializeObject<Books>(json);
            result.StatusCode = response.StatusCode;
            result.StatusCodeMessage = HttpStatusCode.OK.ToString();
            result.IsSuccess = response.IsSuccessStatusCode;
            result.Message = $"Busqueda exitosa";
            result.Data = responseJSON;
            return result;
        }

        public async Task<Response<dynamic>> SendBooks(SendBooks books)
        {
            var httpClient = _httpClientFactory.CreateClient("ApiUrl");
            var pathResource = _configuration["ApiUrl:Resources:Books:GetBooks"];
            var json = JsonConvert.SerializeObject(books);
            var request = new HttpRequestMessage(HttpMethod.Post, pathResource)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            var response = await httpClient.SendAsync(request);
            var result = new Response<object>();
            if (response.StatusCode.Equals(HttpStatusCode.NotFound)
               || response.StatusCode.Equals(HttpStatusCode.Unauthorized)
               || response.StatusCode.Equals(HttpStatusCode.BadRequest))
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                result.StatusCode = response.StatusCode;
                var errorJSONS = JsonConvert.DeserializeObject<ErrorMessage>(errorJson);
                result.StatusCodeMessage = response.StatusCode.ToString();
                result.IsSuccess = response.IsSuccessStatusCode;
                result.Message = $"Error";
                result.Data = errorJSONS;
                return result;
            }
            response.EnsureSuccessStatusCode();
            var resultJson = await response.Content.ReadAsStringAsync();
            var responseJSON = JsonConvert.DeserializeObject<SendBooks>(resultJson);
            result.StatusCode = response.StatusCode;
            result.StatusCodeMessage = HttpStatusCode.OK.ToString();
            result.IsSuccess = response.IsSuccessStatusCode;
            result.Message = $"Libro Registrado";
            result.Data = responseJSON;
            return result;
        }

        public async Task<Response<dynamic>> DeleteBooks(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("ApiUrl");
            var pathResource = _configuration["ApiUrl:Resources:Books:BooksById"];
            var url = string.Format(pathResource, id);
            var response = await httpClient.DeleteAsync(url);
            var result = new Response<object>();
            if (response.StatusCode.Equals(HttpStatusCode.NotFound)
               || response.StatusCode.Equals(HttpStatusCode.Unauthorized)
               || response.StatusCode.Equals(HttpStatusCode.BadRequest))
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                result.StatusCode = response.StatusCode;
                var errorJSONS = JsonConvert.DeserializeObject<ErrorMessage>(errorJson);
                result.StatusCodeMessage = response.StatusCode.ToString();
                result.IsSuccess = response.IsSuccessStatusCode;
                result.Message = $"Error";
                result.Data = errorJSONS;
                return result;
            }
            response.EnsureSuccessStatusCode();
            var resultJson = await response.Content.ReadAsStringAsync();
            result.StatusCode = response.StatusCode;
            result.StatusCodeMessage = HttpStatusCode.OK.ToString();
            result.IsSuccess = response.IsSuccessStatusCode;
            result.Message = $"Libro Eliminado";
            result.Data = resultJson;
            return result;
        }

        public async Task<Response<dynamic>> UpdateBooks(int id, SendBooks books)
        {
            var httpClient = _httpClientFactory.CreateClient("ApiUrl");
            var pathResource = _configuration["ApiUrl:Resources:Books:BooksById"];
            var url = string.Format(pathResource, id);
            var json = JsonConvert.SerializeObject(books);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(url, content);
            var result = new Response<object>();
            if (response.StatusCode.Equals(HttpStatusCode.NotFound)
               || response.StatusCode.Equals(HttpStatusCode.Unauthorized)
               || response.StatusCode.Equals(HttpStatusCode.BadRequest))
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                result.StatusCode = response.StatusCode;
                var errorJSONS = JsonConvert.DeserializeObject<ErrorMessage>(errorJson);
                result.StatusCodeMessage = response.StatusCode.ToString();
                result.IsSuccess = response.IsSuccessStatusCode;
                result.Message = $"Error";
                result.Data = errorJSONS;
                return result;
            }
            response.EnsureSuccessStatusCode();
            var resultJson = await response.Content.ReadAsStringAsync();
            var responseJSON = JsonConvert.DeserializeObject<SendBooks>(resultJson);
            result.StatusCode = response.StatusCode;
            result.StatusCodeMessage = HttpStatusCode.OK.ToString();
            result.IsSuccess = response.IsSuccessStatusCode;
            result.Message = $"Libro Actualizado";
            result.Data = responseJSON;
            return result;
        }

    }
}

