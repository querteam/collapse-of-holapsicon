
using Mechanics.Entities.Abilities;
using UnityEngine;
using UnityEngine.UI;

namespace Mechanics.Interface.EntityView
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(RawImage))]
    public class AbilityView : MonoBehaviour
    {

        public Ability ability;
        public AbilitiesViewManager controller;

        private void OnValidate()
        {
            if (controller == null)
            {
                return;
            }

            if (controller.ThumbsContainer != null)
            {
                Clear();
            }
        }

        public void Setup(Ability ability)
        {
            this.ability = ability;
            GetComponent<RawImage>().texture = this.ability.thumb;
            var button = GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(this.ability.OnClick);
            this.ability.Setup();
        }

        public void Clear()
        {
            GetComponent<RawImage>().texture = controller.ThumbsContainer.EmptyAbilitySlot;
        }

    }
}
