using NUnit.Framework;
using HomeWork13;

namespace Tests
{
    public class QueueTest
    {
        [TestCaseSource("QueueAddCases")]
        public void QueueAddTest(CustomQueue<int> input, CustomQueue<int> expected, int addElement)
        {
            input.Add(addElement);
            Assert.AreEqual(expected.QueueArray, input.QueueArray);
        }

        static object[] QueueAddCases =
        {
            new object[] { new CustomQueue<int>(new int[] { 1, 2, 3, 4 }), new CustomQueue<int>(new int[] { 1, 2, 3, 4, 5}), 5 },
            new object[] { new CustomQueue<int>(new int[] { 90, 80, 50, 1, 3, 2, 4 }), new CustomQueue<int>(new int[] { 90, 80, 50, 1, 3, 2, 4, 55 }), 55 }
        };

        [TestCaseSource("QueueRemoveCases")]
        public void QueueRemoveTest(CustomQueue<string> input, CustomQueue<string> expected)
        {
            input.Remove();
            Assert.AreEqual(expected.QueueArray, input.QueueArray);
        }

        static object[] QueueRemoveCases =
        {
            new object[] { new CustomQueue<string>(new string[] { "a", "b", "c", "d" }), new CustomQueue<string>(new string[] { "b", "c", "d" })},
            new object[] { new CustomQueue<string>(new string[] { "b", "c", "d" }), new CustomQueue<string>(new string[] { "c", "d" })}
        };

        [TestCaseSource("QueueRemoveSecondElementCases")]
        public void QueueRemoveSecondElementTest(CustomQueue<int> input, CustomQueue<int> expected)
        {
            input.Next();
            input.RemoveCurrent();
            Assert.AreEqual(expected.QueueArray, input.QueueArray);
        }

        static object[] QueueRemoveSecondElementCases =
        {
            new object[] { new CustomQueue<int>(new int[] { 1, 2, 3, 4 }), new CustomQueue<int>(new int[] { 1, 3, 4})},
            new object[] { new CustomQueue<int>(new int[] { 44, 33, 22, 11 }), new CustomQueue<int>(new int[] { 44, 22, 11 })}
        };

    }
}