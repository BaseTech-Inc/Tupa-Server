using Application.Common.Models;
using Application.Marcador.Commands.CreateMarcadores;
using Application.Marcador.Commands.DeleteMarcadores;
using Application.Marcador.Commands.UpdateMarcadores;
using Application.Marcador.Queries.GetAllMarcadores;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [Authorize]
    public class MarcadoresController : ApiControllerBase
    {
        public MarcadoresController()
        { }

        // GET: api/Marcadores/
        [HttpGet]
        public async Task<ActionResult<Response<IList<Marcadores>>>> Get(
            [FromServices] IGetAllMarcadoresQueryHandler handler,
            [FromQuery] GetAllMarcadoresQuery command
        )
        {
            var response = handler.Handle(command);

            if (!response.Succeeded)
            {
                return NotFound();
            }

            return Ok(
                response
                );
        }

        // POST: api/Marcadores/?latitude=latitude&longitude=longitude&Nome=Nome
        [HttpPost]
        public async Task<ActionResult<Response<string>>> Create(
            [FromServices] ICreateMarcadoresCommandHandler handler,
            [FromQuery] CreateMarcadoresCommand command
        )
        {
            var response = await handler.Handle(command);

            if (!response.Succeeded)
            {
                return NotFound();
            }

            return Created(
                HttpRequestHeader.Referer.ToString(),
                response
                );
        }

        // DELETE: api/Marcadores/?Id=Id
        [HttpDelete]
        public async Task<ActionResult<Response<string>>> Delete(
            [FromServices] IDeleteMarcadoresCommandHandler handler,
            [FromQuery] DeleteMarcadoresCommand command
        )
        {
            var response = await handler.Handle(command);

            if (!response.Succeeded)
            {
                return NotFound();
            }

            return Ok(
                response
                );
        }

        // UPDATE: api/Marcadores/?Id=Id&latitude=latitude&longitude=longitude&Nome=Nome
        [HttpPut]
        public async Task<ActionResult<Response<string>>> Update(
            [FromServices] IUpdateMarcadoresCommandHandler handler,
            [FromQuery] UpdateMarcadoresCommand command
        )
        {
            var response = await handler.Handle(command);

            if (!response.Succeeded)
            {
                return NotFound();
            }

            return Created(
                HttpRequestHeader.Referer.ToString(),
                response
                );
        }
    }
}
