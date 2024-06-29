using System;


    
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points) { }

        public void Record()
        {
            
        }

        public override void Complete()
        {
            
        }

        public override int GetPoints()
        {
            return Points;
        }

        public override string DisplayStatus()
        {
            return $"{Name} [ ] (Eternal)";
        }

        public override string Save()
        {
            return $"EternalGoal|{Name}|{Description}|{Points}|{IsCompleted}";
        }

        public override void Load(string data)
        {
            var parts = data.Split('|');
            Name = parts[1];
            Description = parts[2];
            Points = int.Parse(parts[3]);
        }
    }
