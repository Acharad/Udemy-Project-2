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
        int _currentHealth;
        
        public int CurrentHealth => _currentHealth;

        public bool IsDead => _currentHealth < 1;
        public void Heal(int lifeCount)
        {
            throw new NotImplementedException();
        }

        public event Action<int, int> OnHealthChanged;
        public event Action OnDead;
        
        private void Awake()
        {
            _currentHealth = maxHealth;
        }

        public void TakeHit(IAttacker attacker)
        {
            if (IsDead) return;
            
            _currentHealth -= attacker.Damage;
            OnHealthChanged?.Invoke(_currentHealth, maxHealth);

            if (IsDead) OnDead?.Invoke();
        }
    }    
}
