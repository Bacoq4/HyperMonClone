using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame.EnemyIndication.Animation
{
    public class EnemyAnimController : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void playThrowAnim()
        {
            animator.SetTrigger("throw");
        }
    }

}
