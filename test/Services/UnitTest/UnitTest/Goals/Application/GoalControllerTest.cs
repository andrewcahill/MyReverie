using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Controllers;
using WebMVC.Services;
using WebMVC.ViewModels;
using Microsoft.Extensions.Logging;
using WebMVC.ViewModels.GoalViewModels;

namespace UnitTest.Goals.Application
{
    public class GoalControllerTest
    {
        private readonly Mock<IGoalService> _iGoalServiceMock;
        private readonly Mock<ILogger<GoalController>> _iLoggerMock;

        public GoalControllerTest()
        {
            _iGoalServiceMock = new Mock<IGoalService>();   
            _iLoggerMock = new Mock<ILogger<GoalController>>();
        }

        [Fact]
        public async Task GetGoal()
        {
            _iGoalServiceMock.Setup(x => x.GetGoal()).Returns(Task.FromResult(new Goal(){ Name = "First Goal" }));

            GoalController goalController = new GoalController(_iGoalServiceMock.Object, _iLoggerMock.Object);

            var actionResult = await goalController.Index();

            var viewResult = Assert.IsType<ViewResult>(actionResult);

            var model = Assert.IsAssignableFrom<IndexViewModel>(viewResult.ViewData.Model);

            Assert.Equal("First Goal", model.Goal.Name);
        }
    }
}
