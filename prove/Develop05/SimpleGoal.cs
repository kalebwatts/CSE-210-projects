using System;


    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points)
            : base(name, description, points) { }

        public override void Complete()
        {
            IsCompleted = true;
        }

        public override int GetPoints()
        {
            return IsCompleted ? Points : 0;
        }

        public override string DisplayStatus()
        {
            return $"{Name} [{(IsCompleted ? "X" : " ")}]";
        }

        public override string Save()
        {
            return $"SimpleGoal|{Name}|{Description}|{Points}|{IsCompleted}";
        }

        public override void Load(string data)
        {
            var parts = data.Split('|');
            Name = parts[1];
            Description = parts[2];
            Points = int.Parse(parts[3]);
            IsCompleted = bool.Parse(parts[4]);
        }
    }
