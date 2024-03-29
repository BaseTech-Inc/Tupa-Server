﻿using Application.Common.Interfaces;
using Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [Authorize]
    public class CurrentWeatherController : ApiControllerBase
    {
        private readonly IOpenWeatherService _openWeatherService;

        public CurrentWeatherController(
            IOpenWeatherService openWeatherService)
        {
            _openWeatherService = openWeatherService;
        }

        // GET: api/v1/CurrentWeather/coord
        [HttpGet("coord")]
        public async Task<ActionResult<Response<CurrentWeatherResponse>>> GetByCoord(
            float lat,
            float lon)
        {
            var response = await _openWeatherService.ProcessCurrentByCoord(lat, lon);

            if (!response.Succeeded)
            {
                return BadRequest(response);
            }

            return Ok(
                response
                );
        }

        // GET: api/v1/CurrentWeather/name
        [HttpGet("name")]
        public async Task<ActionResult<Response<CurrentWeatherResponse>>> GetByName(
            string street,
            string district,
            string city,
            string state)
        {
            var response = await _openWeatherService.ProcessCurrentByName(street, district, city, state);

            if (!response.Succeeded)
            {
                return BadRequest(response);
            }

            return Ok(
                response
                );
        }
    }
}
