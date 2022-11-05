using System.Collections;
using System.Linq;
using GameCore;
using UnityEngine;

namespace GameClient
{
    public class MusicController : BaseGameManagerModuleController<MusicModule>
    {
        private GameManager _gameManager;
        private LevelSwitchController _levels;
        private AudioSource _effectsSound;
        private AudioSource _locationSound;

        private Coroutine _locationSoundCoroutine;
        private Coroutine _effectsSoundCoroutine;

        protected override void InternalInitialize()
        {
            _gameManager = GameManager.Instance;
            _gameManager.SubscribeOnInitialize(OnInitialize);
            _locationSound = _gameManager.gameObject.AddComponent<AudioSource>();
            _effectsSound = _gameManager.gameObject.AddComponent<AudioSource>();
        }

        private void OnInitialize()
        {
            _levels.OnGameLevelLoaded += PlaySoundByLocation;
        }

        private void PlaySoundByLocation(LevelSwitchModule.GameLevels level)
        {
            var musicData = Data.GetLevelSound(level);
            PlayLocationSound(musicData.PlayOnShot, musicData.LoopedAudio);
        }

        private void PlayLocationSound(params AudioClip[] audios)
        {
            if (_locationSoundCoroutine != null)
            {
                _gameManager.StopCoroutine(_locationSoundCoroutine);
            }
            _locationSoundCoroutine = _gameManager.StartCoroutine(PlaySeq(_locationSound, audios));
        }

        private static IEnumerator PlaySeq(AudioSource source, params AudioClip[] audios)
        {
            for (var i=0; i < audios.Length - 1; i++)
            {
                var audio = audios[i];
                source.PlayOneShot(audio);
                yield return new WaitForSeconds(audio.length);
            }

            source.clip = audios.Last();
            source.loop = true;
            source.Play();
        }
    }
}
