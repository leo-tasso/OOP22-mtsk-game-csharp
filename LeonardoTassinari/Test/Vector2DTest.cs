using NUnit.Framework;
using OOP22_mtsk_game_csharp.LeonardoTassinari.game;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.test

{
    [TestFixture]
    public class Vector2DTest
    {

        [Test]
        public void TestSum()
        {
            Vector2D vector1 = new Vector2D(-9, 2);
            Vector2D vector2 = new Vector2D(3, 4);
            Vector2D vector3 = vector1.Sum(vector2);
            Assert.AreEqual(-6, vector3.X);
            Assert.AreEqual(6, vector3.Y);
        }

        [Test]
        public void TestMul()
        {
            Vector2D vector1 = new Vector2D(1, 2);
            Vector2D vector2 = vector1.Mul(4);
            Assert.AreEqual(4, vector2.X);
            Assert.AreEqual(8, vector2.Y);
        }

        [Test]
        public void TestModule()
        {
            Vector2D vector1 = new Vector2D(3, 4);
            double result = vector1.Module();
            Assert.AreEqual(5, result);
        }

        [Test]
        public void TestInvert()
        {
            Vector2D vector1 = new Vector2D(3, 4);
            Vector2D vector2 = vector1.Invert();
            Assert.AreEqual(-3, vector2.X);
            Assert.AreEqual(-4, vector2.Y);
        }

        [Test]
        public void TestEquals()
        {
            Vector2D vector1 = new Vector2D(9, 4);
            Vector2D vector2 = new Vector2D(9, 4);
            Assert.AreEqual(vector1, vector2);
        }

        [Test]
        public void TestStringRepresentation()
        {
            Vector2D vector1 = new Vector2D(5, 4);
            string result = vector1.StringRepresentation;
            Assert.AreEqual("(5,4)", result);
        }
        [Test]
        public void TestNullVector()
        {
            Vector2D vector1 = Vector2D.NullVector();
            Vector2D vector2 = Vector2D.NullVector();
            Assert.AreEqual(vector1.Sum(vector2), Vector2D.NullVector());
        }
    }

}