using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

namespace UI.Button
{
    public class Button : MonoBehaviour,
        IPointerEnterHandler, IPointerExitHandler,
        IPointerClickHandler

    {

        public enum ButtonState
        {
            Normal,
            MouseEnter, MouseOut,
            Click
        }

        public ButtonState state = ButtonState.Normal;

        public bool IsMouseOver;

        protected bool CanChangeStyle = true;

        public ButtonClickedEvent OnClick;

        [SerializeField]
        protected UnityEngine.UI.Button button;
        [SerializeField]
        protected RawImage graphicTarget;
        [SerializeField]
        protected TMPro.TextMeshProUGUI textBox;

        [Header("State Textures")]
        public Texture2D NormalTexture2D;
        public Texture2D OnHoverTexture2D;
        public Texture2D OnClickTexture2D;

        protected virtual void OnValidate()
        {
            if (button == null)
            {
                button = GetComponent<UnityEngine.UI.Button>();
            }

            if (graphicTarget == null)
            {
                graphicTarget = GetComponent<RawImage>();
            }

            if (textBox == null)
            {
                textBox = GetComponentInChildren<TMPro.TextMeshProUGUI>();
            }

            UpdateStyles(state);

            button.onClick.RemoveAllListeners();
            button.onClick = OnClick;
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            IsMouseOver = true;
            UpdateStyles(ButtonState.MouseEnter);
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            IsMouseOver = false;
            UpdateStyles(ButtonState.MouseOut);
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            UpdateStyles(ButtonState.Click);
            OnClick?.Invoke();
        }

        protected virtual void UpdateStyles(ButtonState state)
        {
            Texture2D tex;

            switch (state)
            {
                case ButtonState.Normal:
                    tex = NormalTexture2D;
                    break;
                case ButtonState.MouseOut:
                    tex = NormalTexture2D;
                    break;
                case ButtonState.MouseEnter:
                    tex = OnHoverTexture2D;
                    break;
                case ButtonState.Click:
                    tex = OnClickTexture2D;
                    break;
                default:
                    tex = NormalTexture2D;
                    break;
            }

            graphicTarget.texture = tex;
            CanChangeStyle = false;
            if (state == ButtonState.Click)
            {
                StartCoroutine(ClearAfterClick());
                return;
            }
            CanChangeStyle = true;
        }

        protected IEnumerator<object> ClearAfterClick()
        {
            yield return new WaitForSeconds(.1f);
            try
            {
                if (IsMouseOver)
                {
                    graphicTarget.texture = OnHoverTexture2D;
                }
                UpdateStyles(ButtonState.Normal);
            }
            catch (Exception)
            {
                yield break;
            }
        }

    }
}
