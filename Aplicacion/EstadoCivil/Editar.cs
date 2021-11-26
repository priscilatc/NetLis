using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.EstadoCivil
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdEstadoCivil { get; set; }
            public string Descripcion { get; set; }
            public int Estado { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var estado_civil = await _context.TblCatEstadoCivils.FindAsync(request.IdEstadoCivil);
                if (estado_civil == null)
                {
                    throw new Exception("El estado civil no está en el sistema");
                }

                estado_civil.Descripcion = request.Descripcion ?? estado_civil.Descripcion;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el estado civil");
            }

        }
    }
}
