using api_SIF.dbContexts;
using api_SIF.Models;
using api_SIF.Models.EmpleadosN;
using System.Collections.Generic;

namespace api_SIF.Services.RH
{
    public interface ITurnoService
    {
        public bool insert(TurnoRequest turnoNuevo);
        public turno update(int id, TurnoRequest turnoActualizado);
        public List<turno> getTurnosPorSucursales(string userName);
        public List<turno> getTurnos();

    }
    public class UsuarioService : ITurnoService
    {
        private readonly RHDBContext _dbContext;

        public List<turno> getTurnos()
        {
            throw new System.NotImplementedException();
        }

        public List<turno> getTurnosPorSucursales(string userName)
        {
            throw new System.NotImplementedException();
        }

        public turno update(int id, TurnoRequest turnoActualizado)
        {
            throw new System.NotImplementedException();
        }

        bool ITurnoService.insert(TurnoRequest turnoNuevo)
        {
            throw new System.NotImplementedException();
        }

    }
}
