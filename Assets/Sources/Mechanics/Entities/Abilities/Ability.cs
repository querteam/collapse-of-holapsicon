using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace Mechanics.Entities.Abilities
{
    public class Ability : MonoBehaviour
    {

        public Texture2D thumb;
        public float animationDuration;
        public float animationDelay;

        public virtual void Setup()
        {

        }

        public virtual void Handle()
        {

        }

        public virtual void OnClick()
        {
            Handle();
        }


    }
}
