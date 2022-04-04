using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject.Uis;
using UnityEngine;

namespace UdemyProject.Controllers
{
    public class ShopController : MonoBehaviour
    {
        private ShopGameObject _shopGameObject;
        private void Start()
        {
            _shopGameObject = FindObjectOfType<ShopGameObject>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            IsPlayerTriggered(true);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            IsPlayerTriggered(false);
        }

        private void IsPlayerTriggered(bool trigger)
        {
            var player = GetComponent<PlayerController>();
            if (player != null)
                _shopGameObject.IsActiveShop(trigger);
        }
    }
}
