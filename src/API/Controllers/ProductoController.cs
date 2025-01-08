using Microsoft.AspNetCore.Mvc;
using Api.Application.Services;
using Api.Domain.Entities;


namespace Api.API.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {


        private readonly ProductoService _productoService;


        public ProductoController(ProductoService productoService)
        {
            _productoService = productoService;
        }


        [HttpGet]
        public IActionResult GetAll() => Ok(_productoService.ObtenerProductos());


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var producto = _productoService.ObtenerProductoPorId(id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }


        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            _productoService.CrearProducto(producto);
            return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Producto producto)
        {
            producto.Id = id;
            _productoService.ActualizarProducto(producto);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productoService.EliminarProducto(id);
            return NoContent();
        }


    }


}