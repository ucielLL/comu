using Comu.Helpers;
using Comu.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comu.Repository
{
    public sealed class CollectionDataRepository
    {
        SQLiteAsyncConnection connection;
        private static CollectionDataRepository _collectionDataRepository;


        public CollectionDataRepository()
        {
            connection =
                 new SQLiteAsyncConnection(Constants.DatabasePath,
                 Constants.Flags);
            connection.CreateTableAsync<Collections>();

        }
        public static CollectionDataRepository GetInstance()
        {
            if (_collectionDataRepository == null)
            {
                _collectionDataRepository = new CollectionDataRepository();
            }
            return _collectionDataRepository;
        }

        public async Task<bool> AddCollection(Collections collection)
        {
            if (collection == null) return false;
            if (await GetCollectionAsync(collection.NameCollection) == null)
            {
                collection.Color = $"#{GetRandom():X2}{GetRandom():X2}{GetRandom():X2}";

                await connection.InsertAsync(collection);
                return true;
            }
            return false;
        }
         int GetRandom() 
        {
            Random random = new Random();
            return random.Next(0, 255);
        }

        public async Task<List<Collections>> GetCollectionsAsycn ()
        {
            try 
            {
                if (await connection.Table<Collections>().CountAsync() ==0) return null;
              return await connection.Table<Collections>().ToListAsync();   
            }
            catch (Exception e) { return null; }

        }
      
       public async Task<bool> DeleteCollectionAsync(string collectionName)
        {
            try
            {
                var Rows = await connection.DeleteAsync<Collections>(collectionName);
                if (Rows >= 1)
                {
                    await CardRepostory.GetInstance().DeleteAsync(i => i.Collection == collectionName);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        async Task<Collections> GetCollectionAsync(string name)
        {
            try
            {
                return await connection.Table<Collections>().FirstOrDefaultAsync(X => X.NameCollection == name);
            }
            catch (Exception)
            {

                return null;
            }

        }
       
    }

    
}
