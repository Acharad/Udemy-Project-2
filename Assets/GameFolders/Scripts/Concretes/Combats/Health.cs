using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject.Abstracts.Combats;
using UnityEngine;

namespace UdemyProject.Combats
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField] int maxHealth = 3;
        [SerializeField] int _currentHealth;

        public bool IsDead => _currentHealth < 1;
        
        public event Action<int, int> OnHealthChanged;
        public event Action OnDead;
        
        private void Awake()
        {
            _currentHealth = maxHealth;
        }

        public void TakeHit(IAttacker attacker)
        {
            Debug.Log("IsDead = " + IsDead);
            if (IsDead) return;
            
            _currentHealth -= attacker.Damage;
            OnHealthChanged?.Invoke(_currentHealth, maxHealth);
            
            Debug.Log("IsDead = " + IsDead);
            if (IsDead) OnDead?.Invoke();
        }
        
        public void Heal(int lifeCount)
        {
            _currentHealth = Mathf.Max(_currentHealth += lifeCount, maxHealth);
            OnHealthChanged?.Invoke(_currentHealth, maxHealth);
        }
    }    
}
