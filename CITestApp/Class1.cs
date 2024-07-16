using System.Data.Entity;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Xml.Linq;


namespace CITestApp
{
    public class Class1
    {
        string username = "admin";
        string password = "Admin123"; // Sensitive
        string usernamePassword = "user=admin&password=Admin123"; // Sensitive
        string url = "scheme://user:Admin123@domain.com"; // Sensitive
        private static string TargetDirectory = "/path/to/target/directory/";

        //public void Foo(DbContext context, string query, string param)
        //{
        //    string sensitiveQuery = string.Concat(query, param);
        //    context.Database.ExecuteSqlCommand(sensitiveQuery); // Sensitive
        //    context.Query<User>().FromSql(sensitiveQuery); // Sensitive

        //    context.Database.ExecuteSqlCommand($"SELECT * FROM mytable WHERE mycol={value}", param); // Sensitive, the FormattableString is evaluated and converted to RawSqlString
        //    string query = $"SELECT * FROM mytable WHERE mycol={param}";
        //    context.Database.ExecuteSqlCommand(query); // Sensitive, the FormattableString has already been evaluated, it won't be converted to a parametrized query.
        //}

        public void Example(string filename)
        {
            var ip = "192.168.12.42";
            var address = IPAddress.Parse(ip);

            Process p = new Process();
            p.StartInfo.FileName = "binary"; // Sensitive


            var urlHttp = "http://example.com";                 // Noncompliant
            var urlFtp = "ftp://anonymous@example.com";         // Noncompliant
            var urlTelnet = "telnet://anonymous@example.com";   // Noncompliant
            string path = Path.Combine(TargetDirectory, filename);
            System.IO.File.Delete(path);
        }
        public void Run(string binary)
        {
            var hashProvider1 = new MD5CryptoServiceProvider(); // Sensitive
            var hashProvider2 = (HashAlgorithm)CryptoConfig.CreateFromName("MD5"); // Sensitive
            var hashProvider3 = new SHA1Managed(); // Sensitive
            var hashProvider4 = HashAlgorithm.Create("SHA1"); // Sensitive

            Process p = new Process();
            p.StartInfo.FileName = binary;
            p.Start();
        }
        
    
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
