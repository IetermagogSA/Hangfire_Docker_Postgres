namespace Hangfire_Docker_Postgres.Hangfire
{
    public class JobMethods
    {
        public static void RunTask()
        {
            Console.WriteLine($"Hangfire job executed at {DateTime.Now}");
        }
    }
}
