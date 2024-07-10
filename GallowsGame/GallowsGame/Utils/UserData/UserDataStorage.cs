
using GallowsGame.Utils.UserData;

namespace GallowsGame.Utils
{ 
    public static class UserDataStorage
    {
        public static PersonData? FirstPlayer { get; set; }
        public static PersonData? SecondPlayer { get; set; }
        public static int AllRoundsCount { get; set; } = 1;
    }
}
