using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace UI.Checkbox
{
    class CheckboxGroup : MonoBehaviour
    {
        public List<Checkbox> checkboxes;
        
        private void OnValidate()
        {
            if (checkboxes == null)
                checkboxes = GetComponentsInChildren<Checkbox>().ToList();
        }

    }
}
