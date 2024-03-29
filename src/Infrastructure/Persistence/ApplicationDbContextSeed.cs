﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static Infrastructure.AdministrativeDivision.DivisionLocation;
using Application.Common.Enumerations;
using Application.Common.Interfaces;
using Application.GeoJson;
using Application.GeoJson.Features;
using Application.GeoJson.Geometry;
using Domain.Entities;
using Domain.Enumerations;
using Infrastructure.Identity;
using Application.Common.GooglePoints;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            var managerRole = new IdentityRole(Roles.Manager.ToString());

            if (roleManager.Roles.All(r => r.Name != managerRole.Name))
            {
                await roleManager.CreateAsync(managerRole);
            }

            var employeeRole = new IdentityRole(Roles.Employee.ToString());

            if (roleManager.Roles.All(r => r.Name != employeeRole.Name))
            {
                await roleManager.CreateAsync(employeeRole);
            }

            #region usuario manager
            var listUsuarioManager = new List<Usuario>();

            var usuarioManager = new Usuario
            {
                Email = "manager@localhost",
                TipoUsuario = new TipoUsuario
                {
                    Descricao = EnumTipoUsuario.Premium
                },
                Nome = "manager@localhost"
            };

            listUsuarioManager.Add(usuarioManager);

            var manager = new ApplicationUser { 
                UserName = "manager@localhost", 
                Email = "manager@localhost",
                Usuario = listUsuarioManager
            };

            if (
                userManager.Users.All(u => u.UserName != manager.UserName) &&
                userManager.Users.All(u => u.Email != manager.Email))
            {
                await userManager.CreateAsync(manager, "P@assw0rd");
                await userManager.AddToRolesAsync(manager, new[] { managerRole.Name });

                var token = await userManager.GenerateEmailConfirmationTokenAsync(manager);
                await userManager.ConfirmEmailAsync(manager, token);
            }
            #endregion

            #region usuario discord
            var listUsuarioDiscord = new List<Usuario>();

            var usuarioDiscord = new Usuario
            {
                Email = "discord@localhost",
                TipoUsuario = new TipoUsuario
                {
                    Descricao = EnumTipoUsuario.Premium
                },
                Nome = "discord@localhost"
            };

            listUsuarioDiscord.Add(usuarioDiscord);

            var discord = new ApplicationUser
            {
                UserName = "discord@localhost",
                Email = "discord@localhost",
                Usuario = listUsuarioDiscord
            };

            if (
                userManager.Users.All(u => u.UserName != discord.UserName) &&
                userManager.Users.All(u => u.Email != discord.Email))
            {
                await userManager.CreateAsync(discord, "P@assw0rd");
                await userManager.AddToRolesAsync(discord, new[] { employeeRole.Name });

                var token = await userManager.GenerateEmailConfirmationTokenAsync(discord);
                await userManager.ConfirmEmailAsync(discord, token);
            }
            #endregion
        }

        public static async Task SeedDefaultPontosRiscoAsync(
            ApplicationDbContext context,
            ILogger logger)
        {
            if (!context.PontoRisco.Any())
            {
                logger.LogInformation("PontoRisco Informations Seed");

                var listPontoRisco = new List<PontoRisco>()
                {
                    new PontoRisco { Descricao = "Avenida Antônio Munhoz Bonilha", Ponto = new Ponto { Latitude = -23.499512255206376, Longitude = -46.683796270303695 }, Distrito = context.Distrito.Where(x => EF.Functions.Like(x.Nome, "%" + "Limão" + "%")).Where(x => EF.Functions.Like(x.Cidade.Nome, "%" + "São Paulo" + "%")).Where(x => EF.Functions.Like(x.Cidade.Estado.Nome, "%" + "São Paulo" + "%")).Where(x => EF.Functions.Like(x.Cidade.Estado.Pais.Nome, "%" + "Brasil" + "%")).Include(e => e.Cidade).Include(e => e.Cidade.Estado).Include(e => e.Cidade.Estado.Pais).OrderByDescending(o => o.Nome).ToList().FirstOrDefault() },
                    new PontoRisco { Descricao = "Rua Ricardo Cavatton", Ponto = new Ponto { Latitude = -23.51154577099006, Longitude = -46.702789758619346 }, Distrito = context.Distrito.Where(x => EF.Functions.Like(x.Nome, "%" + "Água Branca" + "%")).Where(x => EF.Functions.Like(x.Cidade.Nome, "%" + "São Paulo" + "%")).Where(x => EF.Functions.Like(x.Cidade.Estado.Nome, "%" + "São Paulo" + "%")).Where(x => EF.Functions.Like(x.Cidade.Estado.Pais.Nome, "%" + "Brasil" + "%")).Include(e => e.Cidade).Include(e => e.Cidade.Estado).Include(e => e.Cidade.Estado.Pais).OrderByDescending(o => o.Nome).ToList().FirstOrDefault() },
                    new PontoRisco { Descricao = "Avenida Sumaré", Ponto = new Ponto { Latitude = -23.5291898, Longitude = -46.6791973 }, Distrito = context.Distrito.Where(x => EF.Functions.Like(x.Nome, "%" + "Sumaré" + "%")).Where(x => EF.Functions.Like(x.Cidade.Nome, "%" + "São Paulo" + "%")).Where(x => EF.Functions.Like(x.Cidade.Estado.Nome, "%" + "São Paulo" + "%")).Where(x => EF.Functions.Like(x.Cidade.Estado.Pais.Nome, "%" + "Brasil" + "%")).Include(e => e.Cidade).Include(e => e.Cidade.Estado).Include(e => e.Cidade.Estado.Pais).OrderByDescending(o => o.Nome).ToList().FirstOrDefault() },
                    new PontoRisco { Descricao = "Marginal Pinheiros", Ponto = new Ponto { Latitude = -23.5652793, Longitude = -46.7027212 } },
                    new PontoRisco { Descricao = "Rua Maria Antonia", Ponto = new Ponto { Latitude = -23.546291599953275, Longitude = -46.65101229874567 }, Distrito = context.Distrito.Where(x => EF.Functions.Like(x.Nome, "%" + "Consolação" + "%")).Where(x => EF.Functions.Like(x.Cidade.Nome, "%" + "São Paulo" + "%")).Where(x => EF.Functions.Like(x.Cidade.Estado.Nome, "%" + "São Paulo" + "%")).Where(x => EF.Functions.Like(x.Cidade.Estado.Pais.Nome, "%" + "Brasil" + "%")).Include(e => e.Cidade).Include(e => e.Cidade.Estado).Include(e => e.Cidade.Estado.Pais).OrderByDescending(o => o.Nome).ToList().FirstOrDefault() },
                    new PontoRisco { Descricao = "Rua Caio Prado", Ponto = new Ponto { Latitude = -23.549035278846254, Longitude = -46.64859688222123 }, Distrito = context.Distrito.Where(x => EF.Functions.Like(x.Nome, "%" + "Consolação" + "%")).Where(x => EF.Functions.Like(x.Cidade.Nome, "%" + "São Paulo" + "%")).Where(x => EF.Functions.Like(x.Cidade.Estado.Nome, "%" + "São Paulo" + "%")).Where(x => EF.Functions.Like(x.Cidade.Estado.Pais.Nome, "%" + "Brasil" + "%")).Include(e => e.Cidade).Include(e => e.Cidade.Estado).Include(e => e.Cidade.Estado.Pais).OrderByDescending(o => o.Nome).ToList().FirstOrDefault() },
                    new PontoRisco { Descricao = "Corredor Norte-Sul", Ponto = new Ponto { Latitude = -23.5488099, Longitude = -46.639034 } },
                    new PontoRisco { Descricao = "Rua São Francisco", Ponto = new Ponto { Latitude = -23.549059644370665, Longitude = -46.63796092457814 }, Distrito = context.Distrito.Where(x => EF.Functions.Like(x.Nome, "%" + "Sé" + "%")).Where(x => EF.Functions.Like(x.Cidade.Nome, "%" + "São Paulo" + "%")).Where(x => EF.Functions.Like(x.Cidade.Estado.Nome, "%" + "São Paulo" + "%")).Where(x => EF.Functions.Like(x.Cidade.Estado.Pais.Nome, "%" + "Brasil" + "%")).Include(e => e.Cidade).Include(e => e.Cidade.Estado).Include(e => e.Cidade.Estado.Pais).OrderByDescending(o => o.Nome).ToList().FirstOrDefault() },
                    new PontoRisco { Descricao = "Avenida do Estado", Ponto = new Ponto { Latitude = -23.55043198166717, Longitude = -46.626502326549996 } },
                    new PontoRisco { Descricao = "Avenida Aricanduva", Ponto = new Ponto { Latitude = -23.5637057, Longitude = -46.5136243 } },
                    new PontoRisco { Descricao = "Avenida Professor Luiz Ignácio Anhaia Mello", Ponto = new Ponto { Latitude = -23.581698347704315, Longitude = -46.56167553310564 }, Distrito = context.Distrito.Where(x => EF.Functions.Like(x.Nome, "%" + "Vila Prudente" + "%")).Where(x => EF.Functions.Like(x.Cidade.Nome, "%" + "São Paulo" + "%")).Where(x => EF.Functions.Like(x.Cidade.Estado.Nome, "%" + "São Paulo" + "%")).Where(x => EF.Functions.Like(x.Cidade.Estado.Pais.Nome, "%" + "Brasil" + "%")).Include(e => e.Cidade).Include(e => e.Cidade.Estado).Include(e => e.Cidade.Estado.Pais).OrderByDescending(o => o.Nome).ToList().FirstOrDefault() },
                    new PontoRisco { Descricao = "Avenida Alcântara Machado", Ponto = new Ponto { Latitude = -23.54435799265057, Longitude = -46.5931803832838 } },
                    new PontoRisco { Descricao = "Avenida Celso Garcia", Ponto = new Ponto { Latitude = -23.53666103385123, Longitude = -46.58914367537825 }, Distrito = context.Distrito.Where(x => EF.Functions.Like(x.Nome, "%" + "Belém" + "%")).Where(x => EF.Functions.Like(x.Cidade.Nome, "%" + "São Paulo" + "%")).Where(x => EF.Functions.Like(x.Cidade.Estado.Nome, "%" + "São Paulo" + "%")).Where(x => EF.Functions.Like(x.Cidade.Estado.Pais.Nome, "%" + "Brasil" + "%")).Include(e => e.Cidade).Include(e => e.Cidade.Estado).Include(e => e.Cidade.Estado.Pais).OrderByDescending(o => o.Nome).ToList().FirstOrDefault() },
                    new PontoRisco { Descricao = "Marginal Pinheiros", Ponto = new Ponto { Latitude = -23.593279141769965, Longitude = -46.694204159345865 } },
                    new PontoRisco { Descricao = "Avenida Marquês de São Vicente", Ponto = new Ponto { Latitude = -23.519291936748548, Longitude = -46.6746502960441 }, Distrito = context.Distrito.Where(x => EF.Functions.Like(x.Nome, "%" + "Barra Funda" + "%")).Where(x => EF.Functions.Like(x.Cidade.Nome, "%" + "São Paulo" + "%")).Where(x => EF.Functions.Like(x.Cidade.Estado.Nome, "%" + "São Paulo" + "%")).Where(x => EF.Functions.Like(x.Cidade.Estado.Pais.Nome, "%" + "Brasil" + "%")).Include(e => e.Cidade).Include(e => e.Cidade.Estado).Include(e => e.Cidade.Estado.Pais).OrderByDescending(o => o.Nome).ToList().FirstOrDefault() },
                    new PontoRisco { Descricao = "Avenida Santo Amaro", Ponto = new Ponto { Latitude = -23.626077715193002, Longitude = -46.68722756134409 }, Distrito = context.Distrito.Where(x => EF.Functions.Like(x.Nome, "%" + "Santo Amaro" + "%")).Where(x => EF.Functions.Like(x.Cidade.Nome, "%" + "São Paulo" + "%")).Where(x => EF.Functions.Like(x.Cidade.Estado.Nome, "%" + "São Paulo" + "%")).Where(x => EF.Functions.Like(x.Cidade.Estado.Pais.Nome, "%" + "Brasil" + "%")).Include(e => e.Cidade).Include(e => e.Cidade.Estado).Include(e => e.Cidade.Estado.Pais).OrderByDescending(o => o.Nome).ToList().FirstOrDefault() },
                    new PontoRisco { Descricao = "Avenida Professor Abraão de Morais", Ponto = new Ponto { Latitude = -23.61844814506177, Longitude = -46.62820989239213 } },
                };

                context.PontoRisco.AddRange(listPontoRisco);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedDefaultPlacesAsync(
            ApplicationDbContext context,
            IPlacesService placesService,
            IMeshesService meshesService,
            ILogger logger)
        {
            // Pais
            if (!context.Pais.Any())
            {
                logger.LogInformation("Pais Informations Seed");

                var entity = new Pais
                {
                    Nome = "Brasil",
                    Sigla = "BR"
                };

                context.Pais.Add(entity);
                await context.SaveChangesAsync();

                var polygons = await SeedDefaultMeshesAsync(context, meshesService, "/paises", "BR");

                foreach (var polygon in polygons)
                {
                    var poligonoPaisEntity = new PoligonoPais()
                    {
                        Pais = entity,
                        Poligono = polygon
                    };

                    context.PoligonoPais.Add(poligonoPaisEntity);
                    await context.SaveChangesAsync();
                }
            }

            // Estado
            if (!context.Estado.Any())
            {
                logger.LogInformation("Estado Informations Seed");

                var states = await placesService.ProcessPlaces<DivisionState>("/estados");                

                // Pais
                var country = context.Pais.Where(x => x.Nome == "Brasil").FirstOrDefault();

                var listEntity = new List<Estado>();

                var listPoligonoEstado = new List<PoligonoEstado>();

                foreach (var state in states)
                {
                    var entity = new Estado
                    {
                        Pais = country,
                        Nome = state.Name,
                        Sigla = state.Initials
                    };

                    listEntity.Add(entity);

                    var polygons = await SeedDefaultMeshesAsync(context, meshesService, "/estados", state.Id.ToString());

                    foreach (var polygon in polygons)
                    {                      
                        var poligonoEstadoEntity = new PoligonoEstado()
                        {
                            Estado = entity,
                            Poligono = polygon
                        };

                        listPoligonoEstado.Add(poligonoEstadoEntity);                        
                    }
                };

                context.Estado.AddRange(listEntity);
                await context.SaveChangesAsync();

                //context.PoligonoEstado.AddRange(listPoligonoEstado);
                //await context.SaveChangesAsync();
            }

            // Cidade
            if (!context.Cidade.Any())
            {
                logger.LogInformation("Cidade Informations Seed");

                var counties = await placesService.ProcessPlaces<DivisionCounty>("/municipios");

                var listEntity = new List<Cidade>();
                var listPoligonoCidadeEntity = new List<PoligonoCidade>();

                foreach (var county in counties)
                {
                    // Estado 
                    var state = context.Estado.Where(x => x.Nome == county.Microregiao.Mesoregion.State.Name).FirstOrDefault();

                    var entity = new Cidade
                    {
                        Estado = state,
                        Nome = county.Name
                    };

                    listEntity.Add(entity);

                    // pegar meshes de todas as cidades do estado de São Paulo
                    if (county.Name == "São Paulo")
                    {
                        var polygons = await SeedDefaultMeshesAsync(context, meshesService, "/municipios", county.Id.ToString());

                        foreach (var polygon in polygons)
                        {
                            var poligonoCidadeEntity = new PoligonoCidade()
                            {
                                Cidade = entity,
                                Poligono = polygon
                            };

                            listPoligonoCidadeEntity.Add(poligonoCidadeEntity);
                        }
                    }                    
                };

                context.Cidade.AddRange(listEntity);
                await context.SaveChangesAsync();

                context.PoligonoCidade.AddRange(listPoligonoCidadeEntity);
                await context.SaveChangesAsync();
            }

            // Distrito
            if (!context.Distrito.Any())
            {
                logger.LogInformation("Distrito Informations Seed");

                var districts = await placesService.ProcessPlaces<DivisionDistrict>("/distritos");

                var listEntity = new List<Distrito>();

                foreach (var district in districts)
                {
                    // Cidade 
                    var county = context.Cidade.Where(x => x.Nome == district.County.Name).FirstOrDefault();

                    var entity = new Distrito
                    {
                        Cidade = county,
                        Nome = district.Name
                    };

                    listEntity.Add(entity);
                };

                context.Distrito.AddRange(listEntity);
                await context.SaveChangesAsync();
            }
        }

        private static async Task<IEnumerable<Poligono>> SeedDefaultMeshesAsync(
            ApplicationDbContext context,
            IMeshesService meshesService,
            string path, 
            string identifier)
        {
            var geoJson = await meshesService.ProcessMeshes(path, "/" + identifier);

            var geoJsonType = geoJson.Geometry.Type;

            List<Feature<Polygon>> geoJsonListPolygons = null;

            var listPolygons = new List<Poligono>();

            switch (geoJsonType)
            {
                case GeoJSONObjectType.Polygon:
                    if (geoJsonListPolygons == null)
                    {
                        geoJsonListPolygons = new List<Feature<Polygon>>();

                        geoJsonListPolygons.Add(await meshesService.ProcessMeshes<Polygon>(path, "/" + identifier));
                    }                        

                    foreach (var geoJsonPolygon in geoJsonListPolygons)
                    {
                        var count = 0;

                        // Polygon
                        var poligonoEntity = new Poligono();

                        // Point
                        var poligonoPontoListEntity = new List<PoligonoPonto>();

                        foreach (var geoJsonLineString in geoJsonPolygon.Geometry.Coordinates)
                        {
                            foreach (var geoJsonPoint in geoJsonLineString.Coordinates)
                            {
                                var poligonoPonto = new PoligonoPonto()
                                {
                                    Poligono = poligonoEntity,
                                    Ponto = new Ponto()
                                    {
                                        Count = count++,
                                        Latitude = geoJsonPoint.Latitude,
                                        Longitude = geoJsonPoint.Longitude
                                    }
                                };

                                poligonoPontoListEntity.Add(poligonoPonto);
                            }
                        }                        

                        context.PoligonoPonto.AddRange(poligonoPontoListEntity);
                        await context.SaveChangesAsync();

                        listPolygons.Add(poligonoEntity);
                    }     

                    break;
                case GeoJSONObjectType.MultiPolygon:
                    if (geoJsonListPolygons != null)
                        geoJsonListPolygons.Clear();

                    geoJsonListPolygons = new List<Feature<Polygon>>();

                    var geoJsonMultiPolygons = await meshesService.ProcessMeshes<MultiPolygon>(path, "/" + identifier);

                    foreach (var geoJsonPolygon in geoJsonMultiPolygons.Geometry.Coordinates)
                    {
                        var featurePolygon = new Feature<Polygon>(geoJsonPolygon);

                        geoJsonListPolygons.Add(featurePolygon);                            
                    }

                    goto case GeoJSONObjectType.Polygon;
                default:
                    throw new InvalidOperationException("unknown item type");
            }

            return listPolygons;
        }
    }
}
