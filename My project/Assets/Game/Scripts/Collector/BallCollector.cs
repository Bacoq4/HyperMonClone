using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame.Collector
{
    public class BallCollector : Collector
    {
        [SerializeField] private int ballCount;

        public void collectBall(int xAmount)
        {
            ballCount += xAmount;
        }

        public void collectXBall(int xAmount)
        {
            ballCount -= xAmount;
            if (ballCount < 0)
            {
                ballCount = 0;
            }
        }
    }

}
