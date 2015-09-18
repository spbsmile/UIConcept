using System;
using UIConcept.GUI;
using UnityEngine;

namespace UIConcept
{
    public class Item : MonoBehaviour
    {
        public int HP = 100;
        public int damageOnClick = 25;
        public int score;
        public Vector3 offsetHealthBar;

        public Action Death;
        public int HpMax { private set; get; }

        public void Awake()
        {
            HpMax = HP;
        }

        public void OnMouseDown()
        {
            HP -= damageOnClick;
            if (HP <= 0)
            {
                BattleGui.instance.AddScore(score);
                Destroy();
            }
        }

        public void Destroy()
        {
            if (Death != null)
            {
                Death();
            }
            gameObject.SetActive(false);
        }
    }
}
