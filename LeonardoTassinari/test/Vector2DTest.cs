using NUnit.Framework;

namespace Name
{
    [TestFixture]
    public class Vector2DTest
    {

        [Test]
        public void TestSum()
        {
            Vector2D v1 = new Vector2D(1, 2);
            Vector2D v2 = new Vector2D(3, 4);
            Vector2D v3 = v1.sum(v2);
            Assert.AreEqual(4, v3.X);
            Assert.AreEqual(6, v3.Y);
        }

        [Test]
        public void TestMul()
        {
            Vector2D v1 = new Vector2D(1, 2);
            Vector2D v2 = v1.mul(3);
            Assert.AreEqual(3, v2.X);
            Assert.AreEqual(6, v2.Y);
        }

        [Test]
        public void TestModule()
        {
            Vector2D v1 = new Vector2D(3, 4);
            double result = v1.module();
            Assert.AreEqual(5, result);
        }

        [Test]
        public void TestInvert()
        {
            Vector2D v1 = new Vector2D(3, 4);
            Vector2D v2 = v1.invert();
            Assert.AreEqual(-3, v2.X);
            Assert.AreEqual(-4, v2.Y);
        }

        [Test]
        public void TestEquals()
        {
            Vector2D v1 = new Vector2D(3, 4);
            Vector2D v2 = new Vector2D(3, 4);
            Assert.AreEqual(v1, v2);
        }

        [Test]
        public void TestStringRepresentation()
        {
            Vector2D v1 = new Vector2D(3, 4);
            string result = v1.StringRepresentation;
            Assert.AreEqual("(3,4)", result);
        }
    }

}