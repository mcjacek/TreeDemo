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
                    new TreeNode("Jacek")
                    {
                        new TreeNode("Adam"),
                        new TreeNode("Eryk")
                    },
                    new TreeNode("Wojciech")
                    {
                        new TreeNode("Wiktoria"),
                        new TreeNode("Kajetan")
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
            Assert.AreEqual(2, family.CountOfChildren);
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

        [TestMethod]
        public void FamilyCreated_TotalNumberOfPeople_CorrentNumberReturned()
        {
            Assert.AreEqual(11, family.TotalLength());
        }


        [TestMethod]
        public void FamilyCreated_MaxDepth_CorrentNumberReturned()
        {
            Assert.AreEqual(4, family.Depth.Count);
        }

        [TestMethod]
        public void FamilyCreated_GetLeafNames_CorrentLeafsReturned()
        {
            var leafs = family.GetLeafNames();

            Assert.AreEqual(6, leafs.Count());

            Assert.IsTrue(leafs.Contains("Adam"));
        }

        [TestMethod]
        public void FamilyCreated_Getbranch_CorrentLengthReturned()
        {
            Assert.AreEqual(2, family.GetChild("Aleksander").GetChild("Jacek").UpstreamLength());
        }
    }
}
