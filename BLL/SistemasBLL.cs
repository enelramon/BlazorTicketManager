using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketManager.DAL;
using TicketManager.Models;

namespace TicketManager.BLL
{
    public class SistemasBLL
    {
        private readonly TicketContext _contexto;

        public SistemasBLL(TicketContext contexto)
        {
            _contexto = contexto;
        }

        public bool Guardar(Sistemas Sistema)
        {
            
            if (!Existe(Sistema.SistemaId))
                return Insertar(Sistema);
            else
                return Modificar(Sistema);
        }

        public bool Existe(int SistemaId)
        {
            return _contexto.Sistemas.Any(s => s.SistemaId == SistemaId);
        }

        private bool Insertar(Sistemas Sistema)
        {
            _contexto.Sistemas.Add(Sistema);
            int cantidad = _contexto.SaveChanges();
            return cantidad > 0;
        }

        public bool Modificar(Sistemas Sistema)
        {
            _contexto.Update(Sistema);
            int cantidad = _contexto.SaveChanges();
            return cantidad > 0;
        }

        public bool Eliminar(Sistemas Sistema)
        {
            _contexto.Sistemas.Remove(Sistema);
            int cantidad = _contexto.SaveChanges();
            return cantidad > 0;
        }

        public Sistemas? Buscar(int SistemaId)
        {
            return _contexto.Sistemas
                .AsNoTracking()
                .FirstOrDefault(s => s.SistemaId == SistemaId);
        }


        public List<Sistemas> GetListWithCriterion(Expression<Func<Sistemas, bool>> Criterio)
        {
            return _contexto.Sistemas
                .Where(Criterio)
                .AsNoTracking()
                .ToList();
        }

        public List<Sistemas> GetList()
        {
            return _contexto.Sistemas
            .AsNoTracking()
            .ToList();
        }
        
    }
}
