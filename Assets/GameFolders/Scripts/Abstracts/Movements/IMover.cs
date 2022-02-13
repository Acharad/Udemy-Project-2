using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject.Abstracts.Movements
{
    public interface IMover
    {
        void Tick(float horizontal);
    }    
}
