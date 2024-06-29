using System;
using System.Collections.Generic;


    
    public class User
    {
        private string _name;
        private int _totalScore;
        private List<Goal> _goals;

        public string Name 
        { 
            get => _name; 
            set => _name = value; 
        }

        public int TotalScore 
        { 
            get => _totalScore; 
            set => _totalScore = value; 
        }

        public List<Goal> Goals 
        { 
            get => _goals; 
            set => _goals = value; 
        }

        public User(string name)
        {
            _name = name;
            _totalScore = 0;
            _goals = new List<Goal>();
        }

        public void AddGoal(Goal goal)
        {
            _goals.Add(goal);
        }

        public void RecordEvent(Goal goal)
        {
            if (goal is EternalGoal eternalGoal)
            {
                eternalGoal.Record();
            }
            else if (goal is ChecklistGoal checklistGoal)
            {
                checklistGoal.Record();
            }
            else
            {
                goal.Complete();
            }

            _totalScore += goal.GetPoints();
        }

        public string DisplayScore()
        {
            return $"{_name}'s Total Score: {_totalScore}";
        }

        public void DisplayGoals()
        {
            Console.WriteLine($"{_name}'s Goals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].DisplayStatus()}");
            }
        }

        public string SaveGoals()
        {
            List<string> goalData = new List<string>();
            foreach (var goal in _goals)
            {
                goalData.Add(goal.Save());
            }
            return string.Join("\n", goalData);
        }

        public void LoadGoals(string data)
        {
            var lines = data.Split('\n');
            _goals.Clear();
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split('|');
                Goal goal = null;
                switch (parts[0])
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                        break;
                    case "ChecklistGoal":
                        goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[6]), int.Parse(parts[7]));
                        break;
                }
                goal.Load(line);
                _goals.Add(goal);
            }
        }
    }
