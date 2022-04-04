using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProje.Managers;
using UnityEngine;

namespace UdemyProject.Controllers
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private int scorePoint = 10;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<PlayerController>() != null)
            {
                GameManager.Instance.IncreaseScore(scorePoint);
            }
        }
    }
}
