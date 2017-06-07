using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MobApp
{

    public partial class CustomProgressBar : ContentView
    {
        public CustomProgressBar()
        {
            InitializeComponent();
            Init();
            Reset();
        }

        private void Init()
        {
            if (TaskItems == null)
            {
                TaskItems = new List<TaskItem>();
            }
        }

        public List<TaskItem> TaskItems
        {
            get;
            set;
        }

        public async Task Run()
        {
            IsRunning = true;
            double counter = 0;

            double totalCounter = TaskItems.Sum(e => e.Wieght);



            foreach (var item in TaskItems)
            {
                counter = counter + item.Wieght;
                double currentStep = counter / totalCounter;
                double currentPercentage = (currentStep * 100);
                CurrentPercentage = currentPercentage;
                lbl.Text = string.Format("{0} - (%{1})", item.TaskName, String.Format("{0:0.0}", currentPercentage));
                item.Task.Start();
                await mainProgressBar.ProgressTo(currentStep, 0, Easing.Linear);
            }

            IsRunning = false;
        }

        public double CurrentPercentage
        {
            get;
            set;

        }
        public async void Reset()
        {
            await mainProgressBar.ProgressTo(0, 0, Easing.Linear);
            lbl.Text = "%0";

            CurrentPercentage = 0;
            if (TaskItems != null)
            {
                TaskItems.Clear();
            }
        }

        public bool IsRunning
        {
            get;
            set;
        }
    }


    public class TaskItem
    {
        public Task Task
        {
            get;
            set;
        }
        public string TaskName
        { get; set; }

        public double Wieght
        {
            get;
            set;
        }
    }
}
