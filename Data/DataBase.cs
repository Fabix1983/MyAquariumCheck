using MyAquariumCheck.Models;
using SQLite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAquariumCheck.Data
{
    internal class DataBase
    {
        private readonly SQLiteAsyncConnection connessione;
        public DataBase()
        {
            Batteries.Init();

            var dataDir = FileSystem.AppDataDirectory;
            var databasePath = Path.Combine(dataDir, "AquariumCheckDB.db");

            var dbStringaConnessione = new SQLiteConnectionString(databasePath);
            connessione = new SQLiteAsyncConnection(dbStringaConnessione);

            var risposta = InizializzaDB();
        }

        private async Task InizializzaDB()
        {
            await connessione.CreateTableAsync<CheckItem>();
        }

        public async Task<int> AggiungiCheckItem(CheckItem item)
        {
            return await connessione.InsertAsync(item);
        }

        public async Task<List<CheckItem>> LeggiCheckItem()
        {
            return await connessione.Table<CheckItem>().OrderByDescending(t => t.Data).ToListAsync();
        }

        public async Task<List<CheckItem>> LeggiCheckItemID(long idrecord)
        {
            return await connessione.Table<CheckItem>().Where(x => x.Id == idrecord).OrderByDescending(t => t.Data).ToListAsync();
        }

        public async Task<int> EliminaCheckItem(CheckItem daEliminare)
        {
            return await connessione.DeleteAsync(daEliminare);
        }
    }
}
