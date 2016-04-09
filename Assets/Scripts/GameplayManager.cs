using UnityEngine;
using System.Linq;
using System;
using UnityEngine.Assertions;

public class GameplayManager : MonoBehaviour
{
    public Player[] players;

    private Player winningPlayer;

    public event Action<Player> PlayerWins = delegate { };

    public static GameplayManager Instance { get; private set; }

    private void Awake()
    {
        winningPlayer = null;
        for (int i = 0; i < players.Length; i++)
        {
            players[i].id = i;
        }
        
        Assert.IsNull(Instance);
        Instance = this;
    }

    private void Update()
    {
        if (winningPlayer != null)
        {
            return;
        }

        var deadPlayers = players.Where(p => p.IsDead);
        if (deadPlayers.Count() == players.Length)
        {
            return;
        }

        if (deadPlayers.Count() >= players.Length - 1)
        {
            winningPlayer = players.Where(p => !p.IsDead).First();
            PlayerWins(winningPlayer);
        }
    }
}