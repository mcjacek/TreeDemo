using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TreeDemo
{
    public class TreeNode : IEnumerable<TreeNode>
    {
        private readonly Dictionary<string, TreeNode> _children =
                                            new Dictionary<string, TreeNode>();

        public readonly string ID;
        public TreeNode Parent { get; private set; }

        public TreeNode(string id)
        {
            this.ID = id;
        }
        public TreeNode GetChild(string id)
        {
            return this._children[id];
        }

        public void Add(TreeNode item)
        {
            if (item.Parent != null)
            {
                item.Parent._children.Remove(item.ID);
            }

            item.Parent = this;
            this._children.Add(item.ID, item);
        }

        public IEnumerator<TreeNode> GetEnumerator()
        {
            return this._children.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int CountOfChildren
        {
            get { return this._children.Count; }
        }

        string stringToReturn = string.Empty;
        public string GetDataString()
        {
            stringToReturn = "";
            BuildTree(this, 0);

            return stringToReturn;
        }

        private void BuildTree(TreeNode node, int depth)
        {
            stringToReturn +=  "".PadLeft(depth * 3) + node.ID + System.Environment.NewLine;

            foreach (var child in node._children)
            {
                BuildTree(child.Value, depth + 1);
            }
        }

        /// <summary>
        /// Get the sum of the branch lengths of this node and all its descendants.
        /// </summary>
        /// <returns></returns>
        public double TotalLength()
        {
            double tbr = 1;

            foreach (var child in _children)
            {
                tbr += child.Value.TotalLength();
            }
            return tbr;
        }

        /// <summary>
        /// Get the maximum dept of the tree
        /// </summary>
        /// <returns></returns>
        public double MaxDept()
        {
            double tbr = 1;

            foreach (var child in _children)
            {
                tbr += child.Value.TotalLength();
            }
            return tbr;
        }

        public List<TreeNode> Depth
        {
            get
            {
                List<TreeNode> path = new List<TreeNode>();
                foreach (var node in _children)
                {
                    List<TreeNode> tmp = node.Value.Depth;
                    if (tmp.Count > path.Count)
                    {
                        path = tmp;
                    }
                }
                path.Insert(0, this);
                return path;
            }
        }

        public List<string> GetLeafNames()
        {
            List<string> leafs = new List<string>();

            if(_children.Count == 0)
            {
                leafs.Add(ID);
            }

            foreach(var child in _children)
            {
                leafs.AddRange(child.Value.GetLeafNames());
            }

            return leafs;
        }

        /// <summary>
        /// Get the sum of the branch lengths from this node up to the root.
        /// </summary>
        public double UpstreamLength()
        {
            double tbr = 0;

            TreeNode nd = this;

            while (nd.Parent != null)
            {
                tbr += 1;
                nd = nd.Parent;
            }

            return tbr;
        }
    }
}