using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
    public class Restart : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Text _text;

        private void Start()
        {
            _gameManager.SubscribeOnInitialize(OnManagerInit);
        }

        public void OnManagerInit()
        {
            var gameEnd = _gameManager.GetController<GameEndController>();
            gameEnd.OnPovestkaLose += ShowWinOrLose;
            gameEnd.OnWin += ShowWinOrLose;
            gameEnd.OnStatNullLoose += ShowWinOrLose;
        }

        private void ShowWinOrLose(string text)
        {
            _prefab.gameObject.SetActive(true);
            _text.text = text;

        }

        public void DestroyThis()
        {
            _prefab.gameObject.SetActive(false);
        }
    }
}
