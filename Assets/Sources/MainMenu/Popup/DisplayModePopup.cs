using System;

using UnityEngine;

namespace MainMenu.Settings.Popup
{
    class DisplayModePopup : UI.Popup.PopupEnum<FullScreenMode>
    {
        public FullScreenMode selected;

        protected override void OnValidate()
        {
            base.OnValidate();
            dropdown.value = (int)selected;
            Fill();
            dropdown.RefreshShownValue();
        }

        protected override void OnChanged(int index)
        {
            global::Settings.Settings.Video.displayMode =
                (FullScreenMode)Enum.ToObject(typeof(FullScreenMode), index);
        }

    }
}
