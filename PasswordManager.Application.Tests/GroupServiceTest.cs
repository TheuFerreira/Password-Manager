using Moq;
using PasswordManager.Application.DTOs;
using PasswordManager.Application.Services.Impl;
using PasswordManager.Domain.Entities;
using PasswordManager.Domain.Repositories;

namespace PasswordManager.Application.Tests
{
    public class GroupServiceTest : BaseTest
    {
        private readonly GroupServiceImpl groupService;

        public GroupServiceTest()
        {
            Mock<IGroupRepository> groupRepository = new();

            List<Group> groups = [
                new(1, "Mock 1"),
                new(2, "Mock 2"),
            ];
            groupRepository
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(() => groups);

            groupRepository
                .Setup(x => x.CreateAsync(It.IsAny<Group>()))
                .ReturnsAsync((Group group) =>
                {
                    var newGroup = new Group(groups.Count + 1, group.Title);
                    groups.Add(newGroup);
                    return newGroup;
                });

            groupRepository
                .Setup(x => x.UpdateAsync(It.IsAny<Group>()))
                .ReturnsAsync((Group group) =>
                {
                    var groupToUpdate = groups.SingleOrDefault(x => x.Id == group.Id);
                    if (groupToUpdate == null) return null;

                    groupToUpdate.Update(group.Title);
                    return groupToUpdate;
                });

            groupRepository
                .Setup(x => x.DeleteAsync(It.IsAny<Group>()))
                .ReturnsAsync((Group group) =>
                {
                    var groupToDelete = groups.SingleOrDefault(x => x.Id == group.Id);
                    if (groupToDelete == null) return null;

                    groups.Remove(groupToDelete);
                    return groupToDelete;
                });

            groupRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync((int id) => groups.FirstOrDefault(x => x.Id == id));

            groupService = new GroupServiceImpl(mapper, groupRepository.Object);
        }

        [Fact]
        public async Task GetAll()
        {
            List<GroupDTO> expected = [
                new() { Id = 1, Title = "Mock 1" },
                new() { Id = 2, Title = "Mock 2" },
            ];
            var actual = await groupService.GetAllAsync();

            Assert.All(actual, group =>
            {
                var expectedUser = expected.Single(e => e.Id == group.Id);
                Assert.Equal(expectedUser.Title, group.Title);
            });
        }

        [Fact]
        public async Task Create()
        {
            var group = new GroupDTO() { Title = "Mock 3" };
            var actual = await groupService.CreateAsync(group);

            Assert.Equal(3, actual.Id);
            Assert.Equal(group.Title, actual.Title);
        }

        [Fact]
        public async Task Update()
        {
            var group = new GroupDTO() { Id = 2, Title = "Mock 2 Updated" };
            var actual = await groupService.UpdateAsync(group);

            Assert.NotNull(actual);
            Assert.Equal(group.Id, actual.Id);
            Assert.Equal(group.Title, actual.Title);
        }

        [Fact]
        public async Task Delete()
        {
            var actual = await groupService.DeleteAsync(1);
            Assert.NotNull(actual);
            Assert.Equal(1, actual.Id);
            Assert.Equal("Mock 1", actual.Title);
        }
    }
}
