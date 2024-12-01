using Newtonsoft.Json;
using UzmanEgitimDanismanim.Shared.Dtos.CustomDtos;

namespace UzmanEgitimDanismanim.Shared.Responses
{
    /// <summary>
    ///     Genel dönüş tipidir. T ye veri koyulacak null bile olsa ve hata yoksa dönen değer koyulacak. Hata varsa mesaj
    ///     yazılıp status false dönecek.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class GResponse<T> : BaseResponse where T : class
    {
        private GResponse(bool status, string message, T data, ErrorDto errorDto = null) : base(status, message)
        {
            Data = data;
        }
        [JsonConstructor]
        //Başarılı ise
        public GResponse(T data, ErrorDto errorDto = null, string message = null) : this(true, message, data, errorDto)
        {
        }

        //Başarısız ise
        public GResponse(string message, ErrorDto errorDto = null) : this(false, message, null, errorDto)
        {
        }

        public T Data { get; set; }
    }
}
