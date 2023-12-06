using TFTDirecting.Contracts;
using TFTDirecting.Dtos;

namespace TFTDirecting.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        public UserDto GetActorsAppliedForMovie(int movieId)
        {
            throw new NotImplementedException();
        }

        public InviteDto GetMoviesApplicationsForActor(int actorId)
        {
            throw new NotImplementedException();
        }

        public InviteDto GetMoviesInvitesForActor(int actorId)
        {
            throw new NotImplementedException();
        }

        public InviteDto GetMoviesWithApprovedRoles(int actorId)
        {
            throw new NotImplementedException();
        }
    }
}
