using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static global::Settings.InterfaceSettings;

namespace MainMenu.Popup
{
    class UserInterfaceSkinPopup : UI.Popup.PopupEnum<InterfaceSkin>
    {
        protected override void OnValidate()
        {
            base.OnValidate();
            dropdown.value = (int)global::Settings.Settings.Interface.skin;
            Fill();
            dropdown.RefreshShownValue();
        }

        protected override void OnChanged(int index)
        {
            global::Settings.Settings.Interface.skin =
                (InterfaceSkin)Enum.ToObject(typeof(InterfaceSkin), index);
        }
    }
}
