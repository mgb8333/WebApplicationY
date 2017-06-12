using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using WebApplicationY.Controllers;
using Moq;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net.Http;

namespace WebApplicationY.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IMessageItemRepository> mock;
        [TestInitialize]
        public void Setup()
        {
            mock = new Mock<IMessageItemRepository>();
            mock.Setup(m => m.GetAllMessages()).Returns(new List<MessageItem> {
                new MessageItem {
                    Id = 1,
                    MessageType = (int)Domain.Enums.ApplicationEnums.MessageTypes.Console,
                    MessageText = "First Mocked Message"
                },
                new MessageItem {
                    Id = 2,
                    MessageType = (int)Domain.Enums.ApplicationEnums.MessageTypes.Webpage,
                    MessageText = "Second Mocked Message"
                },
                new MessageItem {
                    Id = 3,
                    MessageType = (int)Domain.Enums.ApplicationEnums.MessageTypes.Unspecified,
                    MessageText = "Third Mocked Message"
                },
                new MessageItem {
                    Id = 4,
                    MessageType = (int)Domain.Enums.ApplicationEnums.MessageTypes.Webpage,
                    MessageText = "Fourth Mocked Message"
                }
            }.AsEnumerable());
            mock.Setup(m => m.GetById(3)).Returns(
                new MessageItem
                {
                    Id = 3,
                    MessageType = (int)Domain.Enums.ApplicationEnums.MessageTypes.Unspecified,
                    MessageText = "Third Mocked Message"
                }
            );
        }

        [TestMethod]
        public void GetReturnsMessageItem()
        {
            // Arrange
            int itemId = 3;
            var controller = new MessageController(mock.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            IHttpActionResult actionResult = controller.GetMessageItem(itemId);
            var contentResult = actionResult as OkNegotiatedContentResult<MessageItem>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(itemId, contentResult.Content.Id);
        }
    }
}
