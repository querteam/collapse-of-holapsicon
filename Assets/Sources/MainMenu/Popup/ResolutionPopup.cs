using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace MainMenu.Settings.Popup
{
    class ResolutionPopup : UI.Popup.Popup
    {
        protected override void OnValidate()
        {
            base.OnValidate();
            Values = Screen.resolutions
                .Select(item => $"{item.width}x{item.height}")
                .ToArray();
            Selected = Values.ToList()
                .IndexOf($"{Screen.currentResolution.width}x{Screen.currentResolution.height}");
            Fill();
        }

        public override void OnChanged(int index)
        {
            global::Settings.Settings.Video.Resolution = Screen.resolutions
                .First(item => item.width == Screen.currentResolution.width &&
                        item.height == Screen.currentResolution.height);
        }
    }
}
