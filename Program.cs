using System.Data;
using Npgsql;

class Program
{
    string sql = "Server=localhost;Port=5432;Database=WorkWithBase;User id = postgres; Password = Umarjon;";

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
            int width = 15; 
            // malumotlarri chiqarish
            foreach (DataColumn column in data.Columns)
            {
                Console.Write(column.ColumnName.PadRight(width));
            }
            Console.WriteLine();

            foreach (DataRow row in data.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write(item.ToString().PadRight(width));
                }
                Console.WriteLine();
            }

        }
        npgsqlConnection.Close();

    }
}