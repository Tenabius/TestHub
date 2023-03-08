﻿using TestHub.Core.Entities;
using TestHub.Core.Interfaces;
using TestHub.Web.Interfaces;
using TestHub.Web.Models;

namespace TestHub.Web.Services
{
    public class TestPassingService : ITestPassingService
    {
        private readonly IRepository<Test> _repository;
        //TODO WTF
        //private Test _test;

        public TestPassingService(IRepository<Test> repository)
        {
            _repository = repository;
        }

        public TestBlankViewModel GetTestBlank(int testId)
        {
            return MapTestToTestBlank(_repository.GetById(testId));
        }

        public void SubmitTestBlank(TestBlankViewModel testBlankViewModel)
        {
            throw new NotImplementedException();
        }

        private TestBlankViewModel MapTestToTestBlank(Test test)
        {
            //TestBlankViewModel blank = new()
            //{
            //    AuthorId = test.Author.Id,
            //    AuthorName = test.Author.Name,
            //    Name = test.Title,
            //    Description = test.Description,
            //    Id = test.Id,
            //    Duration = test.Duration
            //};

            //return blank;

            throw new NotImplementedException();
        }
    }
}
