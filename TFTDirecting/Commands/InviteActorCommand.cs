using TFTDirecting.Database;

namespace TFTDirecting.Commands
{
    public class InviteActorCommand
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }

        public ActorMovieApplication ToActorMovieApplication()
        {
            return new ActorMovieApplication
            {
                MovieId = MovieId,
                ActorId = ActorId,
                IsAcceptedByDirector = true
            };
        }
    }
}
