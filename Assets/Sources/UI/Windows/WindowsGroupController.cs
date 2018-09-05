using System.Collections.Generic;

using UnityEngine;

namespace UI.Windows
{
    public class WindowsGroupController : MonoBehaviour
    {

        public List<Window> windows;
        public int current;
        public int prev;

        //public bool AutoOpenWindow;
        //public Window StartupWindow;

        private void Start()
        {
            //if (AutoOpenWindow)
            //{
            //    if (StartupWindow == null)
            //        StartupWindow = windows[0];
            //    OpenWindow(StartupWindow);
            //}
        }

        public void OpenWindow(int index)
        {
            if (index < 0 || index >= windows.Count || index == -1)
            {
                print("Invalid index " + index);
                return;
            }

            CloseWindow(current);
            windows[index].gameObject.SetActive(true);

            current = index;
            prev = current;
        }

        public void OpenWindow(Window window)
        {
            OpenWindow(windows.IndexOf(window));
        }

        public void OpenWindow(string name)
        {
            foreach (var window in windows)
            {
                if (window.name == name)
                {
                    OpenWindow(window);
                    return;
                }
            }
        }

        public void CloseWindow(int index)
        {
            windows[index].gameObject.SetActive(false);
        }

        public void CloseWindow(Window window)
        {
            CloseWindow(windows.IndexOf(window));
        }

        public void CloseAllWindows()
        {
            foreach (var window in windows)
            {
                CloseWindow(window);
            }
        }


    }
}
