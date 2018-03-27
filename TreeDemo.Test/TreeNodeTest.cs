using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace TreeDemo.Test
{
    [TestClass]
    public class TreeNodeTest
    {
        TreeNode family = null;
        public TreeNodeTest()
        {
            family = new TreeNode("Alfred")
            {
                new TreeNode("Aleksander")
                {
                    new TreeNode("Jacek"),
                    new TreeNode("Wojciech")
                    {
                        new TreeNode("Wiktoria")
                    }
                },
                new TreeNode("Witold")
                {
                    new TreeNode("Tomasz"),
                    new TreeNode("Beata")
                }
            };
        }

        [TestMethod]
        public void FamilyCreated_AlfredsChildreCount_CorrectNumberOfhildrenReturned()
        {
            Assert.AreEqual(2, family.Count);
        }

        [TestMethod]
        public void FamilyCreated_AlfredsChildreReturned_CorrectChildrenNamesReturned()
        {
            List<string> alfredsChildren = new List<string>() { "Aleksander", "Witold" };
            foreach(var child in family)
            {
                var found = alfredsChildren.Exists(x => x.Equals(child.ID));
                Assert.IsTrue(found);
            }
   
        }
    }
}
