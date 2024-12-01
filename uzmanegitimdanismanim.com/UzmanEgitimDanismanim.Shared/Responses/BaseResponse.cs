namespace UzmanEgitimDanismanim.Shared.Responses
{
    public abstract class BaseResponse
    {
        protected BaseResponse(bool status, string message)
        {
            Message = message;
            Status = status;
        }

        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
