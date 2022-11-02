using Examen1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examen1.Controllers
{
    public class DBContacto
    {
        readonly SQLiteAsyncConnection _conexion;
        // Constructor Vacio
        public DBContacto()
        { }

        // Constructor con parametros
        public DBContacto(String dbpath)
        {
            // Creando una conexion a base de datos sqlite a partir del path de la base de datos
            _conexion = new SQLiteAsyncConnection(dbpath);

            // Crear las tablas correspondientes en la base de datos de sqlite
            _conexion.CreateTableAsync<Models.Contactos>().Wait();
        }

        // CRUD - Aplicaciones 
        // Create

        public Task<int> StoreContac(Models.Contactos contactos)
        {
            if (contactos.Id != 0)
            {
                return _conexion.UpdateAsync(contactos);
            }
            else
            {
                return _conexion.InsertAsync(contactos);
            }
        }
        // Read

        public Task<List<Models.Contactos>> listaContactos()
        {
            return _conexion.Table<Models.Contactos>().ToListAsync();
        }


        public Task<Models.Contactos> getContactos(int pid)
        {
            return _conexion.Table<Models.Contactos>()
                .Where(i => i.Id == pid)
                .FirstOrDefaultAsync();
        }

        public  Task<int> DeleteContactos(Contactos contactos)
        {
            return _conexion.DeleteAsync(contactos);
        }

    }
}
