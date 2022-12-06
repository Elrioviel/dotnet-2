using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
    public class BinarySearchTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private Node<T> root;
        public Node<T> GetRoot()
        {
            return root;
        }

        public void Add(T data, Node<T> node)
        {
            var nodeToAdd = new Node<T>(data);
            if (nodeToAdd.CompareTo(node) > 0)
            {
                if (node.RightNode == null)
                {
                    node.RightNode = nodeToAdd;
                }
                else
                {
                    Add(data, node.RightNode);
                }
            }
            if (nodeToAdd.CompareTo(node) < 0)
            {
                if (node.LeftNode == null)
                {
                    node.LeftNode = nodeToAdd;
                }
                else
                {
                    Add(data, node.LeftNode);
                }
            }
        }

        public void Add(T data)
        {
            var nodeToAdd = new Node<T>(data);
            if (root == null)
            {
                root = nodeToAdd;
            }
            var currentNode = root;
            while (currentNode != null)
            {
                if (nodeToAdd.Data.CompareTo(currentNode.Data) > 0)
                {
                    if (currentNode.RightNode != null)
                    {
                        currentNode = currentNode.RightNode;
                        continue;
                    }
                    currentNode.RightNode = nodeToAdd;
                    continue;
                }
                if (nodeToAdd.Data.CompareTo(currentNode.Data) < 0)
                {
                    if (currentNode.LeftNode != null)
                    {
                        currentNode = currentNode.LeftNode;
                        continue;
                    }
                    currentNode.LeftNode = nodeToAdd;
                    continue;
                }
                return;
            }
        }

        public void AddRange(IEnumerable<T> dataArray)
        {
            foreach (var element in dataArray)
            {
                Add(element);
            }
        }

        public Node<T> Find(T value, Node<T> source)
        {
            if (source == null) return null;
            var nodeToFind = new Node<T>(value);
            if (nodeToFind.CompareTo(source) == 0)
            {
                return source;
            }
            if (nodeToFind.CompareTo(source) > 0)
            {
                return Find(value, source.RightNode);
            }
            if (nodeToFind.CompareTo(source) < 0)
            {
                return Find(value, source.LeftNode);
            }
            return null;
        }

        public IEnumerable<T> InOrderTraversal(Node<T> node)
        {
            if (node == null)
            {
                yield break;
            }
            foreach (var item in InOrderTraversal(node.LeftNode))
            {
                yield return item;
            }
            yield return node.Data;
            foreach (var item in InOrderTraversal(node.RightNode))
            {
                yield return item;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (root.Data == null)
            {
                return new List<T>(0).GetEnumerator();
            }
            return InOrderTraversal(root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
