using GallowsGame.Pages;
using System.Reflection;

namespace GallowsGameTests
{
    public class UnitTest1
    {
        [Fact]
        public void StartGame_InitialState_CorrectlyDisplayed()
        {
            var game = new GamePage("тест");
            var hiddenWordField = typeof(GamePage).GetField("hiddenWord", BindingFlags.NonPublic | BindingFlags.Instance);
            var hiddenWord = hiddenWordField.GetValue(game);
            Assert.Equal("тест", hiddenWord);

            var currentOpenedWordField = typeof(GamePage).GetField("currentOpenedWord", BindingFlags.NonPublic | BindingFlags.Instance);
            var currentOpenedWord = currentOpenedWordField.GetValue(game);
            Assert.Equal("____", currentOpenedWord);
        }

        [Fact]
        public void CorrectLetterGuess_UpdatesGameState()
        {
            var game = new GamePage("тест");
            var guessLetterMethod = typeof(GamePage).GetMethod("GuessLetter", BindingFlags.NonPublic | BindingFlags.Instance);
            guessLetterMethod.Invoke(game, new object[] { "т", new Image() });

            var currentOpenedWordField = typeof(GamePage).GetField("currentOpenedWord", BindingFlags.NonPublic | BindingFlags.Instance);
            var currentOpenedWord = currentOpenedWordField.GetValue(game);
            Assert.Equal("т__т", currentOpenedWord);
        }
        [Fact]
        public void TestCorrectGuessWithMinimalWord()
        {

        }
    }
}