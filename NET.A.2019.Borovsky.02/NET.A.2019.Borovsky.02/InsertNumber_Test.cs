using NUnit.Framework;

namespace NET.A._2019.Borovsky._02
{
    [TestFixture]
    class InsertNumber_Test
    {
        [TestCase]
        public void InsertNumber1()
        {
            InsertNumber ins = new InsertNumber();
            Assert.AreEqual(30, ins.InsNum(6, 3, 3, 6));
        }

        [TestCase]
        public void InsertNumber2()
        {
            InsertNumber ins = new InsertNumber();
            Assert.AreEqual(122, ins.InsNum(10, 7, 4, 8));
        }

        [TestCase]
        public void InsertNumber3()
        {
            InsertNumber ins = new InsertNumber();
            Assert.AreEqual(15, ins.InsNum(10, 5, 0, 3));
        }
    }
}
