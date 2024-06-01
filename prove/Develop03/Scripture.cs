using System;
using System.Collections.Generic;


    class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();
            foreach (string word in text.Split(' '))
            {
                _words.Add(new Word(word));
            }
        }

        public void HideElement()
        {
            Random random = new Random();
            int index = random.Next(_words.Count + 5); // +5 for the reference parts

            if (index < _words.Count)
            {
                _words[index].Hide();
            }
            else
            {
                _reference.HideElement(index - _words.Count);
            }
        }

        public bool IsAllHidden()
        {
            if (!_reference.IsAllHidden())
            {
                return false;
            }

            foreach (Word word in _words)
            {
                if (!word.IsHidden)
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            string scriptureText = "";
            foreach (Word word in _words)
            {
                scriptureText += word.ToString() + " ";
            }
            return $"{_reference.ToString()} {scriptureText.Trim()}";
        }
    }