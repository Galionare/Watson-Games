/*using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;
using TMPro;
using System.Collections.Generic;

public class InputDisplay : MonoBehaviour
{
    public static InputDisplay Instance;

    public List<Player> players;

    public GameObject backgroundText;
    public TMP_Text displayText;
    public Button yesButton;
    public Button noButton;
    public TMP_InputField inputField;
    public Button inputButton;

    public GameObject backgroundScore;
    public TMP_Text scoreText;

    private TaskCompletionSource<bool> _taskCompletionSourceBool;
    private TaskCompletionSource<string> _taskCompletionSourceString;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }

        backgroundText.SetActive(false);
        displayText.gameObject.SetActive(false);
        inputField.gameObject.SetActive(false);
        inputButton.gameObject.SetActive(false);
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);

        backgroundScore.SetActive(true);
        scoreText.gameObject.SetActive(true);
    }

    public async Task ShowMessage(string message) {
        backgroundText.SetActive(true);
        displayText.gameObject.SetActive(true);
        displayText.text = message;
        await Task.Delay(4000);
        backgroundText.SetActive(false);
        displayText.gameObject.SetActive(false);
    }

    public Task<bool> AskYesOrNo(string question) {
        backgroundText.SetActive(true);
        displayText.gameObject.SetActive(true);
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);

        displayText.text = question;

        _taskCompletionSourceBool = new TaskCompletionSource<bool>();

        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();

        yesButton.onClick.AddListener(() => OnAnswer(true));
        noButton.onClick.AddListener(() => OnAnswer(false));

        return _taskCompletionSourceBool.Task;
    }

    private void OnAnswer(bool answer) {
        backgroundText.SetActive(false);
        _taskCompletionSourceBool.SetResult(answer);
    }

    public Task<string> AskInput(string question) {
        backgroundText.SetActive(true);
        displayText.gameObject.SetActive(true);
        inputField.gameObject.SetActive(true);
        inputButton.gameObject.SetActive(true);

        displayText.text = question;
        inputField.text = "";

        _taskCompletionSourceString = new TaskCompletionSource<string>();

        inputButton.onClick.RemoveAllListeners();
        inputButton.onClick.AddListener(OnSubmit);

        return _taskCompletionSourceString.Task;
    }

    public void OnSubmit() {
        string input = inputField.text.Trim();
        backgroundText.SetActive(false);
        inputField.gameObject.SetActive(false);
        inputButton.gameObject.SetActive(false);
        displayText.gameObject.SetActive(false);
        _taskCompletionSourceString.SetResult(input);
    }

    public Task<bool> AskMortgageOrSell(string question) {
        yesButton.GetComponentInChildren<TMP_Text>().text = "Mortgage";
        noButton.GetComponentInChildren<TMP_Text>().text = "Sell";

        backgroundText.SetActive(true);
        displayText.gameObject.SetActive(true);
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);

        displayText.text = question;

        _taskCompletionSourceBool = new TaskCompletionSource<bool>();

        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();

        yesButton.onClick.AddListener(() => OnAnswer(true));
        noButton.onClick.AddListener(() => OnAnswer(false));

        yesButton.GetComponentInChildren<TMP_Text>().text = "Yes";
        noButton.GetComponentInChildren<TMP_Text>().text = "No";

        return _taskCompletionSourceBool.Task;
    }

    public void UpdateScoreboard() {
        backgroundScore.SetActive(true);
        Player player = players[0];

        string scoreboard = "";
        for (int i = 1; i <= players.Count; i++) {
            player = players[i];
            scoreboard += $"Player {i}: {player.money}\n";
            if (player.owned.Count > 0) {
                foreach(var property in player.owned) {
                    scoreboard += $" - {property.NameProperty}, Houses: {property.NumOfHouses}, Mortgaged: {property.Mortgaged}\n";
                }
            }
            else {
                scoreboard += " - No properties\n";
            }
            scoreboard += "\n";
        }

        scoreText.text = scoreboard;

        RectTransform bgRect = backgroundScore.GetComponent<RectTransform>();
        float height = 150f * (players.Count - 1);
        bgRect.sizeDelta = new Vector2(bgRect.sizeDelta.x, height);
    }
}*/
