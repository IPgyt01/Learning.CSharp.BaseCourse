using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Norbit.CRM.Tyganov.Practic3.Library.Tests
{
    [TestClass()]
    public class DynamicArrayTests
    {
        DynamicArray<int> _dynamicArray;

        [TestInitialize]
        public void ArrayInit()
        {
            var array = new int[] { 1, 2, 3 };
            _dynamicArray = new DynamicArray<int>(array);
        }

        [TestMethod]
        public void AddTest()
        {
            var actualArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (var i = 4; i < 10; i++)
            {
                _dynamicArray.Add(i);
            }
            Assert.AreEqual(actualArr[8], _dynamicArray[8]);
        }

        [TestMethod]
        public void RemoveTest()
        {
            _dynamicArray.Remove(2);
            Assert.AreEqual(2, _dynamicArray[1]);
        }

        [TestMethod]
        public void InsertTest()
        {
            _dynamicArray.Insert(5, 1);
            Assert.AreEqual(5, _dynamicArray[0]);
        }
    }
}