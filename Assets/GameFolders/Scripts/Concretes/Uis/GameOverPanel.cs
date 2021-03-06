using System.Collections;
using System.Collections.Generic;
using UdemyProje.Enums;
using UdemyProje.Managers;
using UnityEngine;

namespace UdemyProject.Uis
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesButton()
        {
            GameManager.Instance.SplashScreen(SceneTypeEnum.Game);
        }

        public void NoButton()
        {
            GameManager.Instance.SplashScreen(SceneTypeEnum.Menu);
        }
    }
}
