using System;

namespace Goals.API.ApiModels
{
    public class GoalDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime TargetDate { get; set; }
    }
}