using System;
using Xamarin.Forms;

namespace TodoApp
{
    public partial class TodosPage
    {
        public TodosPage()
        {
            InitializeComponent();
            TodoContentView.OnMenuClicked += Menu_Clicked;
            SideBarView.OnBackClicked += Back_Clicked;
        }

        private void Menu_Clicked()
        {
            var vm = BindingContext as TodosPageViewModel;
            vm.SidebarMenuVisible = !vm.SidebarMenuVisible;

            TodoContentView.TranslateTo(App.Current.MainPage.Width * 0.8, 0, 500, Easing.CubicIn);
            TodoContentView.ScaleTo(0.85, 500, Easing.CubicIn);
            SideBarView.TranslateTo(0, 0, 500, Easing.CubicIn);
        }

        private void Back_Clicked()
        {
            var vm = BindingContext as TodosPageViewModel;
            vm.SidebarMenuVisible = !vm.SidebarMenuVisible;

            TodoContentView.TranslateTo(0, 0, 500, Easing.CubicOut);
            TodoContentView.ScaleTo(1, 500, Easing.CubicOut);
            SideBarView.TranslateTo(-App.Current.MainPage.Width * 0.8, 0, 500, Easing.CubicOut);
        }
    }
}