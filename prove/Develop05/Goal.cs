using System;


    public abstract class Goal
    {
        private string _name;
        private string _description;
        private int _points;
        private bool _isCompleted;

        public string Name 
        { 
            get => _name; 
            set => _name = value; 
        }

        public string Description 
        { 
            get => _description; 
            set => _description = value; 
        }

        public int Points 
        { 
            get => _points; 
            set => _points = value; 
        }

        public bool IsCompleted 
        { 
            get => _isCompleted; 
            set => _isCompleted = value; 
        }

        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
            _isCompleted = false;
        }

        public abstract void Complete();
        public abstract int GetPoints();
        public abstract string DisplayStatus();
        public abstract string Save();
        public abstract void Load(string data);
    }
