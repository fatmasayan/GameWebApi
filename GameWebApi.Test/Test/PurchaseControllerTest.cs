using AutoMapper;
using GameWebApi2.Controllers;
using GameWebApi2.Models;
using GameWebApi2.Repository;
using GameWebApi2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq.Expressions;

namespace GameWebApi.Test
{
    public class PurchaseControllerTest
    {
        [Fact]
        public void GetAll_Returns_AllPurchases()
        {
            // Arrange
            var purchases = new List<Purchase> { /* mock purchases */ };
            var purchaseRepositoryMock = new Mock<IPurchaseRepository>();
            purchaseRepositoryMock.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Purchase, object>>>())).Returns(purchases);

            var mapperMock = new Mock<IMapper>();

            var controller = new PurchaseController(purchaseRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<PurchaseViewModel>>(okResult.Value);
            Assert.Equal(purchases.Count, model.Count());
        }
    }
}
