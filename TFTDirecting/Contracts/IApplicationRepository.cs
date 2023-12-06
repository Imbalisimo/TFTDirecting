using TFTDirecting.Dtos;

namespace TFTDirecting.Contracts
{
    public interface IApplicationRepository
    {
        UserDto GetActorsAppliedForMovie(int movieId);
        InviteDto GetMoviesApplicationsForActor(int actorId);
        InviteDto GetMoviesInvitesForActor(int actorId);
        InviteDto GetMoviesWithApprovedRoles(int actorId);
    }
}
