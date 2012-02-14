using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AviBlog.Core.ViewModel
{
    public class HtmlFragmentViewModel :BaseViewModel
    {
        public int Id { get; set; }
        public int BlogId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Script Body")]
        [DataType(DataType.MultilineText)]
        public string ScriptBody { get; set; }

        [Display(Name = "Location on Webpage")]
        public SelectList LocationList { get; set; }

        public string SelectedLocationId { get; set; }
    }
}