using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame.Collector
{
    public class BallCollector : Collector
    {
        [SerializeField] private int _moneyCount;
        public int MoneyCount => _moneyCount;
        public void collectBall(int xAmount)
        {
            _moneyCount += xAmount;
        }

        public void collectXBall(int xAmount)
        {
            _moneyCount -= xAmount;
            if (_moneyCount < 0)
            {
                _moneyCount = 0;
            }
        }
    }

}
