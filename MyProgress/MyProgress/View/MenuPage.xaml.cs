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
	public partial class MenuPage : MasterDetailPage
	{
		public MenuPage ()
		{
			InitializeComponent ();
            Project.Projects = new List<Project>();

            NavigationPage nav = new NavigationPage(new AllProjectsPage());
            ToolbarItem tool = new ToolbarItem();
            nav.ToolbarItems.Add(tool);

            this.Detail = nav;

            tool.Text = "NOVO PROJETO";
            tool.Clicked += delegate { this.Detail = new NavigationPage(new AddProjectPage() { Title = "Novo Projeto" }) { Title = "Novo Projeto" }; };

            //MessagingCenter.Subscribe<>
        }
	}
}