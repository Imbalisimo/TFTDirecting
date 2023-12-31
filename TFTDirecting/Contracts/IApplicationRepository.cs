﻿using TFTDirecting.Commands;
using TFTDirecting.Dtos;

namespace TFTDirecting.Contracts
{
    public interface IApplicationRepository
    {
        IEnumerable<UserDto> GetActorsAppliedForMovie(int movieId);
        IEnumerable<InviteDto> GetMoviesApplicationsForActor(int actorId);
        IEnumerable<InviteDto> GetMoviesInvitesForActor(int actorId);
        IEnumerable<MovieDto> GetMoviesWithApprovedRoles(int actorId);
        void InviteActor(InviteActorCommand command);
        IEnumerable<MovieDto> GetAppliableMovies(int actorId);
    }
}
