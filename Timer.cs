using System.Diagnostics;

namespace SVN.Debug
{
    public class Timer
    {
        private Stopwatch Stopwatch { get; } = new Stopwatch();

        private Timer()
        {
        }

        public static Timer Start()
        {
            var result = new Timer();
            result.Restart();
            return result;
        }

        public string Restart()
        {
            var result = this.Stop();
            this.Stopwatch.Restart();
            return result;
        }

        public string Stop()
        {
            this.Stopwatch.Stop();
            return this.ToString();
        }

        public override string ToString()
        {
            var time = this.Stopwatch.Elapsed;
            return $"{time.Hours:D2}:{time.Minutes:D2}:{time.Seconds:D2}.{time.Milliseconds:D3}";
        }
    }
}