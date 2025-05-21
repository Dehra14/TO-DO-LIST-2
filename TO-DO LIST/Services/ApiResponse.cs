namespace TO_DO_LIST.Services
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
    }
}