using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RespawnLibExample
{
    [TestFixture]
    class RespawnLibExpTest
    {
        [TestCase]
        public void AddUser()
        {
            RespawnLibExp ex = new RespawnLibExp();
            ex.AddUser("Name");
            Assert.AreEqual(false, ex.IsUserTableEmpty());
        }

        [TestCase]
        public void Reset()
        {
            RespawnLibExp ex = new RespawnLibExp();
            ex.Reset();
            Thread.Sleep(1000);
            Assert.AreEqual(true, ex.IsUserTableEmpty());
        }
    }
}
