using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    [Header("Points of Focus")]
    public Transform BodyPointOfFocus;
    public Transform HandlePointOfFocus;
    public Transform InteriorPointOfFocus;
    public Transform EdgePointOfFocus;

    [Header("Camera Positions")]
    public GameObject Body;
    public GameObject Handle;
    public GameObject Interior;
    public GameObject Edge;

    [Space(10)] // 10 pixels of spacing here.
    public GameObject MainCamera;

    [Space(10)] // 10 pixels of spacing here.
    public bool HandleUp;


    private void Awake()
    {
        Instance = this;
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Idle:
                HandleIdle();
                break;
            case GameState.Inspected:
                break;
            case GameState.Open:
                break;
            case GameState.HandleUp:
                HandleHandleUp();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleIdle()
    {

    }

    private void HandleHandleUp()
    {

    }

    public enum GameState
    {
        Idle,
        Inspected,
        Open,
        HandleUp
    }
}
