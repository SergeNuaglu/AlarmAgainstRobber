using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorCracker : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private UnityEvent _brokenDoor;

    private const string triggerName = "Open";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void BreakTheDoor()
    {
        _animator.SetTrigger(triggerName);
        _brokenDoor?.Invoke();
    }
}
