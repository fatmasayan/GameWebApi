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

namespace GameWebApi.Test
{
    public class MapControllerTest
    {
        [Fact]
        public void GetAll_Returns_AllMaps()
        {
            // Arrange
            var maps = new List<Map> { /* mock maps */ };
            var mapRepositoryMock = new Mock<IMapRepository>();
            mapRepositoryMock.Setup(repo => repo.GetAll()).Returns(maps);

            var mapperMock = new Mock<IMapper>();

            var controller = new MapController(mapRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<MapViewModel>>(okResult.Value);
            Assert.Equal(maps.Count, model.Count());
        }
    }
}
