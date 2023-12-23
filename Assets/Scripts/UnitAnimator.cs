using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UnitAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnSprint()
    {
        _animator.SetTrigger(Triggers.SprintJump);
    }

    public void OffSprint()
    {
        _animator.ResetTrigger(Triggers.SprintJump);
    }

    public static class Triggers
    {
        public const string Walk = nameof(Walk);
        public const string SprintJump = nameof(SprintJump);
        public const string SprintSlide = nameof(SprintSlide);
    }

}
