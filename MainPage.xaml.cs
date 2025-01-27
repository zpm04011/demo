using System.Reflection;
using train1.ViewModels;
using train1.Views;
using train1;
using Microsoft.Maui.Controls;

namespace train1
{
    public partial class MainPage : ContentPage
    {
        //MainViewModel viewModel = new MainViewModel();
        View[] views = new View[4];
        public MainPage()
        {
            InitializeComponent();
            views[0] = new HomeView();
            views[1] = new KnowledgeView();
            views[2] = new CommunityView();
            views[3] = new UserView();

            NavigationPage.SetHasNavigationBar(this, false);

            //this.BindingContext = viewModel;
            //默认首页
            //viewModel.Page = new HomeView();
            content.Content = views[0];
            homeImage.Source = ImageSource.FromFile("home2.png"); // 设置默认选中状态的图标

        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null )
            {
                content.Content = views[0];
                // 重置所有图标
                homeImage.Source = ImageSource.FromFile("home1.png");
                knowledgeImage.Source = ImageSource.FromFile("knowledge1.png");
                communityImage.Source = ImageSource.FromFile("community1.png");
                userImage.Source= ImageSource.FromFile("user1.png");

                if (button == home)
                {
                    content.Content = views[0];
                    homeImage.Source = ImageSource.FromFile("home2.png");
                }
                else if (button == knowledge)
                {
                    content.Content = views[1];
                    knowledgeImage.Source = ImageSource.FromFile("knowledge2.png");
                }
                else if (button == community)
                {
                    content.Content = views[2];
                    communityImage.Source = ImageSource.FromFile("community2.png");
                }
                else if (button == user)
                {
                    content.Content = views[3];
                    userImage.Source = ImageSource.FromFile("user2.png");
                }

            }
        }
    }
    public class CustomFrame : Frame
    {
        public static readonly BindableProperty TopLeftCornerRadiusProperty =
            BindableProperty.Create(nameof(TopLeftCornerRadius), typeof(float), typeof(CustomFrame), 0f);
        public static readonly BindableProperty TopRightCornerRadiusProperty =
           BindableProperty.Create(nameof(TopRightCornerRadius), typeof(float), typeof(CustomFrame), 0f);
        public static readonly BindableProperty BottomLeftCornerRadiusProperty =
            BindableProperty.Create(nameof(BottomLeftCornerRadius), typeof(float), typeof(CustomFrame), 0f);
        public static readonly BindableProperty BottomRightCornerRadiusProperty =
           BindableProperty.Create(nameof(BottomRightCornerRadius), typeof(float), typeof(CustomFrame), 0f);

        public float TopLeftCornerRadius
        {
            get => (float)GetValue(TopLeftCornerRadiusProperty);
            set => SetValue(TopLeftCornerRadiusProperty, value);
        }
             public float TopRightCornerRadius
        {
            get => (float)GetValue(TopRightCornerRadiusProperty);
            set => SetValue(TopRightCornerRadiusProperty, value);
        }

        public float BottomLeftCornerRadius
        {
            get => (float)GetValue(BottomLeftCornerRadiusProperty);
            set => SetValue(BottomLeftCornerRadiusProperty, value);
        }

        public float BottomRightCornerRadius
        {
            get => (float)GetValue(BottomRightCornerRadiusProperty);
            set => SetValue(BottomRightCornerRadiusProperty, value);
        }
    }
}
