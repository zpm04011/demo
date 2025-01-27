using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;
using train1;
using train1.ViewModels;
using System.Collections.ObjectModel;


namespace train1.Views;
public partial class HomeView : ScrollView
{

    public HomeView()
    {
        try
        {
            InitializeComponent();
            this.BindingContext = this;
            //初始化数据
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
            {
                // 输出内部异常信息
                Console.WriteLine("Inner Exception:" + ex.InnerException.Message);
                Console.WriteLine("Stack Trace:" + ex.InnerException);
            }
            else
            {
                Console.WriteLine("Exception:" + ex.Message);
                Console.WriteLine("Stack Trace:" + ex.StackTrace);
            }
        }
    }
}
