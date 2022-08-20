using UnityEngine;
using System.Collections.Generic;

public class PauseManager : MonoBehaviour, IPauseHandler
{
    private readonly List<IPauseHandler> _handlers = new List<IPauseHandler>();

    public bool IsPaused { get; private set; }
    public static PauseManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this; 
    }

    public void Register(IPauseHandler handler)
    {
        _handlers.Add(handler);
    }

    public void UnRegister(IPauseHandler handler)
    {
        _handlers.Remove(handler);
    }

    public void SetPaused(bool isPaused)
    {
        IsPaused = isPaused;

        foreach (var handler in _handlers)
        {
            handler.SetPaused(isPaused);
        }
    }
}
