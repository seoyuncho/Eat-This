using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic; // 추가된 라인
using System.Linq;
public class ScoreManager : MonoBehaviour
{
    public TMP_InputField playerNameInput; // 이름 입력 필드
    public TextMeshProUGUI scoreText; // 점수를 표시할 텍스트
    public Button saveButton; // 저장 버튼
    public GameObject rankingPanel; // 랭킹 패널
    public TextMeshProUGUI rankingText; // 랭킹을 표시할 Text
    private string score;

    private void Start()
    {
        Debug.Log("ScoreManager start");
        // 점수 표시
        score = GameManager.Instance.Score.ToString();
        scoreText.text = "Score: " + score;
        Debug.Log($"{GameManager.Instance.Score.ToString()}");

        rankingPanel.SetActive(false);
        Debug.Log("panel");
    }

    public void SaveScore()
    {
        string playerName = playerNameInput.text;
        Debug.Log($"입력한거11111111{playerName}");
        int playerScore = int.Parse(score);
        Debug.Log($"입력한거{playerName}");

        // 고유한 키 생성
        string scoreKey = "Score_" + System.DateTime.Now.Ticks.ToString();

        // 점수 저장
        PlayerPrefs.SetString(scoreKey, playerName + ":" + playerScore);
        PlayerPrefs.Save();
        // 점수 키 리스트 업데이트
        UpdateScoreKeysList(scoreKey);

        // 랭킹 패널 표시
        ShowRankingPanel();
    }
    private void UpdateScoreKeysList(string newKey)
    {
        // 기존 키 리스트 불러오기
        string existingKeys = PlayerPrefs.GetString("ScoreKeys", "");
        List<string> keysList = existingKeys.Split(',').ToList();

        // 새 키가 이미 리스트에 없는 경우에만 추가
        if (!keysList.Contains(newKey))
        {
            keysList.Add(newKey);
            PlayerPrefs.SetString("ScoreKeys", string.Join(",", keysList));
        }
    }
    private List<KeyValuePair<string, int>> GetSortedScores()
    {
        var scores = new List<KeyValuePair<string, int>>();
        string[] keys = PlayerPrefs.GetString("ScoreKeys", "").Split(',');

        foreach (var key in keys)
        {
            if (!string.IsNullOrEmpty(key) && PlayerPrefs.HasKey(key))
            {
                string scoreEntry = PlayerPrefs.GetString(key);
                string[] parts = scoreEntry.Split(':');
                if (parts.Length == 2)
                {
                    string name = parts[0];
                    int score;
                    if (int.TryParse(parts[1], out score))
                    {
                        scores.Add(new KeyValuePair<string, int>(name, score));
                    }
                }
            }
        }

        // 점수에 따라 내림차순으로 정렬
        return scores.OrderByDescending(x => x.Value).ToList();
    }
    public void ShowRankingPanel()
    {
        // 랭킹 데이터 가져오기
        var sortedScores = GetSortedScores();

        // 상위 5개의 점수만 랭킹 텍스트로 생성
        rankingText.text = "";
        int count = 0;
        foreach (var score in sortedScores)
        {
            if (count < 5)
            {
                rankingText.text += score.Key + ": " + score.Value + "\n";
                count++;
            }
            else
            {
                break;
            }
        }

        // 랭킹 패널 활성화
        rankingPanel.SetActive(true);
    }
}