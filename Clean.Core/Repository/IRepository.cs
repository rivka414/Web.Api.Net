using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clean.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        // מחזיר משימה שמכילה רשימה
        Task<IEnumerable<T>> GetAllAsync();

        // מחזיר משימה שמכילה אובייקט בודד או null
        Task<T?> GetByIdAsync(int id);

        // הוספה לרוב מתבצעת אסינכרונית ב-EF (בגלל הצורך ב-Context)
        Task<T> AddAsync(T entity);

        // עדכון ומחיקה ב-Entity Framework בדרך כלל משנים רק את ה-State בזיכרון,
        // לכן הם יכולים להישאר סינכרוניים, וה-await יתבצע ב-SaveAsync.
        void Update(T entity);
        void Delete(T entity);
    }
}