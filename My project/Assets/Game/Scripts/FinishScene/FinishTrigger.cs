using System;
using System.Collections;
using System.Collections.Generic;
using CoreGame.PlayerIndication;
using UnityEngine;
using UnityEngine.Events;

namespace CoreGame.Finish
{
    public class FinishTrigger : MonoBehaviour
    {
        public UnityAction OnDuelStarted;
        [HideInInspector] public Player player;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                player = other.GetComponent<Player>();
                OnDuelStarted?.Invoke();
            }
        }
    }
   
}