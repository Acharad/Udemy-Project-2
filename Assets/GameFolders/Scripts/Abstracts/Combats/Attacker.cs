using System.Collections;
using System.Collections.Generic;
using UdemyProject.Abstracts.Combats;
using UnityEngine;

namespace UdemyProject.Abstracts.Combats
{
    public abstract class Attacker : MonoBehaviour, IAttacker
    {
        [SerializeField] int damage = 1;

        public int Damage => damage;

        public virtual void Attack(ITakeHit takeHit)
        {
            takeHit.TakeHit(this);
        }
    }    
}
