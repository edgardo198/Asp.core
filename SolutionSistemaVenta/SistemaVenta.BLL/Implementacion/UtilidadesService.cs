using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenta.BLL.Interfaces;
using System.Security.Cryptography;
using System.Linq.Expressions;

namespace SistemaVenta.BLL.Implementacion
{
    public class UtilidadesService : IUtilidadesService
    {
      
        public string GenerarCleve()
        {
            string clave =Guid.NewGuid().ToString("N").Substring(0,6);
            return clave;

        }

        public string ConvertirSha256(string texto)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding encoding= Encoding.UTF8;
                byte[] result = hash.ComputeHash(encoding.GetBytes(texto));

                foreach(byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }

            }
            return sb.ToString();   
        }
    }
}
