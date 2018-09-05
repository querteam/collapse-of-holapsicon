using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMenu.Settings.Popup
{
    class TerrainRenderQualityPopup : UI.Popup.Popup
    {
        protected override void OnValidate()
        {
            base.OnValidate();
            Values = global::Settings.Settings.Video.terrainRenderQuality.names;
            Fill();
            global::Settings.Settings.Video.terrainRenderQuality.value = dropdown.value;
        }

        public override void OnChanged(int index)
        {
            global::Settings.Settings.Video.terrainRenderQuality.value = index;
        }
    }
}
