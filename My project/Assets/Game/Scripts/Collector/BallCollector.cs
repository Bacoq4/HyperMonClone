using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CoreGame.Collector
{
    public class BallCollector : Collector
    {
        [SerializeField] private int _moneyCount;
        [SerializeField] private TextMeshProUGUI moneyText;
        public int MoneyCount => _moneyCount;
        public void increaseMoney(int xAmount)
        {
            _moneyCount += xAmount;
            moneyText.text = _moneyCount.ToString();
        }

        public void decreaseMoney(int xAmount)
        {
            _moneyCount -= xAmount;
            if (_moneyCount < 0)
            {
                _moneyCount = 0;
            }
            moneyText.text = _moneyCount.ToString();
        }
    }

}
