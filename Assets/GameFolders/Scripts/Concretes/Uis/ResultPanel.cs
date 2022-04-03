using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UdemyProject.Uis
{
    public class ResultPanel : MonoBehaviour
    {
        private TextMeshProUGUI _resultText;
        private void Awake()
        {
            _resultText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        }

        public void ResultMessage(string result)
        {
            _resultText.text = result;
        }
    }
}
