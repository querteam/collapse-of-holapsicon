using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Mechanics.Interface.EntityView
{
    public class EntityCredentials : MonoBehaviour
    {

        public Texture2D thumb;
        public Texture2D defaultThumb;
        
        public EntityView view;

        public RawImage Thumb;
        public TextMeshProUGUI Title;
        public TextMeshProUGUI UpgradeLevel;

        public void OnSelectTarget()
        {
            thumb = view.target.thumb;
            if (thumb == null)
                thumb = defaultThumb;
            Thumb.texture = thumb;
            Title.text = view.target.name;
            UpgradeLevel.text = view.target.UpgradeLevel.ToString();
        }

        public void OnDeselectTarget()
        {

        }

    }
}
