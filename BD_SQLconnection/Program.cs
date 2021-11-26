using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BD_SQLconnection
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection cn = new SqlConnection("Data Source=ALPC;Initial Catalog=DB_SHOP;Integrated Security=False;Trusted_Connection=true;"))
            {
                cn.Open();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Выберете действие(1 - введение значений, 2 - удаление значений, 3 - получить данные с таблицы брендов, 0 - выход):");
                        string option = Console.ReadLine();
                        switch (option)
                        {
                            case "1":
                                {
                                    Console.WriteLine("Введите значение для вставки в таблицу брендов(для выхода введите '!'):");
                                    string inp = Console.ReadLine();
                                    List<string> rowsValues = new List<string>();
                                    while (inp != "!")
                                    {
                                        rowsValues.Add(inp);
                                        inp = Console.ReadLine();
                                    }
                                    string comm = "INSERT INTO BRANDS VALUES";
                                    rowsValues.ForEach(x => comm += $"('{x}'),");
                                    comm = comm.Remove(comm.Length - 1);
                                    using (SqlCommand command = new SqlCommand(comm, cn))
                                    {
                                        int rows = command.ExecuteNonQuery();
                                        if (rows > 0)
                                        {
                                            Console.WriteLine(rows + " ADDED!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("ERROR");
                                        }
                                    }

                                }
                                break;
                            case "2":
                                {
                                    Console.WriteLine("Введите id для удаления в таблице брендов(для выхода введите '!'):");
                                    string inp = Console.ReadLine();
                                    List<string> rowsValues = new List<string>();
                                    while (inp != "!")
                                    {
                                        if (Char.IsNumber(inp, 0))
                                            rowsValues.Add(inp);
                                        inp = Console.ReadLine();
                                    }
                                    string comm = "DELETE FROM BRANDS WHERE ";
                                    rowsValues.ForEach(x => comm += $"brand_id='{x}' OR ");
                                    comm = comm.Remove(comm.Length - 4, 4);

                                    using (SqlCommand command = new SqlCommand(comm, cn))
                                    {
                                        int rows = command.ExecuteNonQuery();
                                        if (rows > 0)
                                        {
                                            Console.WriteLine(rows + " DELETED!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("ERROR");
                                        }
                                    }
                                }
                                break;
                            case "3":
                                using (SqlCommand command = new SqlCommand("SELECT * FROM BRANDS", cn))
                                {
                                    var data = command.ExecuteReader();
                                    if (data.HasRows)
                                    {
                                        Console.WriteLine("{0}\t{1}", data.GetName(0), data.GetName(1));

                                        while (data.Read())
                                        {
                                            object id = data.GetValue(0);
                                            object name = data.GetValue(1);

                                            Console.WriteLine("{0}\t\t{1}", id, name);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("ERROR");
                                    }
                                    data.Close();
                                }
                                break;
                            case "0":
                                Environment.Exit(0);
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                    
                }
                
            }
        }
    }
}
