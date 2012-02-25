using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AviBlog.Core.ViewModel
{
    public class PostViewModel : BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [AllowHtml]
        [Display(Name = "Excerpt (Optional)")]
        public string Description { get; set; }

        [Display(Name = "Content")]
        [AllowHtml]
        public string PostContent { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date Modified")]
        public DateTime? DateModified { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date Published")]
        public DateTime? DatePublished { get; set; }

        [Display(Name = "Publish")]
        public bool IsPublished { get; set; }
        public string Slug { get; set; }
        public bool IsDeleted { get; set; }
        public IList<CategoryViewModel> Categories { get; set; }
        public IList<TagViewModel> Tags { get; set; }
        public IList<TrackbackViewModel> Trackbacks { get; set; }
        public int SectedUserId { get; set; }
        public SelectList UserList { get; set; }
        public BlogSiteViewModel SelectedBlog { get; set; }
        public SelectList BlogList { get; set; }

        [Display(Name = "Blog")]
        public int SelectedBlogId { get; set; }

        [Display(Name = "Tags (Use commas to separate)")]
        [DataType(DataType.MultilineText)]
        public string TagListCommaDelimited { get; set; }
        public Guid UniqueId { get; set; }

        public string UserFullName { get; set; }
    }
}