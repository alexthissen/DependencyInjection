﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ASPNETCore30WebApplication.Infrastructure;
using ASPNETCore30WebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly.Timeout;

namespace ASPNETCore30WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/xml", "application/json")]
    public class FamilyNameController : ControllerBase
    {
        private readonly IGenderizeClient genderizeClient;
        private readonly ILogger<FamilyNameController> logger;
        private readonly IOptionsSnapshot<GenderizeApiOptions> genderizeOptions;

        public FamilyNameController(
            IGenderizeClient genderizeClient,
            IOptionsSnapshot<GenderizeApiOptions> genderizeOptions,
            ILoggerFactory logger)
        {
            this.genderizeClient = genderizeClient;
            this.genderizeOptions = genderizeOptions;
            this.logger = logger.CreateLogger<FamilyNameController>();
        }

        // GET api/familyname/name
        /// <summary>
        /// Retrieve profile of person based on name.
        /// </summary>
        /// <param name="name">Name of person.</param>
        /// <returns>Detailed information regarding profile.</returns>
        /// <response code="200">The profile was successfully retrieved.</response>
        /// <response code="400">The request parameters were invalid or a timeout while retrieving profile occurred.</response>
        [HttpGet("{name}")]
        [ProducesResponseType(typeof(FamilyProfile), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<FamilyProfile>> Get(string name)
        {
            GenderizeResult result = null;
            FamilyProfile profile;

            try
            {
                string baseUrl = genderizeOptions.Value.BaseUrl;
                string key = genderizeOptions.Value.DeveloperApiKey;

                logger.LogInformation("Acquiring name details for {FamilyName}.", name);

                result = await genderizeClient.GetGenderForName(name, key);
                Gender gender;
                profile = new FamilyProfile()
                {
                    Name = name,
                    Gender = Enum.TryParse<Gender>(result.Gender, true, out gender)
                        ? gender : Gender.Unknown
                };
            }
            catch (HttpRequestException ex)
            {
                logger.LogWarning(ex, "Http request failed.");
                return StatusCode(StatusCodes.Status502BadGateway, "Failed request to external resource.");
            }
            catch (TimeoutRejectedException ex)
            {
                logger.LogWarning(ex, "Timeout occurred when retrieving details for {FamilyName}.", name);
                return StatusCode(StatusCodes.Status504GatewayTimeout, "Timeout on external web request.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unknown exception occurred while retrieving gender details.");

                // Exception shielding for all other exceptions
                return StatusCode(StatusCodes.Status500InternalServerError, "Request could not be processed.");
            }
            return Ok(profile);
        }
    }
}