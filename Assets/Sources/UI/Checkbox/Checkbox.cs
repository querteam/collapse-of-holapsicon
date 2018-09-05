
using UnityEngine;
using UnityEngine.UI;

namespace UI.Checkbox
{
    class Checkbox : MonoBehaviour
    {

        public bool IsChecked;

        public Texture2D Checked;
        public Texture2D Unchecked;

        public UnityEngine.UI.Button checkbox;
        public RawImage targetGraphic;
        public TMPro.TextMeshProUGUI textbox;

        public UnityEngine.UI.Button.ButtonClickedEvent OnValueChanged;


        private void OnValidate()
        {
            checkbox = GetComponentInChildren<UnityEngine.UI.Button>();
            textbox = GetComponentInChildren<TMPro.TextMeshProUGUI>();
            targetGraphic = checkbox.targetGraphic as RawImage;

            targetGraphic.texture = IsChecked ? Checked : Unchecked;
        }

        public void OnClick()
        {
            OnValueChanged?.Invoke();
            IsChecked = !IsChecked;
            print(IsChecked);
            targetGraphic.texture = IsChecked ? Checked : Unchecked;
        }



    }
}
