﻿using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Localidades.Queries.GetLocalidadesByNames
{
    public interface IGetLocalidadeByNameQueryHandler
    {
        Response<IList<Distrito>> Handle(GetLocalidadesByNameQuery request);
    }
}
