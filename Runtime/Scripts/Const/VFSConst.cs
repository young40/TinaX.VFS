﻿namespace TinaX.VFSKit.Const
{
    public static class VFSConst
    {
        public const string ServiceName = "TinaX.VFS";

        public const string ConfigFileName = "VFSConfig";

        public static string ConfigFilePath_Resources = $"{TinaX.Const.FrameworkConst.Framework_Configs_Folder_Path}/{ConfigFileName}";

        public static System.Type[] IgnoreType =
        {
#if UNITY_EDITOR
            typeof(UnityEditor.MonoScript),
            typeof(UnityEditor.DefaultAsset),
#endif
        };

        public const string ABsHashFileName = "filehashs.json";

        /// <summary>
        /// vfs 主文件
        /// </summary>
        public const string VFS_FOLDER_MAIN = "vfs_root";
        /// <summary>
        /// vfs 扩展包
        /// </summary>
        public const string VFS_FOLDER_EXTENSION = "vfs_extensions";
        public const string VFS_FOLDER_DATA = "vfs_data";

        public const string VFS_STREAMINGASSETS_PATH = "Assets/SteamingAssets/TinaX";

        public const string AssetsManifestFileName = "VFSManifest.json";

    }
}

