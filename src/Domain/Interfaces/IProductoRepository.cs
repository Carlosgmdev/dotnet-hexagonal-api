using System.Collections.Generic;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IProductoRepository
    {
        IEnumerable<Producto> GetAll();
        Producto GetById(int id);
        void Add(Producto producto);
        void Update(Producto producto);
        void Delete(int id);
    }
}