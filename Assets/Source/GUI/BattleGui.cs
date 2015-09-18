using System;
using UIConcept.Setting;
using UnityEngine;
using UnityEngine.UI;

namespace UIConcept.GUI
{
    public class BattleGui : MonoBehaviour
    {
        public ManagerGame managerGame;

        public static BattleGui instance;
        public Text scoring;
        public Text counterLose;
        public Text remain;
        public ResultWindow resultWindow;

        public void Awake()
        {
            instance = this;
            remain.text = managerGame.CountItemsForLose.ToString();
        }

        public void AddScore(int value)
        {
            scoring.text = (Convert.ToInt32(scoring.text) + value).ToString();
        }

        public void DecreaseLoseCounter()
        {
            var countMissItem = Convert.ToInt32(counterLose.text) + 1;
            counterLose.text = countMissItem.ToString();
            if (managerGame.CountItemsForLose <= countMissItem)
            {
                Time.timeScale = 0.0001f;
                if (!PlayerPrefs.HasKey(Settings.Record))
                {
                    PlayerPrefs.SetInt(Settings.Record, Convert.ToInt32(scoring.text));
                }
                else if (Convert.ToInt32(scoring.text) > PlayerPrefs.GetInt(Settings.Record))
                {
                    PlayerPrefs.SetInt(Settings.Record, Convert.ToInt32(scoring.text));
                }
                resultWindow.gameObject.SetActive(true);
            }
            remain.text = (Convert.ToInt32(remain.text) - 1).ToString();
        }
    }
}


