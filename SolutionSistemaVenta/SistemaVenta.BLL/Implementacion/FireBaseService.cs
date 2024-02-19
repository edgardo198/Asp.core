using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Storage;
using SistemaVenta.BLL.Interfaces;
using SistemaVenta.DAL.Interfaces;
using SistemaVenta.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.BLL.Implementacion
{
    public class FireBaseService : IFireBaseService
    {
        private readonly IGenericRepository<Configuracion> _repositorio;

        public FireBaseService(IGenericRepository<Configuracion> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<string> SubirStorage(Stream StreamArchivo, string CarpetaDestino, string NombreArchivo)
        {
            string UrlImagen = "";
            try
            {
                IQueryable<Configuracion> query = await _repositorio.Consultar(c => c.Recurso.Equals("FireBase_Storage"));
                Dictionary<string, string> Conf = query.ToDictionary(keySelector: c => c.Propiedad, elementSelector: c => c.Valor);

                var auth = new FirebaseAuthProvider(new FirebaseConfig(Conf["api_key"]));
                var a = await auth.SignInWithEmailAndPasswordAsync(Conf["email"], Conf["clave"]);

                var cancellation = new CancellationTokenSource();

                var task = new FirebaseStorage(
                    Conf["ruta"],
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                        ThrowOnCancel = true
                    })
                    .Child(Conf[CarpetaDestino])
                    .Child(NombreArchivo)
                    .PutAsync(StreamArchivo, cancellation.Token);

                UrlImagen = await task;
            }
            catch
            {
                UrlImagen = "";
            }
            return UrlImagen;

        }

        public async Task<bool> EliminarStorage(string CarpetaDestino, string NombreArchivo)
        {
            try
            {
                IQueryable<Configuracion> query = await _repositorio.Consultar(c => c.Recurso.Equals("FireBase_Storage"));
                Dictionary<string, string> Conf = query.ToDictionary(keySelector: c => c.Propiedad, elementSelector: c => c.Valor);

                var auth = new FirebaseAuthProvider(new FirebaseConfig(Conf["api_key"]));
                var a = await auth.SignInWithEmailAndPasswordAsync(Conf["email"], Conf["clave"]);

                var cancellation = new CancellationTokenSource();

                var task = new FirebaseStorage(
                    Conf["ruta"],
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                        ThrowOnCancel = true
                    })
                    .Child(Conf[CarpetaDestino])
                    .Child(NombreArchivo)
                    .DeleteAsync();

                await task;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    }

