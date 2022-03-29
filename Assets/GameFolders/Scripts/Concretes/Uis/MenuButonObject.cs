using System.Collections;
using System.Collections.Generic;
using UdemyProje.Enums;
using UdemyProje.Managers;
using UnityEngine;

namespace UdemyProject.Uis
{
    public class MenuButonObject : MonoBehaviour
    {
        public void StartGame()
        {
            GameManager.Instance.SplashScreen(SceneTypeEnum.Game);
        }

        public void QuitGame()
        {
            GameManager.Instance.QuitGame();
        }
    }
}

