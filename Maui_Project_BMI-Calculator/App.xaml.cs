using Maui_Project_BMI_Calculator.MVVM.Views;

namespace Maui_Project_BMI_Calculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new BMIView();
        }
    }
}
