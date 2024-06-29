using System;
using System.Collections.Generic;


    
    public class GoalManager
    {
        public Goal CreateGoal(string type, string name, string description, int points, int targetCount = 0, int bonusPoints = 0)
        {
            switch (type)
            {
                case "SimpleGoal":
                    return new SimpleGoal(name, description, points);
                case "EternalGoal":
                    return new EternalGoal(name, description, points);
                case "ChecklistGoal":
                    return new ChecklistGoal(name, description, points, targetCount, bonusPoints);
                default:
                    throw new ArgumentException("Unknown goal type");
            }
        }

        public string SaveGoals(List<Goal> goals)
        {
            List<string> goalData = new List<string>();
            foreach (var goal in goals)
            {
                goalData.Add(goal.Save());
            }
            return string.Join("\n", goalData);
        }

        public List<Goal> LoadGoals(string data)
        {
            var goals = new List<Goal>();
            var lines = data.Split('\n');
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
                goals.Add(goal);
            }
            return goals;
        }

        public void DisplayGoals(List<Goal> goals)
        {
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].DisplayStatus()}");
            }
        }
    }
