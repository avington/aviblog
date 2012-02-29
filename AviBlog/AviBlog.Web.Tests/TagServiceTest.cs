using System.Collections.Generic;
using System.Linq;
using AviBlog.Core.Entities;
using AviBlog.Core.Repositories;
using AviBlog.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace AviBlog.Web.Tests
{
    [TestClass]
    public class TagServiceTest
    {
        private TagService _target;
        private ITagRepostiory _repository;

        [TestInitialize]
        public void Setup()
        {
            _repository = MockRepository.GenerateMock<ITagRepostiory>();
            _target = new TagService(_repository);
        }

        [TestMethod]
        public void Should_be_able_to_convert_a_list_of_tags_to_a_list_of_tagclouds()
        {
            //arrange
            _repository.Expect(x => x.GetAllTags())
                .Return(BuildTagList());

            //act
            var result = _target.GetTagCloud();

            //assert
            Assert.AreEqual(3,result.First(x => x.TagName == "Tag2").Weight);
        }

        private IQueryable<Tag> BuildTagList()
        {
            List<Tag> tags = new List<Tag>
                                 {
                                     new Tag {Id = 1, TagName = "Tag1"},
                                     new Tag {Id = 2, TagName = "Tag1"},
                                     new Tag {Id = 3, TagName = "Tag2"},
                                     new Tag {Id = 4, TagName = "Tag2"},
                                     new Tag {Id = 5, TagName = "Tag2"},
                                     new Tag {Id = 6, TagName = "Tag2"},
                                     new Tag {Id = 7, TagName = "Tag2"},
                                     new Tag {Id = 8, TagName = "Tag2"},
                                     new Tag {Id = 9, TagName = "Tag9"},
                                     new Tag {Id = 10, TagName = "Tag9"},
                                     new Tag {Id = 11, TagName = "Tag9"},
                                     new Tag {Id = 12, TagName = "Tag12"},
                                     new Tag {Id = 13, TagName = "Tag13"},
                                     new Tag {Id = 14, TagName = "Tag14"},
                                     new Tag {Id = 15, TagName = "Tag15"},
                                     new Tag {Id = 16, TagName = "Tag15"},
                                     new Tag {Id = 17, TagName = "Tag15"},
                                     new Tag {Id = 18, TagName = "Tag15"},
                                     new Tag {Id = 19, TagName = "Tag19"},
                                     new Tag {Id = 20, TagName = "Tag20"},
                                     new Tag {Id = 21, TagName = "Tag21"},


                                 };
            return tags.AsQueryable();
        }
    }
}