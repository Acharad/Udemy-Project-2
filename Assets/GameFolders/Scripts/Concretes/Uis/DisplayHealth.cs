using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject.Abstracts.Combats;
using UdemyProject.Combats;
using UdemyProject.Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace UdemyProject.Uis
{
    public class DisplayHealth : MonoBehaviour
    {
        private Image _healthImage;
        private IHealth _health;

        private void Awake()
        {
            _healthImage = GetComponent<Image>();

        }

        private void OnEnable()
        {
            _health = FindObjectOfType<PlayerController>().GetComponent<Health>();
            _health.OnHealthChanged += HandleHealthChanged;
        }
        
        private void OnDisable()
        {
            _health.OnHealthChanged -= HandleHealthChanged;
        }
        
        private void HandleHealthChanged(int currentHealth, int maxHealth)
        {
            var result = (float)currentHealth / maxHealth ;
            _healthImage.fillAmount = result;
        }
    }
}
