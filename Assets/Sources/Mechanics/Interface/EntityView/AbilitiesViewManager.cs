using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using Mechanics.Entities.Abilities;

namespace Mechanics.Interface.EntityView
{
    public class AbilitiesViewManager : MonoBehaviour
    {

        public AbilitiesThumbsContainer ThumbsContainer;
        public AbilityView[] slots;
        public Ability[] abilities;

        private void OnValidate()
        {
            ThumbsContainer = FindObjectOfType<AbilitiesThumbsContainer>();
            slots = GetComponentsInChildren<AbilityView>();
            foreach (var slot in slots)
            {
                slot.controller = this;
                slot.Clear();
            }
        }

        [ContextMenu("Refresh slots")]
        private void Refresh()
        {
            OnValidate();
            if (abilities.Length > 0)
            {
                Add(abilities);
            }
        }

        public void Add(Ability[] abilities)
        {
            this.abilities = abilities;
            var index = 0;
            foreach (var slot in slots)
            {
                slot.Setup(abilities[index]);
                index++;
                if (index == abilities.Length)
                    return;
            }
        }

        public void Clear()
        {
            foreach (var slot in slots)
            {
                slot.Clear();
            }
        }

        public void RemoveAll()
        {
            Clear();
            abilities = null;
        }

        public void Sort()
        {

        }

    }
}
