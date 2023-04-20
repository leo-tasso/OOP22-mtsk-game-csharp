namespace OOP22_mtsk_game_csharp.PietroOlivi.api
{
    /*
     * Class that encodes the input of the user, that indicates
     * the direction in which the GameObject should be moved,
     * setting one of the 4 boolean values ​​to true.
     */
    internal class KeyboardInput : IInput
    {
        public bool MoveUp { get; set; }
        public bool MoveDown { get; set; }
        public bool MoveRight { get; set; }
        public bool MoveLeft { get; set; }
        public bool Jump { get; set; }
        public bool Forward { get; set; }
        public bool Backwards { get; set; }
        public int? NumberPressed { get; set; }

        public void Reset()
        {
            MoveUp = false;
            MoveDown = false;
            MoveRight = false;
            MoveLeft = false;
            Jump = false;
            Forward = false;
            Backwards = false;
            NumberPressed = null;
        }

        public object Clone()
        {
            throw new System.NotImplementedException();
        }
    }
}
