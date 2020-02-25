﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using TinaX;
using System.IO;
using TinaX.IO;
using TinaXEditor.VFSKit.Const;
using TinaX.VFSKit.Const;

namespace TinaXEditor.VFSKit.Utils
{
    using Object = UnityEngine.Object;

    public static class VFSEditorUtil
    {
        internal static bool GetPathAndGUIDFromTarget(Object t, out string path, ref string guid, out Type mainAssetType)
        {
            mainAssetType = null;
            path = AssetDatabase.GetAssetOrScenePath(t);
            
            guid = AssetDatabase.AssetPathToGUID(path);
            if (guid.IsNullOrEmpty())
                return false;
            mainAssetType = AssetDatabase.GetMainAssetTypeAtPath(path);
            if (mainAssetType != t.GetType() && !typeof(AssetImporter).IsAssignableFrom(t.GetType()))
                return false;
            return true;
        }

        internal static void InitVFSFoldersInStreamingAssets()
        {
            string project_root_path = Directory.GetCurrentDirectory();
            //tinax
            XDirectory.CreateIfNotExists(Path.Combine(project_root_path, VFSConst.VFS_STREAMINGASSETS_PATH));
            XDirectory.CreateIfNotExists(Path.Combine(project_root_path, VFSConst.VFS_STREAMINGASSETS_PATH,VFSConst.VFS_FOLDER_MAIN));
            XDirectory.CreateIfNotExists(Path.Combine(project_root_path, VFSConst.VFS_STREAMINGASSETS_PATH,VFSConst.VFS_FOLDER_DATA));
            XDirectory.CreateIfNotExists(Path.Combine(project_root_path, VFSConst.VFS_STREAMINGASSETS_PATH,VFSConst.VFS_FOLDER_EXTENSION));
        }

        public static void RemoveAllAssetbundleSigns(bool showEditorGUI = true)
        {
            var ab_names = AssetDatabase.GetAllAssetBundleNames();

            int counter = 0;
            int counter_t = 0;
            int length = ab_names.Length;

            foreach(var name in ab_names)
            {
                AssetDatabase.RemoveAssetBundleName(name, true);
                if (showEditorGUI)
                {
                    counter++;
                    if(length > 100)
                    {
                        counter_t++;
                        if (counter_t >= 30)
                        {
                            counter_t = 0;
                            EditorUtility.DisplayProgressBar("TinaX VFS", $"Remove Assetbundle sign - {counter} / {length}", counter / length);
                        }
                    }
                    else
                    {
                        EditorUtility.DisplayProgressBar("TinaX VFS", $"Remove Assetbundle sign - {counter} / {length}", counter / length);
                    }
                }
            }

            if (showEditorGUI)
                EditorUtility.ClearProgressBar();

            AssetDatabase.RemoveUnusedAssetBundleNames();
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        

    }
}

