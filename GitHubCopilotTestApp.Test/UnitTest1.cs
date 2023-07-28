using GitHubCopilotTestApp;

namespace GitHubCopilotTestApp.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestFixture]
        public class ProgramTest
        {
            readonly Program target = new ();

            [TestCase(2)]
            [TestCase(3)]
            [TestCase(5)]
            [TestCase(7)]
            [TestCase(997)]
            [TestCase(2153)]
            [TestCase(5023)]
            [TestCase(9999991)]
            public void IsPrimeTest(int n)
            {
                var result = IsPrime(n);
                Assert.That(result, Is.True);
            }

            [TestCase(-1)]
            [TestCase(0)]
            [TestCase(1)]
            [TestCase(4)]
            [TestCase(6)]
            [TestCase(998)]
            [TestCase(2152)]
            [TestCase(5024)]
            [TestCase(9999999)]
            public void IsNotPrimeTest(int n)
            {
                var result = IsPrime(n);
                Assert.That(result, Is.False);
            }

            private bool IsPrime(int n)
            {
                var type = target.GetType();
                var methodInfo = type.GetMethod("IsPrime", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
                return methodInfo?.Invoke(target, new object[] { n }) is bool;
            }
        }
    }
}
