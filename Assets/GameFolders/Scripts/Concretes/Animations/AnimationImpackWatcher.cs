using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject.Animations
{
    public class AnimationImpackWatcher : MonoBehaviour
    {
        public event System.Action OnImpact;

        public void Impact()
        {
            OnImpact?.Invoke();
        }
    }    
}
