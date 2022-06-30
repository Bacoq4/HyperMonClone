using System;
using System.Collections;
using System.Collections.Generic;
using CoreGame.Movement;
using UnityEngine;
using UnityEngine.UI;

namespace CoreGame.PlayerIndication
{
    public class Player : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<SwerveMovement>().enabled = false;
            GetComponent<ForwardMovement>().enabled = false;
        }
    }
}
