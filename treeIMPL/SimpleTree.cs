using System;
using System.Text;

namespace System.Collections.Generic
{
    /// <summary>
    /// Represents a hierarchy of objects or data.  SimpleTree is a root-level alias for SimpleTree and SimpleSubtreeNode.
    /// </summary>
    public class SimpleTree<T> : SimpleTreeNode<T>
    {
        public SimpleTree() { }
    }
}