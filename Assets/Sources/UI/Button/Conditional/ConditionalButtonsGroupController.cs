using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.Events;

namespace UI.Button.Conditional
{
    public class ConditionalButtonsGroupController : MonoBehaviour
    {
        public List<ConditionalButton> buttons;
        public int current;
        public int prev;

        public UnityEvent OnFocusChanged;

        private void OnValidate()
        {
            if (buttons == null || buttons.Count == 0)
            {
                buttons = GetComponentsInChildren<ConditionalButton>().ToList();
            }

            if (buttons.Count > 0)
            {
                Focus(current, true);
            }
        }

        public bool AutoFocus = false;

        private void Start()
        {
            if (AutoFocus)
            {
                Focus(current, true);
            }
        }

        public void Focus(int index, bool force = false)
        {
            if (current >= buttons.Count || current < 0)
            {
                return;
            }

            current = index;
            buttons[prev].SetActive(false);
            buttons[current].SetActive(true);
            if (force)
            {
                buttons[current].OnPointerClick(null);
            }

            prev = current;

            OnFocusChanged?.Invoke();
        }

        public void Focus(ConditionalButton btn, bool force = false)
        {
            var index = buttons.IndexOf(btn);
            if (index == -1)
            {
                throw new NullReferenceException("Button not found");
            }

            if (index == current && !force)
            {
                return;
            }

            Focus(index, force);
        }

        public int GetCurrentIndex()
        {
            return current;
        }

        public int GetPrevIndex()
        {
            return prev;
        }

    }
}
