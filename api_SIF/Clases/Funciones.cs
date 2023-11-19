using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace api_SIF.Clases
{
    public class Funciones
    {
        public static string HoraAString(TimeOnly hora)
        {
            return hora.ToString("HH:mm:ss");
        }
        public static int ObtenerUltimoId<T>(DbContext dbContext) where T : class
        {
            var tableName = dbContext.Model.FindEntityType(typeof(T)).GetTableName();
            var primaryKeyColumnName = dbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties
                .Select(x => x.Name)
                .SingleOrDefault();

            if (primaryKeyColumnName != null)
            {
                var ultimoId = dbContext.Set<T>().Max(t => EF.Property<int>(t, primaryKeyColumnName));
                return ultimoId;
            }

            return -1; // Otra manera de manejar el caso donde no se puede determinar la clave primaria
        }
    }
}
