using Microsoft.Maui.Controls.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map = Microsoft.Maui.Controls.Maps.Map;

namespace TraveldateMap
{
    public class CInitalizeMap : MainPage
    {
        public List<CPin> _list = new List<CPin>();
        public List<Pin> _pins = new List<Pin>();
        public CInitalizeMap()
        {
           
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
            
            foreach (CPin p in _list)
            {
                Pin pin = new Pin();
                pin.Label = p.productName;
                pin.Address = p.location;
                pin.Type = PinType.Place;
                pin.Location = new Location(p.coordinates1, p.coordinates2);
                pin.MarkerClicked += Pin_MarkerClicked;
                _pins.Add(pin);
            }

        }



    }
}
