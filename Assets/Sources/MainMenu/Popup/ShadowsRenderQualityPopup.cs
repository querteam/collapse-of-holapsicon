using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMenu.Settings.Popup
{
    class ShadowsRenderQualityPopup : UI.Popup.Popup
    {
        protected override void OnValidate()
        {
            base.OnValidate();
            Values = global::Settings.Settings.Video.shadowsQuality.names;
            Fill();
            global::Settings.Settings.Video.shadowsQuality.value = dropdown.value;
        }

        public override void OnChanged(int index)
        {
            global::Settings.Settings.Video.shadowsQuality.value = index;
        }
    }
}
