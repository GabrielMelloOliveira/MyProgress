using MyProgress.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProgress.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddProjectPage : ContentPage
	{
        Priority priority;

		public AddProjectPage ()
		{
			InitializeComponent ();
            btnSave.Clicked += delegate { SaveProject(); };

            btnLow.Clicked += delegate { ChoicePriority(btnLow, Priority.LOW, Color.Orange); };
            btnModerate.Clicked += delegate { ChoicePriority(btnModerate, Priority.MODERATE, Color.Green); };
            btnHigh.Clicked += delegate { ChoicePriority(btnHigh, Priority.HIGH, Color.Red); };
		}

        public AddProjectPage(Project project)
        {
            InitializeComponent();
            btnSave.Text = "Editar Projeto";
            btnSave.Clicked += delegate { SaveProject(); };

            entryName.Text = project.Name;

            btnLow.Clicked += delegate { ChoicePriority(btnLow, Priority.LOW, Color.Orange); };
            btnModerate.Clicked += delegate { ChoicePriority(btnModerate, Priority.MODERATE, Color.Green); };
            btnHigh.Clicked += delegate { ChoicePriority(btnHigh, Priority.HIGH, Color.Red); };

            if (project.Priority == Priority.LOW)
            {
                ChoicePriority(btnLow, Priority.LOW, Color.Orange);
            }
            else if (project.Priority == Priority.MODERATE)
            {
                ChoicePriority(btnModerate, Priority.MODERATE, Color.Green);
            }
            else
            {
                ChoicePriority(btnHigh, Priority.HIGH, Color.Red);
            }
        }

        void SaveProject()
        {
            Project.Projects.Add(new Project()
            {
                Name = entryName.Text,
                Priority = priority
            });

            NavigationPage nav = new NavigationPage(new AllProjectsPage());
            ToolbarItem tool = new ToolbarItem();
            nav.ToolbarItems.Add(tool);

            tool.Text = "NOVO PROJETO";
            tool.Clicked += delegate { ((MasterDetailPage)App.Current.MainPage).Detail = new NavigationPage(new AddProjectPage()) { Title = "Novo Projeto" }; };

            ((MasterDetailPage)App.Current.MainPage).Detail = nav;
        }

        void ChoicePriority(Button button, Priority priority, Color color)
        {
            ClearButtons();
            button.BackgroundColor = color;
            button.TextColor = Color.White;
            this.priority = priority;
        }

        void ClearButtons()
        {
            btnLow.BackgroundColor = Color.Transparent;
            btnModerate.BackgroundColor = Color.Transparent;
            btnHigh.BackgroundColor = Color.Transparent;

            btnLow.TextColor = Color.Black;
            btnModerate.TextColor = Color.Black;
            btnHigh.TextColor = Color.Black;
        }
    }
}