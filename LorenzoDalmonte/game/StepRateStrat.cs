using System;

public class StepRateStrat
{
    private readonly int _numSteps;
    private readonly int _stepValue;
    private readonly long _stepLength;

    public StepRateStrat(int numSteps, int stepValue, long stepLength)
    {
        _numSteps = numSteps;
        _stepValue = stepValue;
        _stepLength = stepLength;
    }

    public int Invoke(long totalElapsed)
    {
        int x = (int) (totalElapsed / _stepLength);
        return x >= _numSteps ? _numSteps * _stepValue : x * _stepValue;
    }
}