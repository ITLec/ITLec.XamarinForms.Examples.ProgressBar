using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void OnButtonClicked(object sender, EventArgs args)
        {
            Task<bool> task = Task.Run(()=> DisplayAlert("Simple Alert", "Decide on an option", "yes or ok", "no or cancel"));
            label.Text = "Alert is currently displayed";
            bool result = await task;
            label.Text = String.Format("Alert {0} button was pressed", result ? "OK" : "Cancel");

           await DisplayAlert("Simple Alert", "Decide on an option", "yes or ok", "no or cancel");

            label.Text = "123";
        }

    async void btnSubmit_Clicked(object sender, EventArgs arg)
        {


            List<TaskItem> tskItems = new List<TaskItem>();

            for (int i = 0; i < 10000; i++)
            {
                tskItems.Add(new TaskItem { Task = new Task(() => { YourCode(); }), TaskName ="Task#: "+ i.ToString(), Wieght = 100 });
            }
            customProgressBar.TaskItems = tskItems;
           await customProgressBar.Run();


        }

        public async void YourCode()
        {
            //Add your logic code
        }
    }
    
}
