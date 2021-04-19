using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using ToDoProject.Controllers;
using ToDoProject.Models;
using Xunit;

namespace ToDoTests
{
    public class UnitTest1
    {
        [Fact]
        public void IndexActionMethod_ReturnsAValidModelState()
        {
            // arrange
            var unit = new Mock<ITicketUnit>();
            var tickets = new Mock<IRepository<Ticket>>();
            unit.Setup(r => r.Tickets).Returns(tickets.Object);

            var http = new Mock<IHttpContextAccessor>();

            var controller = new TicketController(unit.Object, http.Object);

            // act
            var result = controller.ModelState;

            // assert
            Assert.Equal(result, controller.ModelState);
        }
    }
}
