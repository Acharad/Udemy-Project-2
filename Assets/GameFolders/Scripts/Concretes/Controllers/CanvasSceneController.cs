using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProje.Enums;
using UdemyProje.Managers;
using UnityEngine;

namespace UdemyProject.Controllers
{
    public class CanvasSceneController : MonoBehaviour
    {
        [SerializeField] private SceneTypeEnum sceneType;
        [SerializeField] private GameObject canvasObject;

        private void Start()
        {
            GameManager.Instance.OnSceneChanged += HandleSceneChanged;
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnSceneChanged -= HandleSceneChanged;
        }

        private void HandleSceneChanged(SceneTypeEnum sceneType)
        {
            if (sceneType == this.sceneType)
            {
                canvasObject.SetActive(true);
            }
            else
            {
                canvasObject.SetActive(false);
            }
        }
    }
}
