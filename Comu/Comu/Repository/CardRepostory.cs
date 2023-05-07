using Comu.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Comu.Repository
{
    sealed class CardRepostory
    {
        SQLiteAsyncConnection connection;
        private static CardRepostory _cardData;
        public CardRepostory()
        {
            connection =
                 new SQLiteAsyncConnection(Constants.DatabasePath,
                 Constants.Flags);
            connection.CreateTableAsync<CardData>();

        }
        public static CardRepostory GetInstance() 
        {
            if (_cardData == null)
            {
                  _cardData = new CardRepostory();
            }
            return _cardData;
        }

        public async Task<bool> AddCardAsync(CardData card) 
        {
            try 
            {
                if (card == null) return false;

                await connection.InsertAsync(card);
                return true;
            }
            catch (Exception) { return false; } 
               
        }

        public async Task<bool> DeleteAsync(int Id) 
        {
            try 
            {
                await connection.DeleteAsync(Id);   
                return true;    
            }catch (Exception) { return false; }
        }
        public async Task<bool> DeleteAsync(Expression<Func<CardData, bool>> predicate) 
        {
            try 
            {
                if(await connection.Table<CardData>().DeleteAsync(predicate) >= 1) return true;
                return false;
            }catch (Exception) { return false; }
        }

        public async Task<List<CardData>> GetCards(string collectionName)
        {
            try
            {
                List<CardData> cards = new List<CardData>();
                cards  = await connection.Table<CardData>().Where(i => i.Collection == collectionName).ToListAsync();
                return cards;
            }
            catch (Exception) 
            {
                return null;
            }
        }


    }
}
