using TFTDirecting.Commands;
using TFTDirecting.Contracts;
using TFTDirecting.Dtos;

namespace TFTDirecting.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public IEnumerable<UserDto> ActorsAppliedForMovie(int movieId)
        {
            return _applicationRepository.GetActorsAppliedForMovie(movieId);
        }

        public IEnumerable<InviteDto> GetMoviesApplicationsForActor(int actorId)
        {
            return _applicationRepository.GetMoviesApplicationsForActor(actorId);
        }

        public IEnumerable<InviteDto> GetMoviesInvitesForActor(int actorId)
        {
            return _applicationRepository.GetMoviesInvitesForActor(actorId);
        }

        public IEnumerable<MovieDto> GetMoviesWithApprovedRoles(int actorId)
        {
            return _applicationRepository.GetMoviesWithApprovedRoles(actorId);
        }

        public void InviteActor(InviteActorCommand command)
        {
            _applicationRepository.InviteActor(command);
        }

        public IEnumerable<MovieDto> GetAppliableMovies(int actorId)
        {
            return _applicationRepository.GetAppliableMovies(actorId);
        }
    }
}
