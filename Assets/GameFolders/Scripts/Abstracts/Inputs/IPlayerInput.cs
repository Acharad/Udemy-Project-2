using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject.Abstracts.Inputs
{
    public interface IPlayerInput
    {
        float Horizontal { get;}
        float Vertical { get;}
        bool JumpButtonDown { get;}
    }    
}
