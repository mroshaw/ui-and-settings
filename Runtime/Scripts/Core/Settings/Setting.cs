using System;
using UnityEngine;

namespace DaftAppleGames.Settings
{
    [Serializable]
    public abstract class Setting
    {
        protected string StorageName => GetStorageName();
        public string DisplayName => GetDisplayName();

        protected abstract string GetStorageName();
        public abstract string GetDisplayName();

        protected abstract void Apply();

        protected abstract void Load();

        public void LoadAndApply()
        {
            Load();
            Apply();
        }
    }
}