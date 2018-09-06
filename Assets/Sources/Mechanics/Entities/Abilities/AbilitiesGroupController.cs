using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace Mechanics.Entities.Abilities
{
    public class AbilitiesGroupController : MonoBehaviour
    {

        public Ability[] skills;

        private void OnValidate()
        {
            skills = GetComponentsInChildren<Ability>();
        }

    }
}
