﻿using Application.Common.GooglePoints;
using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Cidades.Queries.GetMeshesCidadeById
{
    public class GetMeshesCidadesByIdQuery
    {
        public string Id { get; set; }
    }

    public class GetMeshesCidadesByIdQueryHandler : IGetMeshesCidadesByIdQueryHandler
    {
        private readonly IApplicationDbContext _context;

        public GetMeshesCidadesByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Response<CidadeVm> Handle(GetMeshesCidadesByIdQuery request)
        {
            try
            {
                var listEncode = new List<String>();

                var entityPoligonoCidade = _context.PoligonoCidade
                    .Where(x => x.Cidade.Id == request.Id)
                        .Include(e => e.Poligono)
                            .ToList();

                foreach (var polygon in entityPoligonoCidade)
                {
                    var pontoList = new List<Ponto>();

                    var entityPoligono = _context.Poligono
                        .Where(x => x == polygon.Poligono)
                            .ToList()
                                .FirstOrDefault();

                    var entityPoligonoPontos = _context.PoligonoPonto
                        .Where(x => x.Poligono == entityPoligono)
                            .Include(e => e.Ponto)
                                .OrderBy(x => x.Ponto.Count)
                                    .ToList();

                    foreach (var entityPoligonoPonto in entityPoligonoPontos)
                    {
                        pontoList.Add(entityPoligonoPonto.Ponto);
                    }

                    var encodeCoordinate = GooglePoint.EncodeCoordinate(pontoList).Replace(@"\\", @"\");

                    listEncode.Add(encodeCoordinate);
                }

                var cidadeVm = new CidadeVm
                {
                    EncodePoints = listEncode
                };

                return new Response<CidadeVm>(
                    data: cidadeVm,
                    message: "Veja https://developers.google.com/maps/documentation/utilities/polylinealgorithm");
            }
            catch
            {
                return new Response<CidadeVm>(message: $"erro para obter");
            }
        }
    }
}
