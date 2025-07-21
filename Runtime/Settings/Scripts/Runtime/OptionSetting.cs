using System;
using System.Collections.Generic;

namespace DaftAppleGames.Settings
{
    [Serializable]
    public abstract class OptionSetting : IntSetting
    {
        public abstract List<string> GetOptions();
    }
}