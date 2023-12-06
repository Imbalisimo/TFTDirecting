using TFTDirecting.Database;
using TFTDirecting.Dtos;

namespace TFTDirecting.Contracts
{
    public interface IApplicationService
    {
        UserDto ActorsAppliedForMovie(int movieId);
        InviteDto GetMoviesInvitesForActor(int actorId);
        InviteDto GetMoviesApplicationsForActor(int actorId);
        InviteDto GetMoviesWithApprovedRoles(int actorId);
    }
}
