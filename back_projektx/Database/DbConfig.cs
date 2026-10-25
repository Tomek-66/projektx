namespace back_projektx.Database
{
    public static class DbConfig
    {
        public static string ReleaseServer => "db_projektx";
        public static string ReleasePort => "5432";
        public static string ReleaseDatabase => "projektxdb";
        public static string ReleaseUser => "userpostgres";
        public static string ReleasePassword => "MyProduction123.";


        public static string DebugServer => "localhost";
        public static string DebugPort => "5432";
        public static string DebugDatabase => "projektxdebug";
        public static string DebugUser => "postgres";
        public static string DebugPassword => "Ziomek123.";



        public static string createConnectionString()
        {
            string conn = String.Format("Server={0};Port={1};Database={2};User Id={3};Password={4};", ReleaseServer, ReleasePort, ReleaseDatabase, ReleaseUser, ReleasePassword);

#if DEBUG
            conn = String.Format("Server={0};Port={1};Database={2};User Id={3};Password={4};", DebugServer, DebugPort, DebugDatabase, DebugUser, DebugPassword);
#endif

            return conn;
        }
    }
}
