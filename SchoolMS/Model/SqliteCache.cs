using System;
using System.Data.SQLite;
using Dapper;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SchoolMS.Model  
{
    public class SqliteCache
    {
        public string Key { get; set; }
        public object Value { get; set; }
        public int Expiry { get; set; }
       

        public object GetCache(string key)
        {

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(GetConnectionString()))
                {
                    return connection.Query<dynamic>("SELECT Value FROM KeyValueStore WHERE Key = @Key", new
                    {
                        Key = key
                    }).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
    
        }
        public bool SetCache(SqliteCache cache)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(GetConnectionString()))
                {
                    connection.Execute("INSERT INTO KeyValueStore VALUES(@key,@value,@expiry)", new { key = cache.Key, value = JsonConvert.SerializeObject(cache.Value), expiry = cache.Expiry});
                }
                return true;
            }
            catch(SQLiteException)
            {
                return false;
            }
           
        }

        public bool UpdateCache(string cacheKey,SqliteCache cache)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(GetConnectionString()))
                {
                    connection.Execute("UPDATE KeyValueStore SET Value = @value, Expiry = @expiry where Key = @key", new { value = JsonConvert.SerializeObject(cache.Value), expiry = cache.Expiry, key = cacheKey });
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }        
        }
       
        public void DeleteCache(int expiry)
        {
            using (SQLiteConnection connection = new SQLiteConnection(GetConnectionString()))
            {
                connection.Execute("DELETE FROM KeyValueStore where Expiry < @now", new { now = expiry });
            }
        }
        public string GetConnectionString()
        {
            string currentPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string pwd = currentPath.Remove(0, 6);
            string pat = @"dbcache.db";
            string absolutePath = System.IO.Path.Combine(pwd, pat);
            string connectionString = string.Format("Data Source={0}", absolutePath);
            return connectionString;
        }
    }
}