using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.OrdenDetalles
{
    public class ConsultaExamen
    {
        public class ConsultaExamenUnico : IRequest<List<TblOrdenesDetalle>>
        {
            public Guid Examen { get; set; }
        }

        public class Manejador : IRequestHandler<ConsultaExamenUnico, List<TblOrdenesDetalle>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<List<TblOrdenesDetalle>> Handle(ConsultaExamenUnico request, CancellationToken cancellationToken)
            {
                var ordenes_det = await _context.TblOrdenesDetalles.Where(x => x.IdExamen == request.Examen).ToListAsync();
                return ordenes_det;
            }
        }
    }
}
