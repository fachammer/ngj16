using UnityEngine;
using System.Linq;
using System;

public class GameplayManager : MonoBehaviour
{
    public Player[] players;

    private Player winningPlayer;

    public event Action<Player> PlayerWins = delegate { };

    private void Awake()
    {
        winningPlayer = null;
        for (int i = 0; i < players.Length; i++)
        {
            players[i].id = i;
        }
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