using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Victor4Library.Util;

namespace Victor4Library.Models
{
    public class Pomodoro : IStandard
    {
        public delegate void PomoProgramme();
        public event PomoProgramme OnPomodoroStart;
        public event PomoProgramme OnPomodoroBreak;
        public event PomoProgramme OnPomodoroHalt;
        Timer timer;
        public Pomodoro()
        {
            this.SessionId = Utilities.GenerateId(7);
            this.WorkDuration = 5000;//25mins
            this.ShortBreakDuration = 1000;//5minsbreak
            this.LongBreakDuration = 10000;//25mins
            this.Count = 0;

            timer = new Timer();
            timer.Interval = this.timerInterval();
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Notify();
        }
        public string SessionId { get; set; }
        public int WorkDuration { get; set; }
        public int ShortBreakDuration { get; set; }
        public int LongBreakDuration { get; set; }
        public String PomoMessage { get; set; }
        public int Count { get; private set; }
        //TODO
        public string GetDocumentation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void StartTimer()
        {
            timer.Enabled = true;
        }
        public void Notify()
        {
            Count++;
            this.timer.Interval = timerInterval();
        }
        public int timerInterval()
        {
            //this method defines the time intervals and events that run in each one
            if (Count > 8)
            {
                Count = 0;
            }
            switch (Count)
            {
                case 1:
                    this.OnPomodoroStart?.Invoke();
                    return this.WorkDuration;
                case 2:
                    this.OnPomodoroBreak?.Invoke();
                    return this.ShortBreakDuration;
                case 3:
                    this.OnPomodoroStart?.Invoke();
                    return this.WorkDuration;
                case 4:
                    this.OnPomodoroBreak?.Invoke();
                    return this.ShortBreakDuration;
                case 5:
                    this.OnPomodoroStart?.Invoke();
                    return this.WorkDuration;
                case 6:
                    this.OnPomodoroBreak?.Invoke();
                    return this.ShortBreakDuration;
                case 7:
                    this.OnPomodoroStart?.Invoke();
                    return this.WorkDuration;
                case 8:
                    this.OnPomodoroHalt?.Invoke();
                    return this.LongBreakDuration;
                default:
                    return 1;
            }
        }
        public void EndTimer()
        {
            this.timer.Stop();
        }
    }
}
