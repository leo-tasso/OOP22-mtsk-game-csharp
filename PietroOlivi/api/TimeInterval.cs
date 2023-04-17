using System;

/*
 * Class that models a time interval.
 */
public class TimeInterval
{
    private long Start { get; }
    private long End { get; }

    /*
     * Constructor for interval's bounds (in milliseconds).
     */
    public TimeInterval(long start, long end)
    {
        Start = start;
        End = end;
    }

    /*
     * Randomly extract a value within the range.
     */
    public long DrawInBetween()
    {
        var rand = new Random(DateTime.Now.Millisecond);
        return rand.Next((int)Start, (int)End);
    }

    public override bool Equals(object obj)
    {
        return obj is TimeInterval interval &&
               Start == interval.Start &&
               End == interval.End;
    }

    public override string ToString()
    {
        return base.ToString();
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
