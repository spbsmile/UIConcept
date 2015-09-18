using UIConcept.GUI;
using UnityEngine;

namespace UIConcept.Level
{
    public class EndBourder : MonoBehaviour
    {
        public void Start()
        {
            var pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
            transform.position = new Vector3(-pos.x - 10, 0);
        }
      
        public void OnTriggerEnter2D(Collider2D other)
        {
            var item = other.GetComponent<Item>();
            if (item)
            {
                item.Destroy();
                BattleGui.instance.DecreaseLoseCounter();
            }
        }
    }
}
