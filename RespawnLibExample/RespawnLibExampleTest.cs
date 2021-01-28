using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespawnLibExample
{
    [TestFixture]
    class RespawnLibExampleTest
    {
        [TestCase]
        public void AddUserToDatabase() 
        {
            RespawnLibTestExp example = new RespawnLibExp();
            example.addUser('Abc');
            Assert.AreEqual(true,example.IsUserTableEmpty);
        }
    }
}
