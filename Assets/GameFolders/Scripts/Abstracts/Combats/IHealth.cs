using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject.Abstracts.Combats
{
    public interface IHealth : ITakeHit
    {
        public int CurrentHealth { get; }
        event System.Action OnHealthChanged;
    }
}
