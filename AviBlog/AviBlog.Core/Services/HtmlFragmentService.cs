using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AviBlog.Core.Entities;
using AviBlog.Core.Mappings;
using AviBlog.Core.Repositories;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public class HtmlFragmentService : IHtmlFragmentService
    {
        private readonly IHtmlFragmentMappingService _htmlFragmentMappingService;
        private readonly IHtmlFragmentRepository _htmlFragmentRepository;

        public HtmlFragmentService(IHtmlFragmentRepository htmlFragmentRepository,
                                   IHtmlFragmentMappingService htmlFragmentMappingService)
        {
            _htmlFragmentRepository = htmlFragmentRepository;
            _htmlFragmentMappingService = htmlFragmentMappingService;
        }

        #region IHtmlFragmentService Members

        public HtmlFragmentViewModel GetViewModel(int blogId)
        {
            IQueryable<HtmlFragmentLocation> pageLocations = _htmlFragmentRepository
                .GetAllHtmlPageLocations();

            IEnumerable<DropDownViewModel> list = GetLocationSelectList(pageLocations);

            var viewModel =
                new HtmlFragmentViewModel
                    {
                        BlogId = blogId,
                        LocationList = new SelectList(list, "Id", "Name")
                    };

            return viewModel;
        }

        public string AddHtmlFragement(HtmlFragmentViewModel viewModel)
        {
            HtmlFragment entity = _htmlFragmentMappingService.MapToEntity(viewModel);
            string errorMessage = _htmlFragmentRepository.AddHtmlFragment(entity, viewModel.BlogId,
                                                                          viewModel.SelectedLocationId);
            return errorMessage;
        }

        public string DeleteById(int id)
        {
            string errorMessage = _htmlFragmentRepository.DeleteHtmlFragment(id);
            return errorMessage;
        }

        public HtmlFragmentViewModel GetHtmlFragment(int id)
        {
            HtmlFragment entity = _htmlFragmentRepository.GetAllHtmlFragments().FirstOrDefault(x => x.Id == id);
            HtmlFragmentViewModel view = _htmlFragmentMappingService.MapToView(entity);

            IQueryable<HtmlFragmentLocation> pageLocations = _htmlFragmentRepository
                .GetAllHtmlPageLocations();

            int locationId = 0;
            if (entity != null && entity.Location != null)
            {
                 locationId = entity.Location.Id;
            }

            IEnumerable<DropDownViewModel> list = GetLocationSelectList(pageLocations);
            view.LocationList = new SelectList(list,"Id","Name",locationId);
            return view;
        }

        public string UpdateHtmlFragment(HtmlFragmentViewModel viewModel)
        {
            HtmlFragment entity = _htmlFragmentMappingService.MapToEntity(viewModel);
            string errorMessage = _htmlFragmentRepository.UpdateHtmlFragment(entity, viewModel.BlogId,
                                                              viewModel.SelectedLocationId);
            return errorMessage;
        }

        #endregion

        private static IEnumerable<DropDownViewModel> GetLocationSelectList(
            IQueryable<HtmlFragmentLocation> pageLocations)
        {
            List<DropDownViewModel> list =
                pageLocations.Select(location => new DropDownViewModel
                                                     {Id = location.Id, Name = location.LocationName})
                    .ToList();

            list.Insert(0, new DropDownViewModel {Id = 0, Name = ""});
            return list;
        }
    }
}