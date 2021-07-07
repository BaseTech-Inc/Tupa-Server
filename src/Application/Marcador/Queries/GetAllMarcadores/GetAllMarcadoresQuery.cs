﻿using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Marcador.Queries.GetAllMarcadores
{
    public class GetAllMarcadoresQuery
    {
        public string UserId { get; set; }
    }

    public class GetAllMarcadoresQueryHandler : IGetAllMarcadoresQueryHandler
    {
        private readonly IApplicationDbContext _context;

        public GetAllMarcadoresQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Response<IList<Marcadores>> Handle(GetAllMarcadoresQuery request)
        {
            try
            {
                var entityUsuario = _context.Usuario.Where(x => x.Id == request.UserId).FirstOrDefault();

                var entity = _context.Marcadores.Where(x => x.Usuario == entityUsuario).ToList();

                return new Response<IList<Marcadores>>(data: entity);
            }
            catch
            {
                return new Response<IList<Marcadores>>(message: $"error to get");
            }
        }
    }
}
