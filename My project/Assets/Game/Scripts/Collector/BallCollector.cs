using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame.Collector
{
    public class BallCollector : Collector
    {
        [SerializeField] private int _ballCount;
        public int BallCount => _ballCount;
        public void collectBall(int xAmount)
        {
            _ballCount += xAmount;
        }

        public void collectXBall(int xAmount)
        {
            _ballCount -= xAmount;
            if (_ballCount < 0)
            {
                _ballCount = 0;
            }
        }
    }

}
