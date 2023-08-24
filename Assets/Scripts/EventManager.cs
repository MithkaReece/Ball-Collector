using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action OnBallActive;
    public static event Action OnBallDeleted;
    public static event Action FreeBall;

    public static void CallBallActiveEvent()
    {
        OnBallActive?.Invoke();
    }

    public static void CallBallDeletedEvent()
    {
        OnBallDeleted?.Invoke();
    }

    public static void CallFreeBallEvent()
    {
        FreeBall?.Invoke();
    }
}
