
    class Reference
    {
        private string _book;
        private int _startChapter;
        private int _startVerse;
        private int _endChapter;
        private int _endVerse;

        private bool _bookHidden;
        private bool _startChapterHidden;
        private bool _startVerseHidden;
        private bool _endChapterHidden;
        private bool _endVerseHidden;

        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _startChapter = chapter;
            _startVerse = verse;
            _endChapter = chapter;
            _endVerse = verse;

            _bookHidden = false;
            _startChapterHidden = false;
            _startVerseHidden = false;
            _endChapterHidden = false;
            _endVerseHidden = false;
        }

        public Reference(string book, int startChapter, int startVerse, int endChapter, int endVerse)
        {
            _book = book;
            _startChapter = startChapter;
            _startVerse = startVerse;
            _endChapter = endChapter;
            _endVerse = endVerse;

            _bookHidden = false;
            _startChapterHidden = false;
            _startVerseHidden = false;
            _endChapterHidden = false;
            _endVerseHidden = false;
        }

        public void HideElement(int index)
        {
            switch (index)
            {
                case 0:
                    _bookHidden = true;
                    break;
                case 1:
                    _startChapterHidden = true;
                    break;
                case 2:
                    _startVerseHidden = true;
                    break;
                case 3:
                    _endChapterHidden = true;
                    break;
                case 4:
                    _endVerseHidden = true;
                    break;
            }
        }

        public bool IsAllHidden()
        {
            return _bookHidden && _startChapterHidden && _startVerseHidden && _endChapterHidden && _endVerseHidden;
        }

        public override string ToString()
        {
            string bookStr = _bookHidden ? "_____" : _book;
            string startChapterStr = _startChapterHidden ? "___" : _startChapter.ToString();
            string startVerseStr = _startVerseHidden ? "___" : _startVerse.ToString();
            string endChapterStr = _endChapterHidden ? "___" : _endChapter.ToString();
            string endVerseStr = _endVerseHidden ? "___" : _endVerse.ToString();

            if (_startChapter == _endChapter && _startVerse == _endVerse)
            {
                return $"{bookStr} {startChapterStr}:{startVerseStr}";
            }
            return $"{bookStr} {startChapterStr}:{startVerseStr}-{endChapterStr}:{endVerseStr}";
        }
    }