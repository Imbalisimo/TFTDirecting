using TFTDirecting.Database;
using TFTDirecting.Dtos;

namespace TFTDirecting.Contracts
{
    public interface IApplicationService
    {
        IEnumerable<UserDto> ActorsAppliedForMovie(int movieId);
        IEnumerable<InviteDto> GetMoviesInvitesForActor(int actorId);
        IEnumerable<InviteDto> GetMoviesApplicationsForActor(int actorId);
        IEnumerable<MovieDto> GetMoviesWithApprovedRoles(int actorId);
    }
}
