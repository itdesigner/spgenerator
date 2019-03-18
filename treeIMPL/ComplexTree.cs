using System;
using System.Text;

namespace System.Collections.Generic
{
    /// <summary>
    /// Represents a hierarchy of objects or data.  ComplexTree is a root-level alias for ComplexSubtree and ComplexTreeNode.
    /// </summary>
    public class ComplexTree<T> : ComplexTreeNode<T> where T : ComplexTreeNode<T>
    {
        public ComplexTree() { }
    }
}