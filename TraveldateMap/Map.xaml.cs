using Microsoft.Maui.Controls.Maps;

namespace TraveldateMap;

public partial class MainPage : ContentPage
{


    public MainPage()
    {
        InitializeComponent();

        loadData();
        loadPin();
        foreach (Pin p in _pins)
        {
           mappy.Pins.Add(p);
        }

    }
    public List<CPin> _list = new List<CPin>();
    public List<Pin> _pins = new List<Pin>();
    string order;

    public void Pin_MarkerClicked(object sender, Microsoft.Maui.Controls.Maps.PinClickedEventArgs e)
    {
        var targetStackLayout = main.Children.FirstOrDefault(c => c is StackLayout) as StackLayout;
        var targetLabel = main.Children.FirstOrDefault(c => c is Label) as Label;
        if (targetStackLayout != null)
        {
            // 從主 StackLayout 中移除目標 StackLayout
            main.Children.Remove(targetStackLayout);
        }
        if (targetLabel != null)
        {
            // 從主 Label 中移除目標 StackLayout
            main.Children.Remove(targetLabel);
        }
        var q = _list.Where(p => p.productName == ((Pin)sender).Label).FirstOrDefault();
        StackLayout s = new StackLayout();
        Label l = new Label();
        Button b = new Button();
        order = q.productName;
        l.Text = $"{q.productName}/{q.price}元";
        l.FontSize = 30;
        b.Text = "購買";
        b.Clicked += Buy_Clicked;
        b.HorizontalOptions = LayoutOptions.End;
        s.Orientation = StackOrientation.Horizontal;
        s.HorizontalOptions = LayoutOptions.FillAndExpand;
      s.Children.Add(l);
        s.Children.Add(b);
        main.Children.Add(s);
    }

    private void Buy_Clicked(object sender, EventArgs e)
    {
        Label l = new Label();
        l.Text = "購買成功";
        l.FontSize = 30;
        main.Children.Add(l);
        main.Children.RemoveAt(1);


    }
    public void loadData()
    {
        CPin p = new CPin();
        p.productName = "兒童新樂園";
        p.coordinates1 = 25.097466058695556;
        p.coordinates2 = 121.51492915347542;
        p.location = "11169台北市士林區承德路五段55號";
        p.price = 200;
        _list.Add(p);
        p = new CPin();
        p.productName = "故宮博物院";
        p.coordinates1 = 25.10253025686747;
        p.coordinates2 = 121.54844958112824;
        p.location = "111台北市士林區至善路二段221號";
        p.price = 350;
        _list.Add(p);
        p = new CPin();
        p.productName = "台北101景觀台";
        p.coordinates1 = 25.03382662782283;
        p.coordinates2 = 121.56494087444725;
        p.location = "110台北市信義區信義路五段7號89樓";
        p.price = 450;
        _list.Add(p);
        p = new CPin();
        p.productName = "台北木柵動物園";
        p.coordinates1 = 24.998600674753742;
        p.coordinates2 = 121.58092839107566;
        p.location = "116台北市文山區新光路二段30號";
        p.price = 30;
        _list.Add(p);
    }
    public void loadPin()
    {
        int i = 0;
        foreach (CPin p in _list)
        {
            Pin pin = new Pin();
            pin.Label = p.productName;
            pin.Address = p.location;
            pin.Type = PinType.Place;
            pin.Location = new Microsoft.Maui.Devices.Sensors.Location(p.coordinates1, p.coordinates2);
            pin.MarkerClicked += Pin_MarkerClicked;
            _pins.Add(pin);
            i++;
        }

    }

}