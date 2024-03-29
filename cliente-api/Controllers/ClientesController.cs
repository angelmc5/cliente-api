﻿using AutoMapper;
using cliente_api.Modelos;
using cliente_api.Modelos.Dtos;
using cliente_api.Repositorio;
using cliente_api.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cliente_api.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepositorio _cliRepo;
        private readonly IMapper _mapper;

        public ClientesController(IClienteRepositorio cliRepo, IMapper mapper)
        {
            _cliRepo = cliRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetClientes()
        {
            try
            {
                var listaClientes = _cliRepo.GetClientes();

                var listaClientesDto = new List<ClienteDto>();

                foreach (var item in listaClientes)
                {
                    listaClientesDto.Add(_mapper.Map<ClienteDto>(item));
                }
                return Ok(listaClientesDto);
            }
            catch (RepositoryException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Manejo de otras excepciones
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("{id:int}", Name = "GetCliente")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCliente(int id)
        {
            try
            {
                var itemCliente = _cliRepo.GetCliente(id);

                if (itemCliente == null)
                {
                    return NotFound();
                }
                var itemClienteDto = _mapper.Map<ClienteDto>(itemCliente);
                return Ok(itemClienteDto);
            }
            catch (RepositoryException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Manejo de otras excepciones
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ClienteDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CrearCliente([FromBody] CrearClienteDto crearClienteDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (crearClienteDto == null)
                {
                    return BadRequest(ModelState);
                }

                if (_cliRepo.ExisteCliente(crearClienteDto.Identificacion))
                {
                    ModelState.AddModelError("", "La identificación ya existe");
                    return StatusCode(404, ModelState);
                }
                var cliente = _mapper.Map<Cliente>(crearClienteDto);
                if (!_cliRepo.CrearCliente(cliente))
                {
                    ModelState.AddModelError("", $"Algo salió mail guardando el resgistro {cliente.Nombre}!");
                    return StatusCode(500, ModelState);

                }
                return CreatedAtRoute("GetCliente", new { id = cliente.Id }, cliente);
            }
            catch (RepositoryException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Manejo de otras excepciones
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPatch("{id:int}", Name = "ActualizarPatchCliente")]
        [ProducesResponseType(201, Type = typeof(ClienteDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarPatchCliente(int id, [FromBody] ClienteDto clienteDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (clienteDto == null || id != clienteDto.Id)
                {
                    return BadRequest(ModelState);
                }

                var cliente = _mapper.Map<Cliente>(clienteDto);
                if (!_cliRepo.ActualizarCliente(cliente))
                {
                    ModelState.AddModelError("", $"Algo salió mail actualizando el resgistro {cliente.Nombre}!");
                    return StatusCode(500, ModelState);

                }
                return NoContent();
            }
            catch (RepositoryException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Manejo de otras excepciones
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}", Name = "EliminarCliente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult EliminarCliente(int id)
        {
            try
            {
                if (!_cliRepo.ExisteCliente(id))
                {
                    return NotFound();
                }

                var cliente = _cliRepo.GetCliente(id);

                if (!_cliRepo.BorrarCliente(cliente))
                {
                    ModelState.AddModelError("", $"Algo salió mail eliminando el resgistro {cliente.Nombre}!");
                    return StatusCode(500, ModelState);

                }
                return NoContent();
            }
            catch (RepositoryException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Manejo de otras excepciones
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
