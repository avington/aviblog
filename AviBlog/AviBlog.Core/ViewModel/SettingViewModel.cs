using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AviBlog.Core.ViewModel
{
    public class SettingViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Key { get; set; }

        [AllowHtml]
        [Required]
        public string Entry { get; set; }
    }
}