
using UnityEngine;

namespace UI.Windows
{
    public class Window : MonoBehaviour
    {
        public WindowsGroupController controller;

        private void OnValidate()
        {
            if (controller == null)
            {
                controller = GetComponentInParent<WindowsGroupController>();
            }
        }

        public void Open()
        {
            controller.OpenWindow(this);
        }

        public void Close()
        {
            controller.CloseWindow(this);
        }

    }
}
