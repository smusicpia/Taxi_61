﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using Taxi.Web.Data.Entities;
using Taxi_Qualifier.Common.Models;

using Taxi_Qualifier.Web.Data.Entities;

using Taxi_Qualifier.Web.Data;

using Taxi_Qualifier.Web.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Taxi_Qualifier.Web.Controllers.API
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly IConverterHelper _converterHelper;

        public TripsController(DataContext context, IUserHelper userHelper, IConverterHelper converterHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _converterHelper = converterHelper;
        }

        [HttpPost]
        public async Task<IActionResult> PostTripEntity([FromBody] TripRequest tripRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserEntity userEntity = await _userHelper.GetUserAsync(tripRequest.UserId);
            if (userEntity == null)
            {
                return BadRequest("User doesn't exists.");
            }

            TaxiEntity taxiEntity = await _context.Taxis.FirstOrDefaultAsync(t => t.Plaque == tripRequest.Plaque);
            if (taxiEntity == null)
            {
                _context.Taxis.Add(new TaxiEntity { Plaque = tripRequest.Plaque.ToUpper() });
                await _context.SaveChangesAsync();
                taxiEntity = await _context.Taxis.FirstOrDefaultAsync(t => t.Plaque == tripRequest.Plaque);
            }

            TripEntity tripEntity = new TripEntity
            {
                Source = tripRequest.Address,
                SourceLatitude = tripRequest.Latitude,
                SourceLongitude = tripRequest.Longitude,
                StartDate = DateTime.UtcNow,
                Taxi = taxiEntity,
                TripDetails = new List<TripDetailEntity>
                {
                    new TripDetailEntity
                    {
                        Date = DateTime.UtcNow,
                        Latitude = tripRequest.Latitude,
                        Longitude = tripRequest.Longitude
                    }
                },
                User = userEntity,
            };

            _context.Trips.Add(tripEntity);
            await _context.SaveChangesAsync();
            return Ok(_converterHelper.ToTripResponse(tripEntity));
        }
    }
}
