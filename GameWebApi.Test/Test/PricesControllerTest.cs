using AutoMapper;
using GameWebApi2.Controllers;
using GameWebApi2.Models;
using GameWebApi2.Repository;
using GameWebApi2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWebApi.Test;

public class PricesControllerTest
{
    [Fact]
    public void GetAll_Returns_AllPrices()
    {
        // Arrange
        var prices = new List<Prices> { /* mock prices */ };
        var pricesRepositoryMock = new Mock<IPricesRepository>();
        pricesRepositoryMock.Setup(repo => repo.GetAll()).Returns(prices);

        var mapperMock = new Mock<IMapper>();

        var controller = new PricesController(pricesRepositoryMock.Object, mapperMock.Object);

        // Act
        var result = controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<PricesViewModel>>(okResult.Value);
        Assert.Equal(prices.Count, model.Count());
    }
}
