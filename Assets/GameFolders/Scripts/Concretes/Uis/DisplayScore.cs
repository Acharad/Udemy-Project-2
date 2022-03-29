using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UdemyProje.Managers;
using UnityEngine;

namespace UdemyProject.Uis
{
    public class DisplayScore : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _text.text = GameManager.Instance.Score.ToString();
        }

        private void OnEnable()
        {
            GameManager.Instance.OnScoreChanged += HandleScoreChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnScoreChanged -= HandleScoreChanged;
        }

        private void HandleScoreChanged(int score)
        {
            _text.text = score.ToString();
        }
    }
}
