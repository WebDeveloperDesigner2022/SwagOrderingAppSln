using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using SwagOrderingApp.Models;

namespace SwagOrderingApp
{
    public class SwagDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<SwagDatabase> Instance = new AsyncLazy<SwagDatabase>(async () =>
        {
            var instance = new SwagDatabase();
            CreateTableResult result = await Database.CreateTableAsync<SwagItem>();
            return instance;
        });

        public SwagDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<SwagItem>> GetItemsAsync()
        {
            return Database.Table<SwagItem>().ToListAsync();
        }

        public Task<List<SwagItem>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<SwagItem>("SELECT * FROM [SwagItem] WHERE [Done] = 0");
        }

        public Task<SwagItem> GetItemAsync(int id)
        {
            return Database.Table<SwagItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(SwagItem item)
        {
            return Database.InsertAsync(item);

         /*   if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }*/
        }

        public Task<int> DeleteItemAsync(SwagItem item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
