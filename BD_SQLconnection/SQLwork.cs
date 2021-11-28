using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BD_SQLconnection
{
    class SQLwork
    {
        private SqlConnection cn;
        public SQLwork(string name = "ALPC", string initDB = "DB_SHOP")
        {
            cn = new SqlConnection($"Data Source={name};Initial Catalog={initDB};Integrated Security=False;Trusted_Connection=true;");
        }
        public void Start(string TableName = "NOTES")
        {
            cn.Open();

            using (SqlCommand command = new SqlCommand($"CREATE TABLE {TableName}([id] INT IDENTITY, [name] VARCHAR(15) NOT NULL, [desc] TEXT NOT NULL, [date] DATETIME null)", cn))
            {
                try
                {
                    int res = command.ExecuteNonQuery();
                    if (res > 0)
                    {
                        Console.WriteLine("Table created");
                    }
                }
                catch (SqlException) { }
            }

            while (!Environment.HasShutdownStarted)
            {
                try
                {
                    Console.WriteLine($"Выберете действие(1 - введение значений, 2 - удаление значений, 3 - получить данные с таблицы {TableName}, 0 - выход):");
                    Option option = (Option)int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case Option.input:
                            Input(TableName);
                            break;
                        case Option.delete:
                            Delete(TableName, "[id]");
                            break;
                        case Option.get:
                            Get(TableName);
                            break;
                        case Option.exit:
                            return;
                        default:
                            break;
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally
                {
                    GC.Collect();
                }
            }
        }
        private bool Input(string tableNM)
        {
            bool res = false;
            Console.WriteLine($"Введите значение для вставки в таблицу {tableNM}(для выхода введите '!'):");
            string inp = Console.ReadLine();
            List<string> rowsValues = new List<string>();
            while (inp != "!")
            {
                rowsValues.Add(inp);
                inp = Console.ReadLine();
            }
            string comm = $"INSERT INTO {tableNM} VALUES";
            rowsValues.ForEach(x => comm += $"('{x.Split(' ')[0]}', '"+(x.Split(' ').Length > 1 ? x.Split(' ')[1] : 0)+$"', '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}'),");
            comm = comm.Remove(comm.Length - 1);
            using (SqlCommand command = new SqlCommand(comm, cn))
            {
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    res = true;
                }
            }
            return res;
        }
        private bool Get(string tableNM)
        {
            bool res = false;
            List<KeyValuePair<string, string>> valueList = new List<KeyValuePair<string, string>>();
            using (SqlCommand command = new SqlCommand($"SELECT * FROM {tableNM}", cn))
            {
                var data = command.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        object id = data.GetValue(0);
                        StringBuilder val = new StringBuilder();
                        for(int i = 1; i < data.FieldCount; i++)
                        {
                            val.Append("\t"+data.GetValue(i));
                        }
                        valueList.Add(new KeyValuePair<string, string>(id.ToString(), val.ToString())); ;
                    }
                }
                data.Close();
            }
            if(valueList.Count > 0)
            {
                Console.WriteLine($"Выберите индекс для получения данных, от 0 до {valueList.Count-1} или для вывода всех заметок введите \'!\':");
                string inp = Console.ReadLine();
                if(inp.StartsWith("!"))
                {
                    valueList.ForEach(InputNote);
                    res = true;
                }
                else if(int.Parse(inp) < valueList.Count)
                {
                    InputNote(valueList[int.Parse(inp)]);
                    res = true;
                }
                Console.WriteLine();
            }
            return res;
        }
        private void InputNote(KeyValuePair<string, string> pair)
        {
            Console.WriteLine("{0}.\t\t{1}", pair.Key, pair.Value);
        }
        private bool Delete(string tableNM, string idColName)
        {
            bool res = false;
            Console.WriteLine($"Введите id для удаления в таблице {tableNM}(для выхода введите '!'):");
            string inp = Console.ReadLine();
            List<string> rowsValues = new List<string>();
            while (inp != "!")
            {
                if (Char.IsNumber(inp, 0))
                    rowsValues.Add(inp);
                inp = Console.ReadLine();
            }
            string comm = $"DELETE FROM {tableNM} WHERE ";
            rowsValues.ForEach(x => comm += $"{idColName}='{x}' OR ");
            comm = comm.Remove(comm.Length - 4, 4);

            using (SqlCommand command = new SqlCommand(comm, cn))
            {
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    res = true;
                }
            }
            return res;
        }
    }
}
