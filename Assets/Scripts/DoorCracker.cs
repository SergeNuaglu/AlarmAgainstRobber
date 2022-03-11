using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class DoorCracker : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private UnityEvent _brokenDoor;

    private const string TriggerName = "Open";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void BreakTheDoor()
    {
        _animator.SetTrigger(TriggerName);
        _brokenDoor?.Invoke();
    }
}
