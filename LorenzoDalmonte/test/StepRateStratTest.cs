using NUnit.Framework;

[TestFixture]
public class StepRateStratTest
{
    private static readonly int NUM_STEPS = 10;
    private static readonly int STEP_VALUE = 1;
    private static readonly long STEP_LENGTH = 5L;
    private readonly StepRateStrat s = new StepRateStrat(NUM_STEPS, STEP_VALUE, STEP_LENGTH);

    [Test]
    void IntervalCheck()
    {
        Assert.AreEqual(s.Invoke(STEP_LENGTH) - s.Invoke(0L), STEP_VALUE);
        Assert.AreEqual(s.Invoke(STEP_LENGTH * 2) - s.Invoke(0L), STEP_VALUE * 2);
        Assert.AreEqual(s.Invoke(STEP_LENGTH * 3) - s.Invoke(STEP_LENGTH), STEP_VALUE * 2);
    }

   [Test]
    void MaxValueCheck()
    {
        Assert.AreNotEqual(s.Invoke(STEP_LENGTH * (NUM_STEPS - 1)), s.Invoke(STEP_LENGTH * NUM_STEPS));
        Assert.AreEqual(s.Invoke(STEP_LENGTH * (NUM_STEPS + 1)), s.Invoke(STEP_LENGTH * NUM_STEPS));

        for (long multiplier = 0 ; multiplier <= NUM_STEPS * 2 ; multiplier++)
        {
            Assert.IsTrue(s.Invoke(STEP_LENGTH * multiplier) <= s.Invoke(STEP_LENGTH * NUM_STEPS));
        }
    }
}