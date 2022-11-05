using System;
using System.Collections.Generic;
using GameCore;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameClient
{
    public class MusicModule : BaseGameManagerModule
    {
        [SerializeField] private Dictionary<LevelSwitchModule.GameLevels, LevelMusicData> _levelSoundPair = new Dictionary<LevelSwitchModule.GameLevels, LevelMusicData>();

        public LevelMusicData GetLevelSound(LevelSwitchModule.GameLevels level)
        {
            return _levelSoundPair[level];
        }

        [Serializable, HideReferenceObjectPicker]
        public class LevelMusicData
        {
            [SerializeField] private AudioClip _playOnShot;
            [SerializeField] private AudioClip _loopedAudio;

            public AudioClip PlayOnShot => _playOnShot;
            public AudioClip LoopedAudio => _loopedAudio;
        }
    }
}
