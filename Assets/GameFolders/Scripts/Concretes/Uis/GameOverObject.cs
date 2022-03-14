using System;
using System.Collections;
using UdemyProject.Abstracts.Combats;
using UnityEngine;

namespace UdemyProject.Uis
{
    public class GameOverObject : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPanel;

        private IHealth _playerHealth;

        private void OnEnable()
        {
            gameOverPanel.SetActive(false);
        }

        public void SetPlayerHealth(IHealth health)
        {
            _playerHealth = health;
            
            _playerHealth.OnDead += HandleDeath;
        }
        
        private void HandleDeath()
        {
            gameOverPanel.SetActive(true);
            
            _playerHealth.OnDead -= HandleDeath;
            _playerHealth = null;
        }
    }
}
