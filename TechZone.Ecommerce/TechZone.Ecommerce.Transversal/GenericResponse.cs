namespace TechZone.Ecommerce.Transversal
{
    public class GenericResponse<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<BaseError> Errors { get; set; } = new List<BaseError>();
    }
}
