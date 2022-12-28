

namespace TodoApp
{
    public partial class TodosPage
    {
        public TodosPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            TodoContentView.OnMenuClicked += Menu_ClickedEvent;
            SideBarView.OnBackClicked += Back_ClickedEvent;
        }

        protected override void OnDisappearing()
        {
            TodoContentView.OnMenuClicked -= Menu_ClickedEvent;
            SideBarView.OnBackClicked -= Back_ClickedEvent;
        }

        private void Back_ClickedEvent()
        {
            Task.WhenAll(
                TodoContentView.TranslateTo(0, 0, 500, Easing.CubicOut),
                TodoContentView.ScaleTo(1, 500, Easing.CubicOut),
                SideBarView.TranslateTo(-App.Current.MainPage.Width * 0.8, 0, 500, Easing.CubicOut)
            );
        }

        private void Menu_ClickedEvent()
        {
            TodoContentView.TranslateTo(App.Current.MainPage.Width * 0.8, 0, 500, Easing.CubicIn);
            TodoContentView.ScaleTo(0.85, 500, Easing.CubicIn);
            SideBarView.TranslateTo(0, 0, 500, Easing.CubicIn);
        }
    }
}