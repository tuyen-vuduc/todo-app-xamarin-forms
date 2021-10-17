using System;

namespace TodoApp
{
    public class TaskStatisticModel
    {
        public string Category { get; set; }
        public int TotalTaskCount { get; set; }
        public int DoneTaskCount { get; set; }

        public double DonePercentage => DoneTaskCount / Math.Max(1.0, TotalTaskCount);
    }
}