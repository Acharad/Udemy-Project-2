using System.Collections;
using System.Collections.Generic;
using UdemyProject.Abstracts.Inputs;
using UdemyProject.Abstracts.Movements;
using UdemyProject.Inputs;
using UdemyProject.Movements;
using UnityEngine;

namespace UdemyProject.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        IPlayerInput _input;
        IMover _mover;

        float _horizontal;

        private void Awake()
        {
            _input = new PcInput();
            _mover = new Mover(this);
        }

        private void Update()
        {
            _horizontal = _input.Horizontal;
        }

        private void FixedUpdate()
        {
            _mover.Tick(_horizontal);
        }
    }
}