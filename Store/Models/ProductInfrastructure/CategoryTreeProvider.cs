using Store.Utils;
using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Store.Models
{
    public class CategoryTreeProvider : ICategoryTreeProvider
    {
        private string ConnectionString { get; }
        public CategoryTreeProvider(IConnectionStringProvider connection)
        {
            ConnectionString = connection.ConnectionString;
            generateTree();
            setTreeRoot();
        }

        private void setTreeRoot()
        {
            Root = tree
                .Select(kvp=>kvp.Value)
                .Where(ct=>ct.ParentCategory == 0)
                .First();
        }

        Dictionary<int, Category> tree = new();

        private void generateTree()
        {
            SqlConnection conn = new(ConnectionString);

            List<Category> Ctg = conn.Query<Category>("Select * from categories").ToList();
            foreach (var i in Ctg)
            {

                tree[i.Id] = i;

                if (tree[i.Id].Children is null)
                    tree[i.Id].Children = new();

                if(i.ParentCategory is not 0)
                {
                    i.Parent = tree[i.ParentCategory];
                    tree[i.ParentCategory].Children.Add(i);
                }
            }
        }

        public Category Root { get; private set; }
    }
}
