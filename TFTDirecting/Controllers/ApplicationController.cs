using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TFTDirecting.Commands;
using TFTDirecting.Contracts;

namespace TFTDirecting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private IApplicationService _applicationService;
        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        //[Director]
        [HttpGet("{movieId}")] // 1. Direktor; a. Pregled svih mojih filmova; i. Pregled svih glumaca koji su se prijavili na taj film
        public IActionResult GetActorsAppliedForMovie(int movieId)
        {
            return Ok(_applicationService.ActorsAppliedForMovie(movieId));
        }

        //[Actor]
        [HttpGet("{actorId}")] // 2. Glumac; c. Pregled svih filmova; i. Na kojima je moja pozivnica
        public IActionResult GetMoviesInvites(int actorId)
        {
            return Ok(_applicationService.GetMoviesInvitesForActor(actorId));
        }

        //[Actor]
        [HttpGet("{actorId}")] // 2. Glumac; c. Pregled svih filmova; ii. Na kojima je glumac moja prijava ???? valjda?
        public IActionResult GetMoviesApplications(int actorId)
        {
            return Ok(_applicationService.GetMoviesApplicationsForActor(actorId));
        }

        //[Actor]
        [HttpGet("{actorId}")] // 2. Glumac; c. Pregled svih filmova; iii. Na kojima je moja uloga osigurana
        public IActionResult GetMoviesWithApprovedRoles(int actorId)
        {
            return Ok(_applicationService.GetMoviesWithApprovedRoles(actorId));
        }
    }
}
