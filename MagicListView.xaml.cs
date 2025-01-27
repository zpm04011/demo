using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;
using train1;
using train1.ViewModels;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using train1.Views;
using CommunityToolkit.Maui.Converters;
using train1.Pages;
using System.Text.Json;
using System.IO;
using System.Reflection;

namespace train1.Views;

public partial class MagicListView : ContentView
{
    public MagicListView()
    {
        InitializeComponent();

        var magicItems = new ObservableCollection<MagicItem>
        {
            new MagicItem { Picture="recommend.png",Name = "热门玩法", Description = "TOP 5" },
            new MagicItem { Picture="coin.png",Name = "魔币专区", Description = "NUM 3" },
            new MagicItem { Picture = "bean.png", Name = "魔豆专区", Description = "NUM 5" }
        };
        MagicItemsSource = magicItems;

        // 读取 JSON 文件并反序列化为 MagicCoverData 对象
        var magicCoverDataList = loadMagicCoverDataFromJson("train1.Resources.Raw.HomeViewMagicsNew.json");
        MagicCoverDataSource = magicCoverDataList;

        BindingContext = this;
        // 设置绑定上下文


    }
    public static readonly BindableProperty MagicItemsSourceProperty =
            BindableProperty.Create(nameof(MagicItemsSource), typeof(IEnumerable<MagicItem>), typeof(MagicListView), null);

    public IEnumerable<MagicItem> MagicItemsSource
    {
        get => (IEnumerable<MagicItem>)GetValue(MagicItemsSourceProperty);
        set => SetValue(MagicItemsSourceProperty, value);
    }

    public static readonly BindableProperty MagicCoverDataSourceProperty =
        BindableProperty.Create(nameof(MagicCoverData), typeof(IEnumerable<MagicCoverData>), typeof(MagicListView), null);
    public IEnumerable<MagicCoverData> MagicCoverDataSource
    {
        get => (IEnumerable<MagicCoverData>)GetValue(MagicCoverDataSourceProperty);
        set => SetValue(MagicCoverDataSourceProperty, value);
    }

    private async void OnMagicItemTapped(object sender, TappedEventArgs e)
    {
        var frame = sender as Frame;
        if (frame != null)
        {
            var magicCoverData = frame.BindingContext as MagicCoverData;
            if (magicCoverData != null)
            {
                if (int.TryParse(magicCoverData.id, out int id))
                {
                    var page = new MagicInformationPage(id);
                    await Navigation.PushAsync(page);
                }
                else
                {
                    Console.WriteLine($"Invalid id:{magicCoverData.id}");
                }
            }
        }
    }

    private ObservableCollection<MagicCoverData> loadMagicCoverDataFromJson(string resourcePath)
    {
        var assembiy = Assembly.GetExecutingAssembly();
        using (Stream stream = assembiy.GetManifestResourceStream(resourcePath))
        {
            if (stream == null)
            {
                Console.WriteLine($"Resource not found:{resourcePath}");
                return new ObservableCollection<MagicCoverData>();
            }
            using (StreamReader reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                Console.WriteLine($"JSON data:{json}");
                try
                {
                    var magicCoverDataList = JsonSerializer.Deserialize<List<MagicCoverData>>(json);
                    return new ObservableCollection<MagicCoverData>(magicCoverDataList);
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"JSON deserialization error:{ex.Message}");
                    Console.WriteLine($"Stack Trace:{ex.StackTrace}");
                    throw;
                }
            }
        }
    }
   
    public class MagicItem
    {
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class MagicCoverData
    {
        public string magicName { get; set; }
        public string coverPicture { get; set; }
        public string id { get; set; }
        public int likesCount { get; set; }
        public int commentsCount { get; set; }
    }
}
