using NanMoiJeSuisCoach.Modele;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachV1.outils
{
    class SQLiteDb
    {
        public const string DatabaseFilename = "dbcoach.db3";

        public static string DatabasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        public const SQLiteOpenFlags Flags = SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache;

        private SQLiteAsyncConnection connection;
        
        private async Task Initialize()
        {
            if (connection is not null)
                return;

            connection = new(DatabasePath);

            await connection.CreateTableAsync<Profil>();
        }

        public async Task<int> SaveItemAsync(Profil profil)
        {
            await Initialize();

            if (profil.Id != 0)
            {
                return await connection.UpdateAsync(profil);
            }
            else
            {
                return await connection.InsertAsync(profil);
            }
        }

        public async Task<Profil> GetLastItemAsync()
        {
            await Initialize();
            return await connection.FindWithQueryAsync<Profil>("SELECT * FROM Profil ORDER BY dateCreation DESC");
        }

        public async Task<List<Profil>> QueryGetAllItemsAsync()
        {
            await Initialize();
            return await connection.QueryAsync<Profil>("SELECT * FROM Profil ORDER BY id DESC");
        }
    }
}
