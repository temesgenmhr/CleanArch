using AutoMapper;
using CleanArch.Application.Contracts.Persistance;
using CleanArch.Application.Features.Categories.Commands.CreateCategory;
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

namespace CleanArch.Application.UnitTests.Catagories.Commands
{
    public class CreateCategoryTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

        public CreateCategoryTests()
        {
            _mockCategoryRepository = RepositoryMoks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }
        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoriesRepo()
        {
            var handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);
            await handler.Handle(new CreateCategoryCommand() { name = "Test" }, CancellationToken.None);

            var allCats = await _mockCategoryRepository.Object.ListAllAsnc();
            allCats.Count.Should().Be(5);
        }
    }
}
