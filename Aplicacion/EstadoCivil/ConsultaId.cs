using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.EstadoCivil
{
    public class ConsultaId
    {
        public class EstadoCivilUnico : IRequest<TblCatEstadoCivil>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<EstadoCivilUnico, TblCatEstadoCivil>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatEstadoCivil> Handle(EstadoCivilUnico request, CancellationToken cancellationToken)
            {
                var estado_civil = await _context.TblCatEstadoCivils.FindAsync(request.Id);
                return estado_civil;
            }

        }
    }
}
