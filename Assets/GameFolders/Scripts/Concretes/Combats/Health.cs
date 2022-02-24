using System.Collections;
using System.Collections.Generic;
using UdemyProject.Abstracts.Combats;
using UnityEngine;

namespace UdemyProject.Combats
{
    public class Health : MonoBehaviour, ITakeHit
    {
        [SerializeField] int maxHealth = 3;

        int _currentHealth;

        private void Awake()
        {
            _currentHealth = maxHealth;
        }

        public void TakeHit(IAttacker attacker)
        {
            _currentHealth -= attacker.Damage;
        }
    }    
}
