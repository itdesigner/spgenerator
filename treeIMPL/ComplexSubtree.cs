using System;
using System.Text;

namespace System.Collections.Generic
{
    /// <summary>
    /// Represents a hierarchy of objects or data.  ComplexSubtree is an alias for ComplexTree and ComplexTreeNode.
    /// </summary>
    public class ComplexSubtree<T> : ComplexTreeNode<T> where T : ComplexTreeNode<T>
    {
        public ComplexSubtree() { }
    }
}