using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

namespace UI.Popup
{
    public class PopupEnum<TEnum> : MonoBehaviour
    {

        public TMP_Dropdown dropdown;

        protected virtual void OnValidate()
        {
            dropdown = GetComponentInChildren<TMP_Dropdown>();
        }

        public void Fill()
        {
            dropdown.ClearOptions();
            foreach (var name in Enum.GetNames(typeof(TEnum)))
            {
                dropdown.options.Add(new TMP_Dropdown.OptionData { text = name });
            }

            dropdown.onValueChanged.RemoveAllListeners();
            dropdown.onValueChanged.AddListener(OnChanged);
        }

        protected virtual void OnChanged(int index) { }

    }
}
