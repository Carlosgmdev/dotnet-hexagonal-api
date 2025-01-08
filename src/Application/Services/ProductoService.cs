using System.Collections.Generic;
using Api.Domain.Entities;
using Api.Domain.Interfaces;


namespace Api.Application.Services
{


    public class ProductoService
    {


        private readonly IProductoRepository _productoRepository;



        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }



        public IEnumerable<Producto> ObtenerProductos() => _productoRepository.GetAll();


        public Producto ObtenerProductoPorId(int id) => _productoRepository.GetById(id);


        public void CrearProducto(Producto producto) => _productoRepository.Add(producto);


        public void ActualizarProducto(Producto producto) => _productoRepository.Update(producto);


        public void EliminarProducto(int id) => _productoRepository.Delete(id);

    
    }


}