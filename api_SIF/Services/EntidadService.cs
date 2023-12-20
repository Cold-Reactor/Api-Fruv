using api_SIF.dbContexts;
using System.Linq;

namespace api_SIF.Services
{
    // En Services/EntidadService.cs

    public class EntidadService
    {
        private readonly RHDBContext dbContext;

        public EntidadService(RHDBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void ActualizarEntidad<TModelo>(TModelo modelo) where TModelo : class
        {
            // Obtener la entidad existente desde la base de datos
            var entidadExistente = dbContext.Set<TModelo>().Find(ObtenerValorClavePrimaria(modelo));

            if (entidadExistente != null)
            {
                // Adjuntar la entidad existente al contexto de Entity Framework
                dbContext.Attach(entidadExistente);

                // Iterar sobre las propiedades del modelo
                foreach (var propiedad in modelo.GetType().GetProperties())
                {
                    // Obtener el valor de la propiedad del modelo
                    var valorPropiedad = propiedad.GetValue(modelo);

                    // Si el valor no es nulo, "" o 0 y no es la propiedad de la clave primaria, actualizar la propiedad en la entidad existente
                    if (valorPropiedad != null && !valorPropiedad.Equals("") && propiedad.Name != ObtenerNombreClavePrimaria<TModelo>())
                    {
                        // Marcar la propiedad como modificada para que se actualice en la base de datos
                        dbContext.Entry(entidadExistente).Property(propiedad.Name).IsModified = true;
                        dbContext.Entry(entidadExistente).Property(propiedad.Name).CurrentValue = valorPropiedad;
                    }
                    // Si la propiedad es la clave primaria y su valor es cero, generarlo automáticamente
                    else if (propiedad.Name == ObtenerNombreClavePrimaria<TModelo>() && valorPropiedad is int && (int)valorPropiedad == 0)
                    {
                        // Generar un nuevo valor para la propiedad de la clave primaria (puedes ajustar esto según tus necesidades)
                        dbContext.Entry(entidadExistente).Property(propiedad.Name).IsModified = true;
                       // dbContext.Entry(entidadExistente).Property(propiedad.Name).CurrentValue = GenerarNuevoId();
                    }
                }

                // Guardar los cambios en la base de datos
                dbContext.SaveChanges();
            }
        }
        private object ObtenerValorClavePrimaria<TModelo>(TModelo modelo) where TModelo : class
        {
            var entityType = dbContext.Model.FindEntityType(typeof(TModelo));
            var primaryKey = entityType.FindPrimaryKey();

            // Asumimos que solo hay una propiedad en la clave primaria para simplificar
            var primaryKeyPropertyName = primaryKey.Properties.Single().Name;

            return modelo.GetType().GetProperty(primaryKeyPropertyName)?.GetValue(modelo);
        }

        private string ObtenerNombreClavePrimaria<TModelo>() where TModelo : class
        {
            var entityType = dbContext.Model.FindEntityType(typeof(TModelo));
            var primaryKey = entityType.FindPrimaryKey();

            // Asumimos que solo hay una propiedad en la clave primaria para simplificar
            return primaryKey.Properties.Single().Name;
        }
    }

}
