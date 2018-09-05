using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Button.Conditional
{
    public class ConditionalButton : Button
    {
        [Header("Conditional")]
        public bool IsSelected;

        protected ConditionalButtonsGroupController controller;

        public Texture2D NormalSelectedTexture2D;
        public Texture2D OnHoverSelectedTexture2D;
        public Texture2D OnClickSelectedTexture2D;

        protected override void UpdateStyles(ButtonState state)
        {
            if (!gameObject.activeSelf)
            {
                return;
            }

            Texture2D tex;

            switch (state)
            {
                case ButtonState.Normal:
                    tex = IsSelected ? NormalSelectedTexture2D : NormalTexture2D;
                    break;
                case ButtonState.MouseOut:
                    tex = IsSelected ? NormalSelectedTexture2D : NormalTexture2D;
                    break;
                case ButtonState.MouseEnter:
                    tex = IsSelected ? OnHoverSelectedTexture2D : OnHoverTexture2D;
                    break;
                case ButtonState.Click:
                    tex = IsSelected ? OnClickSelectedTexture2D : OnClickTexture2D;
                    break;
                default:
                    tex = IsSelected ? NormalSelectedTexture2D : NormalTexture2D;
                    break;
            }

            graphicTarget.texture = tex;
            CanChangeStyle = false;
            if (state == ButtonState.Click)
            {
                //StartCoroutine(ClearAfterClick());
                return;
            }
            CanChangeStyle = true;
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            controller = GetComponentInParent<ConditionalButtonsGroupController>();
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            if (controller == null)
            {
                controller = GetComponentInParent<ConditionalButtonsGroupController>();
            }

            if (controller != null)
            {
                controller.Focus(this);
            }
        }

        public void SetActive(bool value)
        {
            IsSelected = value;
            UpdateStyles(IsMouseOver ? ButtonState.MouseEnter : ButtonState.Normal);
        }

        private void Start()
        {
            UpdateStyles(ButtonState.Normal);
        }
    }
}
