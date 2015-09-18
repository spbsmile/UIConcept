using System.Collections;
using UIConcept.GUI;
using UnityEngine;

namespace UIConcept
{
    public class ManagerGame : MonoBehaviour
    {
        public int CountItemsForLose;
        public HealthBarHandler healthBar;
        public float timeRespawn;
        public Transform cirle;
        public Transform triangle;
       
        private Vector3 startPosition;

        private float acceleration = 1.4f;
        private float timeStartAcceleration;
        private float timeIntervalAcceleration = 5;

        public void Start()
        {
            startPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
            StartCoroutine(CreateItem(cirle, timeRespawn));
            StartCoroutine(CreateItem(triangle, timeRespawn));
            timeStartAcceleration = Time.time;
        }

        private IEnumerator CreateItem(Transform sample, float time)
        {
            var item = Instantiate(sample) as Transform;
            item.position = new Vector3(startPosition.x, Random.Range(-startPosition.y, startPosition.y));
            CreateHealthBar(item.GetComponent<Item>());
            yield return new WaitForSeconds(time);
            StartCoroutine(CreateItem(sample, CheckAcceleration(time)));
        }

        private void CreateHealthBar(Item item)
        {
            var sample = Instantiate(healthBar) as HealthBarHandler;
            sample.transform.SetParent(healthBar.transform.parent);
            sample.transform.localScale = Vector3.one;
            sample.item = item;
            sample.gameObject.SetActive(true);
        }

        private float CheckAcceleration(float time)
        {
            if (Time.time - timeStartAcceleration > timeIntervalAcceleration)
            {
                timeStartAcceleration = Time.time;
                time /= acceleration;
            }
            return time;
        }
    }
}