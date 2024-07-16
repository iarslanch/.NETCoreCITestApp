namespace CITestApp.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void TestAddPositive()
        {
            Calculator calculator = new Calculator();
            int sum = calculator.Add(2, 3);
            Assert.AreEqual(sum, 5);

        }

        [TestMethod]
        public void TestDivisionDivideByZero()
        {
            Calculator calculator = new Calculator();
            float ans = calculator.Division(2, 0);
            Assert.AreEqual(ans, 5);

        }
    }
}