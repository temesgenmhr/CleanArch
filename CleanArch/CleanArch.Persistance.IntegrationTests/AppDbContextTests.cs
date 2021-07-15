using CleanArch.Application.Contracts;
using CleanArch.Domain.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArch.Persistance.IntegrationTests
{
    public class AppDbContextTests
    {
        private readonly AppDbContext _appDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;
        public AppDbContextTests()
        {
            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);
            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
        }
        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            var ev = new Event() { EventId = Guid.NewGuid(), Name = "Test Event" };
            _appDbContext.Events.Add(ev);
            await _appDbContext.SaveChangesAsync();

            ev.CategoryId.Should().Be(_loggedInUserId);
        }
    }
}
