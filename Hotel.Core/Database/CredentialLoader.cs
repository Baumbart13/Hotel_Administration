using System.Text;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Fluent;

namespace Hotel.Core.Database;

public class CredentialLoader
{
    protected static NLog.Logger logger = LogManager.GetCurrentClassLogger();
    public class DatabaseCredentials
    {
        public const char CsvSeparator = ',';
        public static readonly string LineSeparator = Environment.NewLine;
        
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string DatabaseName { get; private set; }
        public string Hostname { get; private set; }

        public DatabaseCredentials(string host, string user, string pass, string database)
        {
            Username = user;
            Hostname = host;
            Password = pass;
            DatabaseName = database;
        }
    }

    public static DatabaseCredentials LoadDatabase(string filepath)
    {
        var dbCreds = new DatabaseCredentials("", "", "", "");
        if (!Directory.Exists(filepath))
        {
            logger.Fatal(new FileNotFoundException("Crucial file not found", filepath));
            return dbCreds;
        }
        var user = "";
        var pass = "";
        var database = "";
        var host = "";

        var reader = File.OpenText(filepath);
        var readLine = reader.ReadLine();
        if (readLine == null)
        {
            logger.Fatal(new IOException("Corrupted database file!"));
            return dbCreds;
        }

        if (!readLine.Contains("hostname,user,password,database"))
        {
            logger.Fatal(new IOException("Corrupted database file!"));
            return dbCreds;
        }

        var splittedLine = reader.ReadLine().Trim().Split(DatabaseCredentials.CsvSeparator);
        if (splittedLine.Length != 4)
        {
            logger.Fatal(new IOException("Corrupted database file!"));
            return dbCreds;
        }

        host = splittedLine[0];
        user = splittedLine[1];
        pass = splittedLine[2];
        database = splittedLine[3];

        dbCreds = new DatabaseCredentials(host, user, pass, database);
        return dbCreds;
    }
}