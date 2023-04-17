using System;

/*
 * Interface to model the inputs.
 */
public interface IInput : ICloneable 
{
    bool MoveUp { get; set; }
    bool MoveDown { get; set; }
    bool MoveRight { get; set; }
    bool MoveLeft { get; set; }
    bool Jump { get; set; }
    bool Forward { get; set; }
    bool Backwards { get; set; }
    Int32? NumberPressed { get; set; }

    /*
        * Method to reset all inputs to false.
        */
    void Reset();
}
        