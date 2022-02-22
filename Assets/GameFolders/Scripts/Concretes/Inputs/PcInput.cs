using System.Collections;
using System.Collections.Generic;
using UdemyProject.Abstracts.Inputs;
using UnityEngine;

namespace UdemyProject.Inputs
{
    public class PcInput : IPlayerInput
    {
        public float Horizontal => Input.GetAxis("Horizontal");
        public float Vertical => Input.GetAxis("Vertical");
        public bool JumpButtonDown => Input.GetButtonDown("Jump");
    }
}