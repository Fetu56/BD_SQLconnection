namespace BD_SQLconnection
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Notes";
            System.Console.Title = name;
            SQLwork sql = new SQLwork();
            sql.Start(name);
        }
    }
}
