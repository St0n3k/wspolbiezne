using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Data
{
    internal class Logger
    {
        private static List<Ball> balls;
        private Stopwatch watch = new Stopwatch();
        public Logger(List<Ball> b) {
            balls = b;
            Thread t = new Thread(() =>
            {
                watch.Start();
                while (true)
                {
                    if (watch.ElapsedMilliseconds >= 5)
                    {
                        watch.Restart();
                        using (StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + "\\log.txt", true))
                        {
                            string stamp = ($"Log started {DateTime.UtcNow:o}");
                            foreach (Ball ball in balls)
                            {
                                writer.WriteLine(stamp + JsonSerializer.Serialize(ball));
                            }
                        }
                    }
                }
            })
            {
                IsBackground = true
            };
            t.Start();
        }

        public void stop() {
            watch.Reset();
            watch.Stop();
        }
    }
}
