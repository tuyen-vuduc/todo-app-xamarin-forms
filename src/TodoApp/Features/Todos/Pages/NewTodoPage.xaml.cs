using System;

namespace TodoApp
{
    public partial class NewTodoPage
    {
        public NewTodoPage()
        {
            InitializeComponent();
        }

        private void OnPickDueDateButtonTapped(object sender, EventArgs e)
        {
            DueDatePicker.Focus();
        }

        private void OnSelectCategoryButtonTapped(object sender, EventArgs e)
        {
            CategoryPicker.Focus();
        }
    }
}
