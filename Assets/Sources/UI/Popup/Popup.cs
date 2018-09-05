using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UI.Popup
{
    public class Popup : MonoBehaviour
    {
        public string[] Values;
        public TMP_Dropdown dropdown;

        public int Selected;

        protected virtual void OnValidate()
        {
            dropdown = GetComponentInChildren<TMP_Dropdown>();
            if (Values.Length > Selected && Selected >= 0)
            {
                dropdown.value = Selected;
                dropdown.RefreshShownValue();
            }
        }

        public void Fill()
        {
            dropdown.ClearOptions();
            foreach (var name in Values)
            {
                dropdown.options.Add(new TMP_Dropdown.OptionData { text = name });
            }

            dropdown.onValueChanged.RemoveAllListeners();
            dropdown.onValueChanged.AddListener(OnChanged);

            //dropdown.value = Selected;
            dropdown.RefreshShownValue();
        }
        
        public virtual void OnChanged(int index) { }

    }
}
