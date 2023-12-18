using JobPortal.Maui.ViewModels;
using System.ComponentModel;
using System.IO;
using System.Net.Http;

namespace JobPortal.Maui.Pages;

public partial class RegisterPage : ContentPage
{
	private RegisterPageViewModel vm;

	/*ANIMATION VARIABLES*/
	private List<Border> boxList = new List<Border>();
	readonly Animation SlideAnimation1;
	readonly Animation SlideAnimation2;
	readonly Animation FadeAnimation;

    public RegisterPage(RegisterPageViewModel registerPageViewModel)
	{
		InitializeComponent();
        vm = registerPageViewModel;


        boxList.Add(registerBox1);
        boxList.Add(registerBox2);
        boxList.Add(registerBox3);
        boxList.Add(registerBox4);
        boxList.Add(registerBox5);
        boxList.Add(registerBox6);
        boxList.Add(registerBox7);

        ClearRegisterGridUI();
        mainRegisterGrid.Children.Add(boxList[vm.Step]);

        SlideAnimation1 = new Animation(v => boxList[vm.Step].TranslationX = v, -200, 20, Easing.Linear);
        SlideAnimation2 = new Animation(v => boxList[vm.Step].TranslationX = v, 20, 0, Easing.Linear);
        FadeAnimation = new Animation(v => boxList[vm.Step].Opacity = v, 0, 1, Easing.Linear);

        vm.TriggerActionRequested += OnTriggerActionRequested;
        BindingContext = vm;
    }
    private async void OnTriggerActionRequested(object sender, EventArgs e)
    {
        if (vm.Step == 4)
        {
            if (vm.FileToUpload != null)
            {
                var stream = await vm.FileToUpload.OpenReadAsync();
                vm.UserImageSource = ImageSource.FromStream(() => stream);
            }
        }
        await Task.Delay(100);
        ClearRegisterGridUI();
        mainRegisterGrid.Children.Add(boxList[vm.Step]);
        FadeAnimation.Commit(this, "Fade", 16, 200, Easing.Linear, null, null);
        SlideAnimation1.Commit(this, "Slide1", 16, 250, Easing.Linear, (v, c) =>
        {
            SlideAnimation2.Commit(this, "Slide2", 16, 100, Easing.Linear, null, null);
        }, null);
        await Task.Delay(500);
        this.AbortAnimation("Slide1");
        this.AbortAnimation("Slide2");
        this.AbortAnimation("Fade");
    }

    private void ClearRegisterGridUI()
    {
        foreach (var item in boxList)
        {
            if (mainRegisterGrid.Contains(item))
            {
                mainRegisterGrid.Remove(item);
            }
        }
    }

}


