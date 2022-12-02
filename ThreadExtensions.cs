using System.Threading;
using System.Diagnostics;

namespace ThreadExtensions
{
    public static class Thread
    {
        public static void Wait(int pauseInSeconds)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (true)
            {
                if (stopwatch.ElapsedMilliseconds >= pauseInSeconds)
                {
                    break;
                }
                System.Threading.Thread.Sleep(1);
            }
        }
    }
}
