using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace Mechanics.Interface.EntityView
{
    public class EntityStats : MonoBehaviour
    {

        public EntityView view;

        public RectTransform healthbarHandle;
        public RectTransform healthbarRect;

        public RectTransform protectionbarHandle;
        public RectTransform protectionbarRect;

        public TextMeshProUGUI healthValueText;
        public TextMeshProUGUI protectionValueText;
        public TextMeshProUGUI powerValueText;

        private UnityAction<float, float> OnHealthUpdate;
        private UnityAction<float, float> OnProtectionUpdate;

        private void Start()
        {
            OnHealthUpdate = (prev, curr) => HandleStatsUpdate(State.Health, prev, curr);
            OnProtectionUpdate = (prev, curr) => HandleStatsUpdate(State.Health, prev, curr);
        }

        public void OnSelectTarget()
        {

            healthValueText.text = view.target.stats.MaxHealthPoints.ToString();
            protectionValueText.text = view.target.stats.MaxProtectionPoints.ToString();
            powerValueText.text = view.target.stats.DamagePoints.ToString();

            UpdateBars();

            view.target.stats.OnHealthUpdate.AddListener(OnHealthUpdate);
            view.target.stats.OnProtectionUpdate.AddListener(OnProtectionUpdate);

        }

        public enum State { Health, Protection }
        public void HandleStatsUpdate(State state, float prev, float current)
        {
            UpdateBars();
        }

        public void UpdateBars()
        {
            var rect = healthbarHandle.rect;
            var width = healthbarRect.rect.width /
                (view.target.stats.GetHealthPersentage() / 100);

            healthbarHandle.rect.Set(width / -2, rect.y, width, rect.height);

            rect = protectionbarHandle.rect;
            width = protectionbarRect.rect.width /
                (view.target.stats.GetProtectionPersentage() / 100);

            protectionbarHandle.rect.Set(width / -2, rect.y, width, rect.height);
        }

        public void OnDeselectTarget()
        {
            view.target.stats.OnHealthUpdate.RemoveListener(OnHealthUpdate);
            view.target.stats.OnProtectionUpdate.RemoveListener(OnProtectionUpdate);
        }

    }
}
