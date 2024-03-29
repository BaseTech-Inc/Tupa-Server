﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;

namespace Application.Cidades.Queries.GetCidadesByName
{
    public class GetCidadesByNameQuery
    {
        public string name { get; set; }
    }

    public class GetCidadesByNameQueryHandler : IGetCidadesByNameQueryHandler
    {
        private readonly IApplicationDbContext _context;

        public GetCidadesByNameQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Response<IList<Cidade>> Handle(GetCidadesByNameQuery request)
        {
            try
            {
                var entity = _context.Cidade.Where(x => EF.Functions.Like(x.Nome, "%" + request.name + "%")).Include(e => e.Estado).Include(e => e.Estado.Pais).ToList();

                return new Response<IList<Cidade>>(data: entity);
            }
            catch
            {
                return new Response<IList<Cidade>>(message: $"erro para obter");
            }
        }
    }
}
