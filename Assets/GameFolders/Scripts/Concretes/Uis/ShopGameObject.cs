using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject.Abstracts.Combats;
using UdemyProject.Controllers;
using UnityEngine;

namespace UdemyProject.Uis
{
    public class ShopGameObject : MonoBehaviour
    {
        [SerializeField] private QuestionPanel QuestionPanel;
        [SerializeField] private GameObject shop;

        private IHealth _playerHealth;
        private void OnEnable()
        {
            _playerHealth = FindObjectOfType<PlayerController>().GetComponent<IHealth>();
        }

        private void OnDisable()
        {
            _playerHealth = null;
        }

        public void BuyLifeClicked(int lifeCount)
        {
            QuestionPanel.gameObject.SetActive(true);
            QuestionPanel.SetLifeCountAndReferences(lifeCount, _playerHealth);
        }

        public void IsActiveShop(bool isActive)
        {
            shop.SetActive(isActive);
        }
    }
}