namespace Hotel.Core.Database;

public abstract class MySqlDatabase : Database
{
    public MySqlDatabase(string hostname, string user, string password, string database)
        : base(hostname, user, password, database)
    { }

    public override void Connect()
    {
        throw new NotImplementedException();
    }

    public override void Disconnect()
    {
        throw new NotImplementedException();
    }
}