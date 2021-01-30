using System;
using System.Diagnostics.Contracts;

namespace DesignPattern.Prototype
{
    /*
     * 原型模式是一种创建型设计模式， 使你能够复制已有对象， 而又无需使代码依赖它们所属的类。
     * dotnet 中有两个数据结构 Stack/Queue 这两个数据都实现了 ICloneable 接口，内部实现了深复制（拷贝）
     * 详细可以参考： https://referencesource.microsoft.com/#mscorlib/system/collections/stack.cs,6acda10c5f8b128e
     */

    public class Stack : ICloneable
    {
        private object[] _array;     // Storage for stack elements
        private int _size;           // Number of items in the stack.
        private int _version;        // Used to keep enumerator in sync w/ collection.

        private const int _defaultCapacity = 10;

        public Stack()
        {
            _array = new object[_defaultCapacity];
            _size = 0;
            _version = 0;
        }

        // Create a stack with a specific initial capacity.  The initial capacity
        // must be a non-negative number.
        public Stack(int initialCapacity)
        {
            if (initialCapacity < 0)
                throw new ArgumentOutOfRangeException();
            Contract.EndContractBlock();
            if (initialCapacity < _defaultCapacity)
                initialCapacity = _defaultCapacity;  // Simplify doubling logic in Push.
            _array = new object[initialCapacity];
            _size = 0;
            _version = 0;
        }

        /// <summary>
        /// 原型模式实现继承的接口Clone方法
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Contract.Ensures(Contract.Result<object>() != null);
            Stack s = new Stack(_size);
            s._size = _size;
            Array.Copy(_array, 0, s._array, 0, _size);
            s._version = _version;
            return s;
        }
    }
}
