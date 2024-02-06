using AutoMapper;
using cliente_api.Controllers;
using cliente_api.Modelos;
using cliente_api.Modelos.Dtos;
using cliente_api.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Clientes.UnitTest.API
{
    public class ClientesControllerTests
    {
        private Mock<IClienteRepositorio> _clienteRepositorioMock;
        private Mock<IMapper> _mapper;
        private ClientesController _clienteController;

        [SetUp]
        public void Setup()
        {
            _clienteRepositorioMock = new Mock<IClienteRepositorio>();
            _mapper = new Mock<IMapper>();
            _clienteController = new ClientesController(_clienteRepositorioMock.Object, _mapper.Object);

        }

        [Test]
        public void Get_Clientes()
        {
            // Arrange
            var clientes = new List<Cliente>
            {
                new Cliente { Id = 1, Nombre = "Angel Morocho", Genero = "M", Edad = 44,Identificacion="0705337889",Direccion="El Batan n34-41 y Eloy Alfaro", Telefono ="098333445",Contrasena="12345",Estado = true },
                new Cliente { Id = 2, Nombre = "José Mejia", Genero = "M", Edad = 44,Identificacion="0784333778",Direccion="Shiris y Suecia", Telefono ="0983336737",Contrasena="test123",Estado = true }
            };

            _clienteRepositorioMock.Setup(repo => repo.GetClientes()).Returns(clientes);

            // Act
            var result = _clienteController.GetClientes();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okObjectResult = (OkObjectResult)result;
            Assert.NotNull(okObjectResult);

            var model = (IEnumerable<ClienteDto>)okObjectResult.Value;
            Assert.NotNull(model);
            Assert.That(model.Count(), Is.EqualTo(clientes.Count));
        }
    }
}