using MailingList.Controllers;
using MailingList.Models;
using MailingList.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MailingListTests
{
    public class MalingListControllerTest
    {
        [Fact]
        public void FilterDataByLastName()
        {
            //Arrange
            string lastName = "smith";
            var mockService = new Mock<IMailingListService>();
            mockService.Setup(service => service.GetMailingListsAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(GetTestMalingListEntries().Where(c => c.LastName.ToLower().Trim() == lastName));

            var controller = new MailingListController(mockService.Object);

            //Act
            var result = controller.GetMailingList(lastName, null).GetAwaiter().GetResult();

            //Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var retrurnValue = Assert.IsAssignableFrom<IEnumerable<MailingListRecord>>(objectResult.Value);

            Assert.Equal(2, retrurnValue.Count());
        }

        private IEnumerable<MailingListRecord> GetTestMalingListEntries()
        {
            var testListEntries = new List<MailingListRecord> {
                new MailingListRecord() {
                    Id = 1,
                    LastName = "Smith",
                    FirstName = "John",

                },
                new MailingListRecord() {
                    Id = 2,
                    LastName = "Smith",
                    FirstName = "Mary",

                },
                new MailingListRecord() {
                    Id = 3,
                    LastName = "Marshall",
                    FirstName = "Charlie",

                },
            };

            return testListEntries;
        }
    }
}
