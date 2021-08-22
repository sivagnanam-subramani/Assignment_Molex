using System;
using Assignment.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Assignment.Managers;
using Assignment.Models;

namespace Assignment.UnitTest.Managers
{
    public class StoriesManagerTests
    {
        #region Mock Properties 
        public Mock<IStoriesRepository> _storiesRepository;
        #endregion End of Mock Properties

        [SetUp]
        public void Setup()
        {
            _storiesRepository = new Mock<IStoriesRepository>();
        }

        //*=========================StoriesManagerTests-GetStories============================*//

        [TestFixture]
        public class GetStories : StoriesManagerTests
        {
            [TestCase]
            public async Task Given_GetStories_Called_Return_Data()
            {
                // Arrange
                _storiesRepository.Setup(x => x.GetStories()).Returns(Task.FromResult<ObservableCollection<string>>(new ObservableCollection<string>() { "28262122", "28260194" }));
                var _storiesManager = new StoriesManager(_storiesRepository.Object);

                // Act
                var resp = await _storiesManager.GetStories();

                // Assert
                Assert.IsNotNull(resp);
                Assert.Greater(resp.Count, 0);
            }

            [TestCase]
            public async Task Given_GetStories_Called_Return_Empty_List()
            {
                // Arrange
                _storiesRepository.Setup(x => x.GetStories()).Returns(Task.FromResult<ObservableCollection<string>>(new ObservableCollection<string>()));
                var _storiesManager = new StoriesManager(_storiesRepository.Object);

                // Act
                var resp = await _storiesManager.GetStories();

                // Assert
                Assert.IsNotNull(resp);
                Assert.AreEqual(resp.Count, 0);
            }
        }

        //*=========================StoriesManagerTests-GetStoryDetails============================*//

        [TestFixture]
        public class GetStoryDetails : StoriesManagerTests
        {
            [TestCase]
            public async Task Given_GetStoryDetails_Called_Return_Data()
            {
                // Arrange
                _storiesRepository.Setup(x => x.GetStoryDetails(It.IsAny<List<string>>())).Returns(Task.FromResult(new ObservableCollection<StoryDetailModel>() { new StoryDetailModel() {
                    Id=22512196,
                    Title="Firecracker: Secure and fast microVMs for serverless computing",
                    Type="story",
                    Url="https://firecracker-microvm.github.io/"

                } }));
                var _storiesManager = new StoriesManager(_storiesRepository.Object);

                // Act
                var resp = await _storiesManager.GetStoriesWithDetail(0, new ObservableCollection<string>() { "22512196" });

                // Assert
                Assert.IsNotNull(resp);
                Assert.Greater(resp.Count, 0);
                Assert.AreEqual(resp[0].Id, 22512196);
                Assert.AreEqual(resp[0].Title, "Firecracker: Secure and fast microVMs for serverless computing");
            }

            [TestCase]
            public async Task Given_GetStoryDetails_Called_Return_Empty_Data()
            {
                // Arrange
                _storiesRepository.Setup(x => x.GetStoryDetails(It.IsAny<List<string>>())).Returns(Task.FromResult(new ObservableCollection<StoryDetailModel>()));
                var _storiesManager = new StoriesManager(_storiesRepository.Object);

                // Act
                var resp = await _storiesManager.GetStoriesWithDetail(0, new ObservableCollection<string>() { "22512196" });

                // Assert
                Assert.IsNotNull(resp);
                Assert.AreEqual(resp.Count, 0);
            }

            [TestCase]
            public async Task Given_GetStoryDetails_When_Parameter_List_Is_Empty_Called_Return_Empty_Data()
            {
                // Arrange
                _storiesRepository.Setup(x => x.GetStoryDetails(It.IsAny<List<string>>())).Returns(Task.FromResult(new ObservableCollection<StoryDetailModel>()));
                var _storiesManager = new StoriesManager(_storiesRepository.Object);

                // Act
                var resp = await _storiesManager.GetStoriesWithDetail(0, new ObservableCollection<string>());


                // Assert
                Assert.IsNotNull(resp);
                Assert.AreEqual(resp.Count, 0);
            }

        }
    }
}
