using NUnit.Framework;
using TestNinja.Fundamentals;

namespace UnitTestProject1
{
    [TestFixture]
    public class StackTests
    {

        [Test]
        public void Stack_NewStack_ReturnsCountOfZero()
        {
            var stack = new Stack<int>();

            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Push_NullObject_ThrowsAnException()
        {
            var stack = new Stack<string>();

            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ValidArgs_AddTheObjectToStack()
        {
            var stack = new Stack<int>();

            stack.Push(1);

            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Pop_EmptyStack_ThrowsAnException()
        {
            var stack = new Stack<int>();

            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_ValidStack_PopLastEnteredObject()
        {
            var stack = new Stack<int>();
            stack.Push(-1);

            var result = stack.Pop();

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void Pop_ValidStack_AfterPopCountIsSmaller()
        {
            var stack = new Stack<int>();
            stack.Push(-1);
            stack.Push(-2);

            var result = stack.Pop();

            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Peek_EmptyStack_ThrowsAnException()
        {
            var stack = new Stack<bool>();

            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_ValidStack_ReturnsLastObject()
        {
            var stack = new Stack<string>();

            stack.Push("ala");
            stack.Push("bala");

            var result = stack.Peek();

            Assert.That(result, Is.EqualTo("bala"));
        }

        [Test]
        public void Peek_ValidStack_CountOfStackIsSame()
        {
            var stack = new Stack<string>();

            stack.Push("ala");
            stack.Push("bala");

            var result = stack.Peek();

            Assert.That(stack.Count, Is.EqualTo(2));
        }


    }
}
