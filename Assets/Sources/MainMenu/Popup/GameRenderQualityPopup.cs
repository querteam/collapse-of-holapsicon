using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMenu.Settings.Popup
{
    class GameRenderQualityPopup : UI.Popup.Popup
    {
        protected override void OnValidate()
        {
            base.OnValidate();
            Values = global::Settings.Settings.Video.gameRenderQuality.names;
            Fill();
            global::Settings.Settings.Video.gameRenderQuality.value = dropdown.value;
        }

        public override void OnChanged(int index)
        {
            global::Settings.Settings.Video.gameRenderQuality.value = index;
        }

    }
}
