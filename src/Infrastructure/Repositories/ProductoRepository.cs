using System.Collections.Generic;
using System.Linq;
using Api.Domain.Entities;
using Api.Domain.Interfaces;


namespace Api.Infrastructure.Repositories
{


    public class ProductoRepository : IProductoRepository
    {


        private readonly List<Producto> _productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Producto 1", Precio = 100 },
            new Producto { Id = 2, Nombre = "Producto 2", Precio = 200 },
            new Producto { Id = 3, Nombre = "Producto 3", Precio = 300 },
            new Producto { Id = 4, Nombre = "Producto 4", Precio = 400 },
            new Producto { Id = 5, Nombre = "Producto 5", Precio = 500 }
        };


        public IEnumerable<Producto> GetAll() => _productos;


        public Producto GetById(int id) => _productos.FirstOrDefault(p => p.Id == id);


        public void Add(Producto producto)
        {
            producto.Id = _productos.Max(p => p.Id) + 1;
            _productos.Add(producto);
        }


        public void Update(Producto producto)
        {
            var index = _productos.FindIndex(p => p.Id == producto.Id);
            if (index >= 0)
                _productos[index] = producto;
        }


        public void Delete(int id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto != null) _productos.Remove(producto);
        }


    }


}