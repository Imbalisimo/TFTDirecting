using TFTDirecting.Database;

namespace TFTDirecting.Dtos
{
    public class InviteDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public bool IsAcceptedByActor { get; set; }
        public bool IsAcceptedByDirector { get; set; }

        public InviteDto(ActorMovieApplication application)
        {
            Id = application.Id;
            MovieId = application.MovieId;
            ActorId = application.ActorId;
            IsAcceptedByActor = application.IsAcceptedByActor;
            IsAcceptedByDirector = application.IsAcceptedByDirector;
        }
    }
}
