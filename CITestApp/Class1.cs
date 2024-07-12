using System.Xml.Linq;

namespace CITestApp
{
    public class Class1
    {
        string username = "admin";
        string password = "Admin123"; // Sensitive
        string usernamePassword = "user=admin&password=Admin123"; // Sensitive
        string url = "scheme://user:Admin123@domain.com"; // Sensitive

        public void DoSomething()
        {
            if (this is Class1) // Noncompliant
            {
                // Code specific to Pizza...
            }
        }
        void Method(object value)
        {
            int i;
            i = (int)value;   // Casting (explicit conversion) from float to int
        }
        public void Foo() 
        {
            string x;
            int i=0;
            int j=0;
            int k = i / j;
            throw new NotImplementedException();
        }
        private void mytest(string[] args)
        { }

        public int Sum()
        {
            var i = 0;
            var result = 0;
            while (true) // Noncompliant: the program will never stop
            {
                result += i;
                i++;
            }
            return result;
        }
        int Pow(int num, int exponent)
        {
            return num * Pow(num, exponent - 1); // Noncompliant: no condition under which Pow isn't re-called
        }

        public void mymethos2()
        {
            try
            {
                // Some work which end up throwing an exception
                throw new ArgumentException();
            }
            finally
            {
                // Cleanup
                throw new InvalidOperationException(); // Noncompliant: will mask the ArgumentException
            }

        }

        public void Foo2()
        {
            var g1 = new Guid();    // Noncompliant - what's the intent?
            Guid g2 = new();        // Noncompliant
            var g3 = default(Guid); // Noncompliant
            Guid g4 = default;      // Noncompliant
        }

    }
}
