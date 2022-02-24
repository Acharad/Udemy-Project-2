using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject.Abstracts.Combats
{
    public interface ITakeHit
    {
        void TakeHit(IAttacker attacker);
    }    
}
