
    class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public void Hide()
        {
            _isHidden = true;
        }

        public bool IsHidden
        {
            get { return _isHidden; }
        }

        public override string ToString()
        {
            return _isHidden ? "_____" : _text;
        }
    }