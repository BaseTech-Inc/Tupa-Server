﻿using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PontosRisco.Queries.GetPontoRiscoById
{
    public interface IGetPontoRiscoByIdQueryHandler
    {
        Response<PontoRisco> Handle(GetPontoRiscoByIdQuery request);
    }
}
