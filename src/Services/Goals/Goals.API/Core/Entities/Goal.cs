using System;

namespace Goals.API.Core.Entities
{
    public class Goal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime TargetDate { get; set; }
    }
}