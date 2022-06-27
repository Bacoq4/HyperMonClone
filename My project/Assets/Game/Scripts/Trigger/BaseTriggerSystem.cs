using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame.Trigger
{
    // main reason to make an abstract class is to make another types of trigger systems in future, but using base class for all references
    public abstract class BaseTriggerSystem : MonoBehaviour
    {
        private void sameTriggerOnAllMembers(Collider other)
        {
            // This is a template function, can be filled in future
        }
        protected abstract void ImplementOnTriggerEnter(Collider other);

        private void OnTriggerEnter(Collider other)
        {
            sameTriggerOnAllMembers(other);
            ImplementOnTriggerEnter(other);
        }
    }

}
