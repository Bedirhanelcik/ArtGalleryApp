using System.Data.SqlClient;

namespace ArtGalleryApp
{
    public static class DatabaseHelper
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(
                @"Server=localhost\SQLEXPRESS;
                  Database=ArtGalleryDB;
                  Trusted_Connection=True;");
        }
    }
}
