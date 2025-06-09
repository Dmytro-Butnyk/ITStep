using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_5
{
    public class TextReport
    {
        private readonly string _text;

        public TextReport(string text)
        {
            _text = text;
        }

        public int NumberOfSentences { get; private set; }
        public int NumberOfCharacters { get; private set; }
        public int NumberOfWords { get; private set; }
        public int NumberOfQuestionSentences { get; private set; }
        public int NumberOfExclamationSentences { get; private set; }

        public async Task Analyze()
        {
            NumberOfSentences = await CountSentences();
            NumberOfCharacters = await CountCharacters();
            NumberOfWords = await CountWords();
            NumberOfQuestionSentences = await CountQuestionSentences();
            NumberOfExclamationSentences = await CountExclamationSentences();
        }

        private async Task<int> CountSentences()
        {
            return await Task.Run(() =>
            {
                var sentences = _text.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                return sentences.Length;
            });
        }

        private async Task<int> CountCharacters()
        {
            return await Task.Run(() => _text.Length);
        }

        private async Task<int> CountWords()
        {
            return await Task.Run(() =>
            {
                var words = _text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                return words.Length;
            });
        }

        private async Task<int> CountQuestionSentences()
        {
            return await Task.Run(() =>
            {
                var sentences = _text.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                return sentences.Count(s => s.Trim().EndsWith("?"));
            });
        }

        private async Task<int> CountExclamationSentences()
        {
            return await Task.Run(() =>
            {
                var sentences = _text.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                return sentences.Count(s => s.Trim().EndsWith("!"));
            });
        }

        public override string ToString()
        {
            return $"Number of sentences: {NumberOfSentences}\n" +
                   $"Number of characters: {NumberOfCharacters}\n" +
                   $"Number of words: {NumberOfWords}\n" +
                   $"Number of question sentences: {NumberOfQuestionSentences}\n" +
                   $"Number of exclamation sentences: {NumberOfExclamationSentences}";
        }
    }
}
