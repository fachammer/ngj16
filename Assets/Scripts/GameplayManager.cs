using UnityEngine;
using System.Linq;
using System;
using System.Collections.Generic;

public class GameplayManager : MonoBehaviour
{
    public Player[] players;

    public MonoBehaviour[] componentsToEnable;

    private Player winningPlayer;

    public event Action<Player> PlayerWins = delegate { };

    private List<Player> remainingPlayers;

    private void Awake()
    {
        winningPlayer = null;
        for (int i = 0; i < players.Length; i++)
        {
            players[i].id = i;
            players[i].GetComponent<Controlls>().enabled = false;
        }

        remainingPlayers = new List<Player>(players);
    }

    private void Update()
    {
        if (winningPlayer != null)
        {
            return;
        }

        var diedPlayers = remainingPlayers.Where(p => p.IsDead).ToList();
        remainingPlayers.RemoveAll(diedPlayers.Contains);

        if (remainingPlayers.Count == 1)
        {
            winningPlayer = remainingPlayers.First();
            PlayerWins(winningPlayer);
        }
    }

    public void EnableAll()
    {
        foreach (var player in players)
        {
            player.GetComponent<Controlls>().enabled = true;
        }

        foreach (var component in componentsToEnable)
        {
            component.enabled = true;
        }
    }
}