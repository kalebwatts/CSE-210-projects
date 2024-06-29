using System;


    
    public class ChecklistGoal : Goal
    {
        private int _completionCount;
        private int _targetCount;
        private int _bonusPoints;

        public int CompletionCount 
        { 
            get => _completionCount; 
            set => _completionCount = value; 
        }

        public int TargetCount 
        { 
            get => _targetCount; 
            set => _targetCount = value; 
        }

        public int BonusPoints 
        { 
            get => _bonusPoints; 
            set => _bonusPoints = value; 
        }

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
            : base(name, description, points)
        {
            _targetCount = targetCount;
            _bonusPoints = bonusPoints;
            _completionCount = 0;
        }

        public void Record()
        {
            _completionCount++;
            if (_completionCount >= _targetCount)
            {
                IsCompleted = true;
            }
        }

        public override void Complete()
        {
            if (IsCompleted)
            {
                _completionCount = _targetCount;
            }
        }

        public override int GetPoints()
        {
            return IsCompleted ? Points + _bonusPoints : Points;
        }

        public override string DisplayStatus()
        {
            return $"{Name} [{(IsCompleted ? "X" : " ")}] (Completed {_completionCount}/{_targetCount} times)";
        }

        public override string Save()
        {
            return $"ChecklistGoal|{Name}|{Description}|{Points}|{IsCompleted}|{_completionCount}|{_targetCount}|{_bonusPoints}";
        }

        public override void Load(string data)
        {
            var parts = data.Split('|');
            Name = parts[1];
            Description = parts[2];
            Points = int.Parse(parts[3]);
            IsCompleted = bool.Parse(parts[4]);
            _completionCount = int.Parse(parts[5]);
            _targetCount = int.Parse(parts[6]);
            _bonusPoints = int.Parse(parts[7]);
        }
    }
