using UIConcept.Setting;
using UnityEngine;
using UnityEngine.UI;

namespace UIConcept.GUI
{
    public class MainMenu : MonoBehaviour
    {
        public Text record;

        public void Start()
        {
            var value = (PlayerPrefs.HasKey(Settings.Record)) ? PlayerPrefs.GetInt(Settings.Record).ToString() : "0";
            record.text = "Ваш рекорд: " + value;
        }

        public void Play()
        {
            Application.LoadLevel(1);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}

