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
            var family = new TreeNode("Alfred")
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

            //var family= new TreeNode("Alfred");
            //    var tata = new TreeNode("Aleksander");
            //   .Add(tata);
            //        var jacek = new TreeNode("Jacek");
            //        var wojciech = new TreeNode("Wojciech");
            //        tata.Add(jacek);
            //        tata.Add(wojciech);
            //            var wiktoria = new TreeNode("Wiktoria");
            //            wojciech.Add(wiktoria);

            //var wujek = new TreeNode("Witold");
            //   .Add(wujek);
            //        var tomasz = new TreeNode("Tomasz");
            //        var beata = new TreeNode("Beata");
            //        wujek.Add(tomasz);
            //        wujek.Add(beata);

            var treeString = family.GetDataString();
        }
    }
}
