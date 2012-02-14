using System;
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

            List<DropDownViewModel> list =
                pageLocations.Select(location => new DropDownViewModel
                                                     {Id = location.Id, Name = location.LocationName})
                    .ToList();

            list.Insert(0, new DropDownViewModel {Id = 0, Name = ""});

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
            var entity = _htmlFragmentMappingService.MapToEntity(viewModel);
            string errorMessage = _htmlFragmentRepository.AddHtmlFragment(entity, viewModel.BlogId,viewModel.SelectedLocationId);
            return errorMessage;
        }

        public string DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}