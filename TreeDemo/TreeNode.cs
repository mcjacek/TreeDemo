using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TreeDemo
{
    class TreeNode : IEnumerable<TreeNode>
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

        public int Count
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
    }
}
