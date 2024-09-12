using System.Data;
using Npgsql;

class Program
{
    string sql = "Server=localhost;Port=5432;Database=WorkWithBase;User id = postgres; Password = ******;";

    private static void Main(string[] args)
    {
        Program program = new Program();
        program.SqlConnectionReader();
        Console.ReadLine();
    }
    private void SqlConnectionReader()
    {
        NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sql);
        npgsqlConnection.Open();
        NpgsqlCommand npgsqlCommand = new NpgsqlCommand();
        npgsqlCommand.Connection = npgsqlConnection;
        npgsqlCommand.CommandType = System.Data.CommandType.Text;
        npgsqlCommand.CommandText = "SELECT * FROM \"Clients\"";

        NpgsqlDataReader dataReader = npgsqlCommand.ExecuteReader();
        if (dataReader.HasRows)
        {
            DataTable data = new DataTable();
            data.Load(dataReader);
            foreach (DataRow row in data.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write(item + "\t");
                }
                Console.WriteLine();
            }
        }
        npgsqlConnection.Close();

    }
}