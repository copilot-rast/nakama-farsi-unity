namespace PolicePatrol.Sdk
{
    public sealed class ApiResult<T>
    {
        private ApiResult(T data, ApiError error, string code)
        {
            Data = data;
            Error = error;
            Code = code ?? error?.Code;
        }

        public T Data { get; }

        public ApiError Error { get; }

        public string Code { get; }

        public bool IsSuccess => Error == null;

        public static ApiResult<T> Ok(T data, string code = null) => new ApiResult<T>(data, null, code);

        public static ApiResult<T> Fail(ApiError error) => new ApiResult<T>(default, error, null);
    }
}
