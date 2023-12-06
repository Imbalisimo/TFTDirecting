﻿namespace TFTDirecting.Commands
{
    public class UpdateMovieCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Duration { get; set; }
        public double Budget { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
    }
}