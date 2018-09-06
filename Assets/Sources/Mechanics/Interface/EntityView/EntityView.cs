using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.UI;

namespace Mechanics.Interface.EntityView
{
    [RequireComponent(typeof(RectTransform))]
    public class EntityView : MonoBehaviour
    {

        public RectTransform rect;
        public EntityViewable target;

        public EntityCredentials credentials;
        public EntityStats stats;

        private void OnValidate()
        {
            rect = GetComponent<RectTransform>();
            credentials = GetComponentInChildren<EntityCredentials>();
            credentials.view = this;
            stats = GetComponentInChildren<EntityStats>();
            stats.view = this;
        }

        public void SetTarget(EntityViewable target)
        {
            if (this.target != null)
            {
                credentials.OnDeselectTarget();
                stats.OnDeselectTarget();
            }

            this.target = target;
            credentials.OnSelectTarget();
            stats.OnSelectTarget();
        }
        
    }
}
