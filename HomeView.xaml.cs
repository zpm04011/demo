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
            //��ʼ������
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
            {
                // ����ڲ��쳣��Ϣ
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
