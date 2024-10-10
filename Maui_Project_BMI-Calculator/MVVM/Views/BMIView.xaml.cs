using Maui_Project_BMI_Calculator.MVVM.ViewModels;

namespace Maui_Project_BMI_Calculator.MVVM.Views;

public partial class BMIView : ContentPage
{
	public BMIView()
	{
		InitializeComponent();
		BindingContext = new BMIViewModel();
	}
}