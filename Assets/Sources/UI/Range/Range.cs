
using UnityEngine;
using UnityEngine.UI;

namespace UI.Range
{
    class Range : MonoBehaviour
    {

        public Scrollbar scrollbar;
        public Scrollbar.ScrollEvent OnScroll;

        public Scrollbar.Direction direction = Scrollbar.Direction.LeftToRight;

        public bool allowSteps;
        public int numberOfSteps;

        private void OnValidate()
        {
            scrollbar = GetComponentInChildren<Scrollbar>();
            scrollbar.direction = direction;

            if (allowSteps && numberOfSteps != 0)
                scrollbar.numberOfSteps = numberOfSteps;
            else
                scrollbar.numberOfSteps = 0;
        }

        private void Start()
        {
            scrollbar.onValueChanged.RemoveAllListeners();
            scrollbar.onValueChanged.AddListener(ScrollHandler);

            if (allowSteps && numberOfSteps != 0)
            {
                scrollbar.numberOfSteps = numberOfSteps;
            }
        }

        private void ScrollHandler(float value)
        {
            OnScroll?.Invoke(value);
        }

        public void Set(float value)
        {
            scrollbar.value = value;
        }

        public void Set(int value)
        {
            scrollbar.value = Unnormalize(value);
        }

        public float Value => scrollbar.value;
        public int Normalized => Normalize(scrollbar.value);

        public static int Normalize(float value)
        {
            return Mathf.CeilToInt(value * 100);
        }

        public static int Unnormalize(int value)
        {
            return value / 100;
        }

    }
}
