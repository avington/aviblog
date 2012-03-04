using System.ComponentModel.DataAnnotations;

namespace AviBlog.Core.ViewModel
{
    public class PingServiceViewModel
    {
        public int Id { get; set; }

        [Required]
        public string PingUrl { get; set; }
    }
}