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
	public partial class AllProjectsPage : TabbedPage
	{
        List<Project> ProjectsDO = new List<Project>();
        List<Project> ProjectsDOING = new List<Project>();
        List<Project> ProjectsDONE = new List<Project>();

		public AllProjectsPage ()
		{
			InitializeComponent ();
            LoadProjects();
        }

        void LoadProjects()
        {
            lvDoProjects.ItemsSource = null;
            lvDoingProjects.ItemsSource = null;
            lvDoneProjects.ItemsSource = null;
            
            foreach (Project project in Project.Projects)
            {
                if (project.Status == Status.DO)    ProjectsDO.Add(project);
                if (project.Status == Status.DOING) ProjectsDOING.Add(project);
                if (project.Status == Status.DONE)  ProjectsDONE.Add(project);
            }

            lvDoProjects.ItemsSource = ProjectsDO;
            lvDoingProjects.ItemsSource = ProjectsDOING;
            lvDoneProjects.ItemsSource = ProjectsDONE;
        }

        void MenuItem_Clicked_Edit_Do(object sender, EventArgs e)
        {
            Project project = (Project)lvDoProjects.SelectedItem;

            //Project.Projects.Where(a => a.Name.Equals(project.Name)).First().Status = Status.DOING;

            //LoadProjects();

            ((MasterDetailPage)App.Current.MainPage).Detail = new AddProjectPage(project);
        }

        void MenuItem_Clicked_Change_Do(object sender, EventArgs e)
        {
            Project project = (Project)lvDoProjects.SelectedItem;

            Project.Projects.Where(a => a.Name.Equals(project.Name)).First().Status = Status.DOING;

            LoadProjects();
        }

        void MenuItem_Clicked_Edit_Doing(object sender, EventArgs e)
        {
            Project project = (Project)lvDoProjects.SelectedItem;

            Project.Projects.Where(a => a.Name.Equals(project.Name)).First().Status = Status.DONE;

            LoadProjects();
        }

        void MenuItem_Clicked_Change_Doing(object sender, EventArgs e)
        {
            Project project = (Project)lvDoProjects.SelectedItem;

            Project.Projects.Where(a => a.Name.Equals(project.Name)).First().Status = Status.DONE;

            LoadProjects();
        }

        void MenuItem_Clicked_Edit_Done(object sender, EventArgs e)
        {
            Project project = (Project)lvDoProjects.SelectedItem;

            Project.Projects.Where(a => a.Name.Equals(project.Name)).First().Status = Status.DOING;

            LoadProjects();
        }

        void MenuItem_Clicked_Change_Done(object sender, EventArgs e)
        {
            Project project = (Project)lvDoProjects.SelectedItem;

            Project.Projects.Where(a => a.Name.Equals(project.Name)).First().Status = Status.DOING;

            LoadProjects();
        }
    }
}