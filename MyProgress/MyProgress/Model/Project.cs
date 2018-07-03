using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyProgress.Model
{
    public class Project
    {
        public Project()
        {
            Tasks = new List<Task>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string CountTasks { get => "Tarefas: " + Tasks.Count; }
        public List<Task> Tasks { get; set; }
        public Status Status { get; set; } = Status.DO;
        public Priority Priority { get; set; } = Priority.LOW;
        public Color PriorityColor {
            get
            {
                if (Priority == Priority.LOW) return Color.DarkOrange;
                else if (Priority == Priority.MODERATE) return Color.DarkGreen;
                else return Color.DarkRed;
            }
        }

        public static List<Project> Projects { get; set; }
    }
}
