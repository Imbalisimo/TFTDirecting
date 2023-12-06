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

        public UserDto ActorsAppliedForMovie(int movieId)
        {
            return _applicationRepository.GetActorsAppliedForMovie(movieId);
        }

        public InviteDto GetMoviesApplicationsForActor(int actorId)
        {
            return _applicationRepository.GetMoviesApplicationsForActor(actorId);
        }

        public InviteDto GetMoviesInvitesForActor(int actorId)
        {
            return _applicationRepository.GetMoviesInvitesForActor(actorId);
        }

        public InviteDto GetMoviesWithApprovedRoles(int actorId)
        {
            return _applicationRepository.GetMoviesWithApprovedRoles(actorId);
        }
    }
}
