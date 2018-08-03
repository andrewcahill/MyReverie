using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Controllers;
using WebMVC.Services;
using WebMVC.ViewModels;
using Microsoft.Extensions.Logging;
using WebMVC.Interfaces;
using WebMVC.ViewModels.GoalViewModels;

namespace UnitTest.Goals.Application
{
    public class GoalControllerTest
    {
        private readonly Mock<IGoalService> _iGoalServiceMock;
        private readonly Mock<ILogger<GoalsController>> _iLoggerMock;

        public GoalControllerTest()
        {
            _iGoalServiceMock = new Mock<IGoalService>();   
            _iLoggerMock = new Mock<ILogger<GoalsController>>();
        }

        [Fact]
        public async Task GetGoal()
        {
            _iGoalServiceMock.Setup(x => x.GetGoals()).Returns(Task.FromResult(
                new List<Goal>()
                {
                    new Goal()
                    {
                        Id = 1,
                        Name = "First Goal"
                    },
                    new Goal()
                    {
                        Id = 2,
                        Name = "Second Goal"
                    },
                    new Goal()
                    {
                        Id = 3,
                        Name = "Third Goal"
                    }
                }));





            GoalsController goalController = new GoalsController(_iGoalServiceMock.Object, _iLoggerMock.Object);

            var actionResult = await goalController.Index();

            var viewResult = Assert.IsType<ViewResult>(actionResult);

            var model = Assert.IsAssignableFrom<IndexViewModel>(viewResult.ViewData.Model);

            Assert.Equal("First Goal", model.Goals[0].Name);
        }
    }
}
