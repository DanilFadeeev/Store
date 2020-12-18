using Dapper;
using Store.Models;
using Store.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private string connectionString { get; }
        public Category root { get; }

        public CategoryRepository(IConnectionStringProvider Connection, ICategoryTreeProvider tree)
        {
            connectionString = Connection.ConnectionString;
            root = tree.Root;
        }

        public async Task<List<string>> AllCategories()
        {
            using SqlConnection conn = new(connectionString);
            var result = (await conn.QueryAsync<string>("select name from Categories")).ToList();
            return result;
        }

        public async Task<List<string>> GetChildrenCategories(string category)
        {
            List<string> result = new();
            foreach(var i in await AllCategories())
            {
                if (await IsParentCategory(i, category))
                    result.Add(i);
            }
            return result;
        }

        public async Task<List<string>> GetNotAbstractChildren(string category) 
        {
            var result = (await GetChildrenCategories(category))
                .Where(c =>
                {
                    var child = searchNodeByName(c, root).Children;
                    return child is null
                 || searchNodeByName(c, root).Children.Count == 0;
                })
                .ToList() ;
            return result;
        }

        public async Task<bool> IsParentCategory(string compare, string parent)
        {
            Category cmp = searchNodeByName(compare, root);
            while(cmp.Parent is not null)
            {
                if (cmp.Parent.Name == parent)
                    return true;
                cmp = cmp.Parent;
            }
            return false;
        }

        private Category searchNodeByName(string name, Category startNode)
        {
            if (startNode is null)
                startNode = root;

            if (startNode.Name == name)
                return startNode;

            foreach (var i in startNode.Children) {
                var searchInChid = searchNodeByName(name, i);
                if (searchInChid is not null)
                    return searchInChid;
            }
            return null;
        }
    }
}
