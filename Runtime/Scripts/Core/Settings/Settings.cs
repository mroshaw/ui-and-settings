using System.IO;
using Unity.Plastic.Newtonsoft.Json;
using Unity.Plastic.Newtonsoft.Json.Linq;
using UnityEngine;

namespace DaftAppleGames.Settings
{
    public abstract class Settings
    {
        protected abstract string GetStorageName();
        protected abstract string GetDisplayName();
    }
}