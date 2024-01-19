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
                .FirstOrDefault();

            //if (primaryKeyColumnName != null)
            //{
            //    var ultimoId = dbContext.Set<T>().Max(t => EF.Property<int>(t, primaryKeyColumnName));
            //    return ultimoId;
            //}
            if (primaryKeyColumnName != null)
            {
                var set = dbContext.Set<T>();
                if (set.Any())
                {
                    var ultimoId = set.Max(t => EF.Property<int>(t, primaryKeyColumnName));
                    return ultimoId;
                }
            }

            return -1; 
        }
        

    }
}
