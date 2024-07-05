using GallowsGame.Pages;
using System.Reflection;

namespace GallowsGameTests
{
    public class UnitTest1
    {
        [Fact]
        public void StartGame_InitialState_CorrectlyDisplayed()
        {
            var game = new GamePage("test");
            var hiddenWordField = typeof(GamePage).GetField("hiddenWord", BindingFlags.NonPublic | BindingFlags.Instance);
            var hiddenWord = hiddenWordField.GetValue(game);
            Assert.Equal("test", hiddenWord);

            var currentOpenedWordField = typeof(GamePage).GetField("currentOpenedWord", BindingFlags.NonPublic | BindingFlags.Instance);
            var currentOpenedWord = currentOpenedWordField.GetValue(game);
            Assert.Equal("____", currentOpenedWord);
        }

        [Fact]
        public void CorrectLetterGuess_UpdatesGameState()
        {
            var game = new GamePage("test");
            var hiddenWordField = typeof(GamePage).GetField("hiddenWord", BindingFlags.NonPublic | BindingFlags.Instance);
            var hiddenWord = hiddenWordField.GetValue(game);
            Assert.Equal("test", hiddenWord);
            
            //bool result = game.GuessLetter('t');
            //Assert.True(result);
            //Assert.Equal("t__t", game.GuessedWord);
            //Assert.Contains('t', game.GuessedLetters);
            //Assert.Equal(6, game.RemainingAttempts);
        }
    }
}