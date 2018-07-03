using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyProgress.Model
{
    public class SubTask
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; } = Status.DO;
        public Priority Priority { get; set; } = Priority.LOW;
        public Color PriorityColor { get; set; }
    }
}
