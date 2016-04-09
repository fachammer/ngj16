using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Assertions;
using System.Collections;

public class GameOverHandler : MonoBehaviour
{

    public GameplayManager gameplayManager;

    public GameOverScreen gameOverScreen;

    public GameRestartController gameRestartController;

    private Queue<IEnumerator> coroutinesToExecute = new Queue<IEnumerator>();

    private void Awake()
    {
        Assert.IsNotNull(gameOverScreen);
        Assert.IsNotNull(gameplayManager);
        Assert.IsNotNull(gameRestartController);
        gameRestartController.enabled = false;
        gameplayManager.PlayerWins += OnPlayerWins;
        gameplayManager.PlayerLoses += OnPlayerLoses;
    }

    private void Update()
    {
        if (coroutinesToExecute.Any())
        {
            StartCoroutine(ExecuteCoroutines());
        }
    }

    private IEnumerator ExecuteCoroutines()
    {
        while (coroutinesToExecute.Any())
        {
            var coroutine = coroutinesToExecute.Dequeue();
            yield return StartCoroutine(coroutine);
        }
    }

    private void OnPlayerWins(Player winningPlayer)
    {
        IEnumerable<MonoBehaviour> controllers = GameObject.FindObjectsOfType<Controlls>();
        IEnumerable<MonoBehaviour> deathTriggers = GameObject.FindObjectsOfType<DeathTrigger>();

        var componentsToDisable = controllers.Concat(deathTriggers);
        foreach (var component in componentsToDisable)
        {
            component.enabled = false;
        }

        coroutinesToExecute.Enqueue(WinningPlayerRoutine(winningPlayer));
    }

    private IEnumerator WinningPlayerRoutine(Player winningPlayer)
    {
        yield return StartCoroutine(gameOverScreen.SetWinningPlayer(winningPlayer));
        gameRestartController.enabled = true;
    }

    private void OnPlayerLoses(Player losingPlayer)
    {
        coroutinesToExecute.Enqueue(gameOverScreen.SetLeakedPlayer(losingPlayer));
    }
}