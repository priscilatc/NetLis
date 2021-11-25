﻿using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Pais
{
    public class ConsultaId
    {
        public class PaisUnico : IRequest<TblCatPais>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<PaisUnico, TblCatPais>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatPais> Handle(PaisUnico request, CancellationToken cancellationToken)
            {
                var pais = await _context.TblCatPais.FindAsync(request.Id);
                return pais;
            }

        }
    }
}
