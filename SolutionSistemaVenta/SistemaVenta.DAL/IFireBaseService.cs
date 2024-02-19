using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.BLL.Interfaces
{
    public interface IFireBaseService
    {
        Task<string> DubirStorage(Stream StreamArchivo, string CarpetaDestino, string NombreArchivo);
        Task<string> DubirStorage(string CarpetaDestino, string NombreArchivo);

    }
}
