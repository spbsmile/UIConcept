using UnityEngine;
using UnityEngine.UI;

namespace UIConcept.GUI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class HealthBarHandler : MonoBehaviour
    {
        public Item item;
        private Slider slider;
        private RectTransform rect;

        public void Start()
        {
            rect = GetComponent<RectTransform>();
            slider = GetComponent<Slider>();
            Init();
        }

        public void Init()
        {
            item.Death += () => GetComponent<CanvasGroup>().alpha = 0;
        }

        public void Update()
        {
            if (item == null) return;
            rect.anchoredPosition = Camera.main.WorldToScreenPoint(item.transform.position + item.offsetHealthBar);
            slider.value = NormalizeHP(item.HP);
        }

        private float NormalizeHP(int hp)
        {
            return Mathf.Clamp01((float)hp/item.HpMax);
        }
    }
}
