using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UdemyProje.Managers;
using UdemyProject.Abstracts.Combats;
using UdemyProject.Controllers;
using UnityEngine;

namespace UdemyProject.Uis
{
    public class QuestionPanel : MonoBehaviour
    {
        [SerializeField] private ResultPanel resultPanel;
        private TextMeshProUGUI _messageText;
        private int _lifeCount;
        private IHealth _playerHealth;
        private void Awake()
        {
            _messageText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        }

        private void OnDisable()
        {
            _lifeCount = 0;
            _playerHealth = null;
        }

        public void SetLifeCountAndReferences(int lifeCount, IHealth playerHealth)
        {
            _lifeCount = lifeCount;
            _messageText.text = $"Do you want buy {_lifeCount} heal?";
            _playerHealth = playerHealth;
        }

        public void YesClicked()
        {
            resultPanel.gameObject.SetActive(true);

            if (_lifeCount <= GameManager.Instance.Score)
            {
                resultPanel.ResultMessage($"You have bought {_lifeCount} heal");
                GameManager.Instance.DecreaseScore(_lifeCount);
                _playerHealth.Heal(_lifeCount);
            }
                
            else
                resultPanel.ResultMessage("You don't have enough score");
            this.gameObject.SetActive(false);
        }
    }
}
