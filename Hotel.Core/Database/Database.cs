using System.Data.Common;

namespace Hotel.Core.Database;

public abstract class Database
{
    protected static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
    protected DbConnection mConnection;

    protected string mHostname = "";
    protected string mUsername = "";
    protected string mPassword = "";
    protected string mDatabaseName = "";
    
    public string Hostname => this.mHostname;

    public string Username => this.mUsername;

    public string DatabaseNameName => mDatabaseName;

    public Database(string hostname, string username, string password, string databaseName)
    {
        if (hostname.Length < 1 ||
            username.Length < 1 ||
            password.Length < 1 ||
            databaseName.Length < 1)
        {
            hostname = username = password = databaseName = "FATAL ERROR: Wrong credentials!";
            logger.Fatal(hostname);
            return;
        }

        this.mHostname = hostname;
        this.mUsername = username;
        this.mPassword = password;
        this.mDatabaseName = databaseName;
    }

    public abstract void Connect();
    public abstract void Disconnect();
    public abstract Database Clone();
    public abstract void CreateDatabase(string database);

    public void CreateDatabase()
    {
        this.CreateDatabase(this.mDatabaseName);
    }

    public override string ToString()
    {
        return $"Hostname:{mHostname};Username:{mUsername};Password:{mPassword};DatabaseName:{mDatabaseName};";
    }
}