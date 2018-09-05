using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMenu.Settings.Popup
{
    class ShadersRenderQualityPopup : UI.Popup.Popup
    {
        protected override void OnValidate()
        {
            base.OnValidate();
            Values = global::Settings.Settings.Video.shadersQuality.names;
            Fill();
            global::Settings.Settings.Video.shadersQuality.value = dropdown.value;
        }

        public override void OnChanged(int index)
        {
            global::Settings.Settings.Video.shadersQuality.value = index;
        }
    }
}
