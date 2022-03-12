using System.Collections;
using System.Collections.Generic;
using UdemyProje3.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProje3.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] int score;

        private const string PLAYER_SCORE = "Player_Score";

        public static GameManager Instance { get; private set; }

        public int Score => score;

        public event System.Action<SceneTypeEnum> OnSceneChanged;
        public event System.Action<int> OnScoreChanged;

        private void Awake()
        {
            SingletonThisObject();
        }

        private IEnumerator Start()
        {
            yield return SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Menu"));

            if (PlayerPrefs.HasKey(PLAYER_SCORE))
            {
                score = PlayerPrefs.GetInt(PLAYER_SCORE);
            }
        }

        private void SingletonThisObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void SplashScreen(SceneTypeEnum sceneTypeEnum)
        {
            StartCoroutine(SplashScreenAsync(sceneTypeEnum));
        }

        private IEnumerator SplashScreenAsync(SceneTypeEnum sceneType)
        {
            yield return SceneManager.LoadSceneAsync(SceneTypeEnum.SplashScreen.ToString(), LoadSceneMode.Additive);
            OnSceneChanged?.Invoke(SceneTypeEnum.SplashScreen);

            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

            SceneManager.SetActiveScene(SceneManager.GetSceneByName("SplashScreen"));

            yield return new WaitForSeconds(5f);

            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            yield return SceneManager.LoadSceneAsync(sceneType.ToString(), LoadSceneMode.Additive);

            OnSceneChanged.Invoke(sceneType);

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneType.ToString()));
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void IncreaseScore(int scorePoint)
        {
            score += scorePoint;
            OnScoreChanged?.Invoke(score);
        }

        public void DecreaseScore(int scorePoint)
        {
            score -= scorePoint;
            OnScoreChanged?.Invoke(score);
        }

        public void SaveScore()
        {
            PlayerPrefs.SetInt(PLAYER_SCORE, score);
        }
    }
}