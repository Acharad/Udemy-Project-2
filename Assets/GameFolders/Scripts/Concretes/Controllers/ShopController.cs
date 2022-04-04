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
            IsPlayerTriggered( col,true);
            Debug.Log("Shop | OnTriggerEnter2D");
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            IsPlayerTriggered(other, false);
            Debug.Log("Shop | OnTriggerExit2D");
        }

        private void IsPlayerTriggered(Collider2D col,bool trigger)
        {
            var player = col.GetComponent<PlayerController>();
            Debug.Log(player);
            if (player != null)
                _shopGameObject.IsActiveShop(trigger);
        }
    }
}
