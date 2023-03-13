namespace Core.Models
{
    public abstract class Model<T> where T : struct
    {
        public T Id { get; set; }
    }
}