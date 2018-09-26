using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Victor4Library.Models
{
    public enum Severity { low, medium, high }
    public class TaskToDo : IStandard
    {
        public string SessionId { get; set; }
        public delegate void TaskReady();
        public event TaskReady TaskReadyEvent;
        Timer timer;
        public TaskToDo(string header, string details)
        {
            this.SessionId = Util.Utilities.GenerateId(7);
            this.TaskHeader = header;
            this.TaskDetails = details;
            CreationDate = DateTime.Now;
            this.Severity = Severity.medium;
        }
        public TaskToDo(string header, string details, DateTime dueTime) : this(header, details)
        {
            this.DueDate = dueTime;
            this.Severity = Severity.medium;

            timer = new Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 5000;
            timer.Enabled = true;
        }
        public TaskToDo(string header, string details, DateTime dueTime, Severity severity) : this(header, details, dueTime)
        {
            this.Severity = severity;
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now > DueDate && !IsRung)
            {
                Notify();
            }
        }
        public string TaskHeader { get; set; }
        public string TaskDetails { get; set; }
        public bool IsRung { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public Severity Severity { get; set; }
        //TODO
        public string GetDocumentation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private void Notify()
        {
            TaskReadyEvent?.Invoke();
            IsRung = true;
        }
    }
}
