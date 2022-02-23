using System.Collections;
using System.Collections.Generic;
using UdemyProject.Abstracts.Inputs;
using UnityEngine;

namespace UdemyProject.Inputs
{
    public class MobileInput : IPlayerInput
    {
        //ileride eklenicek
        public float Horizontal => throw new System.NotImplementedException();
        public float Vertical => throw new System.NotImplementedException();
        public bool JumpButtonDown => throw new System.NotImplementedException();
        public bool AttackButtonDown => throw new System.NotImplementedException();
    }       
}
