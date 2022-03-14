using System.Collections;
using System.Collections.Generic;
using UdemyProje.Managers;
using UnityEngine;

namespace UdemyProject.Uis
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesButton()
        {
            GameManager.Instance.SplashScreen("Game");
        }

        public void NoButton()
        {
            GameManager.Instance.SplashScreen();
        }
    }
}
