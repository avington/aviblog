namespace AviBlog.Core.Entities
{
    public class StopWord
    {
        public int Id { get; set; }
        public virtual Blog Blog { get; set; }
        public string Word { get; set; }
    }
}