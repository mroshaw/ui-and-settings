using System;
using UnityEngine;

namespace DaftAppleGames.Settings
{
    [Serializable]
    public abstract class Setting : ScriptableObject
    {
        public string settingId;
        protected string StorageName => GetStorageName();
        public string DisplayName => GetDisplayName();

        protected abstract string GetStorageName();
        public abstract string GetDisplayName();

        public abstract void Apply();

        public abstract void Load();

        public abstract void Save();

        public void LoadAndApply()
        {
            Load();
            Apply();
        }
    }
}