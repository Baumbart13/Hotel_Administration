using NLog;

namespace Hotel.Core.Database;

public class CredentialLoader
{
    protected static NLog.Logger logger = LogManager.GetCurrentClassLogger();
    public const char CsvSeparator = ',';

    protected CredentialLoader()
    {
        logger.Error("How did you call this? Go away!!");
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
        Environment.Exit(-1);
    }

    public enum DatabaseType
    {
        MySQL, MongoDB, MicrosoftSQL, MsSQL
    }
    
    public class DatabaseCredentials
    {
        public static readonly string LineSeparator = Environment.NewLine;
        
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string DatabaseName { get; private set; }
        public string Hostname { get; private set; }
        public DatabaseType DbType { get; private set; }

        public DatabaseCredentials(string host = "", string user = "", string pass = "", string database = "", DatabaseType dbType = DatabaseType.MySQL)
        {
            Username = user;
            Hostname = host;
            Password = pass;
            DatabaseName = database;
            DbType = dbType;
        }
    }

    public static DatabaseCredentials LoadDatabase(string filepath = "database.csv")
    {
        var dbCreds = new DatabaseCredentials("", "", "", "");
        if (!Directory.Exists(filepath))
        {
            logger.Fatal(new FileNotFoundException("Crucial file not found", filepath));
            return dbCreds;
        }

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

        var splittedLine = reader.ReadLine().Trim().Split(CsvSeparator);
        if (splittedLine.Length < 4)
        {
            logger.Fatal(new IOException("Corrupted database file!"));
            return dbCreds;
        }

        var host = splittedLine[0];
        var user = splittedLine[1];
        var pass = splittedLine[2];
        var database = splittedLine[3];

        if (splittedLine.Length == 5)
        {
            Enum.TryParse(splittedLine[4], true, out DatabaseType dbType);
            dbCreds = new DatabaseCredentials(host, user, pass, database, dbType);
        }
        else
        {
            dbCreds = new DatabaseCredentials(host, user, pass, database);
        }
        return dbCreds;
    }
}