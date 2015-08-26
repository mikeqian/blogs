using System;
using System.Configuration;
using Mono.Data.Sqlite;
using System.IO;

namespace DataAccess
{
    public static class ConnectionManager
    {
        public static string DbFile
        {
            get { return ConfigurationManager.AppSettings["db"]; }
        }


        public static SqliteConnection GetConnection()
        {
            if (!File.Exists(DbFile))
            {
                throw new Exception("db file does not exist,pls check the config file.");
            }

            return new SqliteConnection("Data Source=" + DbFile);
        }
    }
}