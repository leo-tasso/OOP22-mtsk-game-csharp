using System;

namespace IInput
{ 
    /*
     * Interface to model the inputs.
     */
    public interface IInput : ICloneable 
    {
        /*
         * Method to check if moveUp input is active.
         */
        bool IsMoveUp();

        /*
         * Method to check if moveDown input is active.
         */
        bool IsMoveDown();

        /*
         * Method to check if moveRight input is active.
         */
        bool IsMoveRight();

        /*
         * Method to check if moveLeft input is active.
         */
        bool IsMoveLeft();

        /*
         * Method to check if jump input is active.
         */
        bool IsJump();

        /*
         * Method to check if forward input is active.
         */
        bool IsForward();

        /*
         * Method to check if backwards input is active.
         */
        bool IsBackwards();

        /*
         * Method to set if moveUp input is active.
         */
        void SetMoveUp(bool moveUp);

        /*
         * Method to set moveDown input.
         */
        void SetMoveDown(bool moveDown);

        /*
         * Method to set if moveRight input is active.
         */
        void SetMoveRight(bool moveRight);

        /*
         * Method to set moveLeft input.
         */
        void SetMoveLeft(bool moveLeft);

        /*
         * Method that returns a Nullable containing, 
         * possibly, the number pressed (in [1,9]).
         */
        Int32? GetNumberPressed();

        /*
         * Sets the number pressed on the keyboard by the player.
         */
        void SetNumberPressed(Int32? numberPressed);

        /*
         * Method to set jump input.
         */
        void SetJump(bool jump);

        /*
         * Method to set forward input.
         */
        void SetForward(bool forward);

        /*
         * Method to set backwards input.
         */
        void SetBackwards(bool backwards);

        /*
         * Method to reset all inputs to false.
         */
        void Reset();
    }
}
        