using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Iterator
{
    abstract class IteratorAggregate : IEnumerable
    {
        // Returns an Iterator or another IteratorAggregate for the implementing
        // object.
        public abstract IEnumerator GetEnumerator();
    }
}
