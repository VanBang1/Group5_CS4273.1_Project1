using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Group5_QLCGP
{
    public class Tree
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParenetId { get; set; }
        public string img { get; set; }
    }
    public class TreeRecursion
    {
        List<Tree> allTreeItems;
        public const string OPEN_LIST_TAG = "{";
        public const string CLOSE_LIST_TAG = "}";
        public const string OPEN_LIST_ITEM_TAG = " ";
        public const string CLOSE_LIST_ITEM_TAG = " ";

        public TreeRecursion()
        {
            allTreeItems = GetTreeItems();
        }
        public List<Tree> GetTreeItems()
        {
            List<Tree> TreeItmes = new List<Tree>();
            Tree item1 = new Tree { Id = 1, Name = "Item1:" };
            Tree item2 = new Tree { Id = 2, Name = "Item2:" };
            Tree item3 = new Tree { Id = 3, Name = "Item2_1:", ParenetId = 2 };
            Tree item4 = new Tree { Id = 4, Name = "Item2_2:", ParenetId = 2 };
            Tree item5 = new Tree { Id = 5, Name = "Item2_2_1:", ParenetId = 4 };
            Tree item6 = new Tree { Id = 6, Name = "Item2_2_2:", ParenetId = 4 };
            Tree item7 = new Tree { Id = 7, Name = "Item2_2_1_1:", ParenetId = 5 };
            Tree item8 = new Tree { Id = 8, Name = "Item1_1:", ParenetId = 1 };

            TreeItmes.Add(item1);
            TreeItmes.Add(item2);
            TreeItmes.Add(item3);
            TreeItmes.Add(item4);
            TreeItmes.Add(item5);
            TreeItmes.Add(item6);
            TreeItmes.Add(item7);
            TreeItmes.Add(item8);

            return TreeItmes;

        }

        public string GenerateTreeUi()
        {
            var strBuilder = new StringBuilder();
            List<Tree> parentItems = (from a in allTreeItems where a.ParenetId == 0 select a).ToList();
            strBuilder.Append(OPEN_LIST_TAG);
            foreach (var parentcat in parentItems)
            {
                strBuilder.Append(OPEN_LIST_ITEM_TAG);
                strBuilder.Append(parentcat.Name);
                List<Tree> childItems = (from a in allTreeItems where a.ParenetId == parentcat.Id select a).ToList();
                if (childItems.Count > 0)
                    AddChildItem(parentcat, strBuilder);
                strBuilder.Append(CLOSE_LIST_ITEM_TAG);
            }
            strBuilder.Append(CLOSE_LIST_TAG);
            return strBuilder.ToString();
        }

        private void AddChildItem(Tree childItem, StringBuilder strBuilder)
        {
            strBuilder.Append(OPEN_LIST_TAG);
            List<Tree> childItems = (from a in allTreeItems where a.ParenetId == childItem.Id select a).ToList();
            foreach (Tree cItem in childItems)
            {
                strBuilder.Append(OPEN_LIST_ITEM_TAG);
                strBuilder.Append(cItem.Name);
                List<Tree> subChilds = (from a in allTreeItems where a.ParenetId == cItem.Id select a).ToList();
                if (subChilds.Count > 0)
                {
                    AddChildItem(cItem, strBuilder);
                }
                strBuilder.Append(CLOSE_LIST_ITEM_TAG);
            }
            strBuilder.Append(CLOSE_LIST_TAG);
        }
    }
}