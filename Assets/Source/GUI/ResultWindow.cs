using UIConcept.Setting;
using UnityEngine;
using UnityEngine.UI;

namespace UIConcept.GUI
{
    public class ResultWindow : MonoBehaviour
    {
        public Text record;

        public void Play()
        {
            Time.timeScale = 1;
            Application.LoadLevel(Application.loadedLevel);
        }

        public void Exit()
        {
            Time.timeScale = 1;
            Application.LoadLevel(0);
        }

        public void OnEnable()
        {
            var value = (PlayerPrefs.HasKey(Settings.Record)) ? PlayerPrefs.GetInt(Settings.Record).ToString() : "0";
            record.text = "Ваш рекорд: " + value;
        }
    }
}

