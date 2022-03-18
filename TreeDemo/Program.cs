using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var family = new TreeNode("Alfred")
            //{
            //    new TreeNode("Aleksander")
            //    {
            //        new TreeNode("Jacek")
            //        {
            //            new TreeNode("Adam"),
            //            new TreeNode("Eryk")
            //        },
            //        new TreeNode("Wojciech")
            //        {
            //            new TreeNode("Wiktoria"),
            //            new TreeNode("Kajetan")
            //        }
            //    },
            //    new TreeNode("Witold")
            //    {
            //        new TreeNode("Tomasz"),
            //        new TreeNode("Beata")
            //    }
            //};

            var family = new TreeNode("Alfred");
            var tata = new TreeNode("Aleksander");
            family.Add(tata);
            var jacek = new TreeNode("Jacek");
            var wojciech = new TreeNode("Wojciech");
            tata.Add(jacek);
            var adam = new TreeNode("Adam");
            var eryk = new TreeNode("Eryk");
            jacek.Add(adam);
            jacek.Add(eryk);
            tata.Add(wojciech);
            var wiktoria = new TreeNode("Wiktoria");
            var kajetan = new TreeNode("Kajetan");
            wojciech.Add(wiktoria);
            wojciech.Add(kajetan);

            var wujek = new TreeNode("Witold");
            family.Add(wujek);
            var tomasz = new TreeNode("Tomasz");
            var beata = new TreeNode("Beata");
            wujek.Add(tomasz);
            wujek.Add(beata);

            var treeString = family.GetDataString();
        }
    }
}
