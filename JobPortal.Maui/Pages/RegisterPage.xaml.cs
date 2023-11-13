using JobPortal.Maui.ViewModels;
using System.ComponentModel;
using System.Net.Http;

namespace JobPortal.Maui.Pages;

public partial class RegisterPage : ContentPage
{
	private RegisterPageViewModel vm;

	/*ANIMATION VARIABLES*/
	private List<Frame> frameList = new List<Frame>();
	readonly Animation SlideAnimation1;
	readonly Animation SlideAnimation2;
	readonly Animation FadeAnimation;

    public RegisterPage(RegisterPageViewModel registerPageViewModel)
	{
		InitializeComponent();
        vm = registerPageViewModel;

		frameList.Add(frameBox1);
		frameList.Add(frameBox2);
		frameList.Add(frameBox3);
		frameList.Add(frameBox4);
		frameList.Add(frameBox5);
		frameList.Add(frameBox6);

        SlideAnimation1 = new Animation(v => frameList[vm.Step].TranslationX = v,-200,20,Easing.Linear);
        SlideAnimation2 = new Animation(v => frameList[vm.Step].TranslationX = v,20,0,Easing.Linear);
        FadeAnimation = new Animation(v => frameList[vm.Step].Opacity = v,0,1,Easing.Linear);

		vm.PropertyChanged += Vm_PropertyChanged;
		BindingContext = vm;
    }

	private void Vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == nameof(RegisterPageViewModel.IsBusy))
		{
            if (vm.IsBusy)
			{
                FadeAnimation.Commit(this, "Fade", 16, 200, Easing.Linear, null, null);
                SlideAnimation1.Commit(this, "Slide1", 16, 250, Easing.Linear, (v,c) =>
				{
					SlideAnimation2.Commit(this, "Slide2", 16, 100, Easing.Linear,null,null);
				},null);
            }
			else
			{
				this.AbortAnimation("Slide1");
				this.AbortAnimation("Slide2");
				this.AbortAnimation("Fade");
			}
		}
	}
}


