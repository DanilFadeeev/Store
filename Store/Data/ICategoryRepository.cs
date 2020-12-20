using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data
{
    public interface ICategoryRepository
    {
        Task<List<string>> AllCategories();
        Task<List<string>> GetChildrenCategories(string category);
         /// <summary>
         /// check if category have concrete parent
         /// </summary>
         /// <param name="compare">category what you check</param>
         /// <param name="parent">parent what you try search</param>
         /// <returns>is potential parent is really parent</returns>
        Task<bool> IsParentCategory(string compare, string parent);
        Task<List<string>> GetNotAbstractChildren(string category);
    }
}
