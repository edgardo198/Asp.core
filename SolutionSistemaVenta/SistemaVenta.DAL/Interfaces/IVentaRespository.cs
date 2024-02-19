using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenta.Entity;

namespace SistemaVenta.DAL.Interfaces
{
    public interface IVentaRespository: IGenericRepository<Venta>
    {
        Task<Venta> Registrar(Venta Entidad);

        Task<List<DetalleVenta>> Reporte(DateTime FechaInicio, DateTime FechaFin);

    }
}
