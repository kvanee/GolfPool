using System;
using System.Threading;
using GolfPool.App_Start;
using GolfPool.Models;

[assembly: WebActivator.PreApplicationStartMethod(typeof(GolferScoreMonitor), "Start")]

namespace GolfPool.App_Start
{
    public static class GolferScoreMonitor
    {
        private static readonly Timer _timer = new Timer(OnTimerElapsed);
        private static readonly JobHost _jobHost = new JobHost();

        public static void Start()
        {
            _timer.Change(TimeSpan.Zero, TimeSpan.FromSeconds(240));
        }

        private static void OnTimerElapsed(object sender)
        {
            _jobHost.DoWork(() => PlayerAdministration.UpdateScores());
        }
    }
}