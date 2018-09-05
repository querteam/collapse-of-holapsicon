using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMenu.Popup
{
    public enum NetworkQuality
    {
        High, Low
    }

    class NetworkQualityPopup : UI.Popup.PopupEnum<NetworkQuality>
    {
        public NetworkQuality startup;

        protected override void OnValidate()
        {
            base.OnValidate();
            dropdown.value = (int)startup;
            Fill();
            dropdown.RefreshShownValue();
        }

        protected override void OnChanged(int index)
        {
            base.OnChanged(index);
            startup = (NetworkQuality)Enum.ToObject(typeof(NetworkQuality), index);
        }
    }
}
