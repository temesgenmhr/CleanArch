using AutoMapper;
using CleanArch.Application.Contracts.Persistance;
using CleanArch.Application.Features.Categories.Queries.GetCategoriesList;
using CleanArch.Application.Profiles;
using CleanArch.Application.UnitTests.Mocks;
using CleanArch.Domain.Entities;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArch.Application.UnitTests.Catagories.Queries
{
    public class GetCategoryListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

        public GetCategoryListQueryHandlerTests()
        {
            _mockCategoryRepository = RepositoryMoks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }
        [Fact]
        public async Task GetCategoriesTest()
        {
            var handler = new GetCategoryListQueryHandler(_mockCategoryRepository.Object, _mapper);
            var result = await handler.Handle(new GetCategoryListQuery(), CancellationToken.None);

            result.Should().BeOfType<List<CategoryListVm>>();
            result.Count.Should().Be(4);
        }
    }
}
