using System;
using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUIProperty
    {
        #region CONTROLBUTTON

        public static bool ControlButton(string text, params GUILayoutOption[] options)
            => ControlButton(new GUIContent(text), SizeType.Short, options);
        
        public static bool ControlButton(GUIContent text, params GUILayoutOption[] options)
            => ControlButton(new GUIContent(text), SizeType.Short, options);
        
        public static bool ControlButton(string text, SizeType size, params GUILayoutOption[] options)
            => ControlButton(new GUIContent(text), size, options);
        
        public static bool ControlButton(GUIContent text, SizeType size, params GUILayoutOption[] options)
        {
            Rect position = EditorGUILayout.GetControlRect(false, 6 * (int)size, GUI.skin.button, options);
            position.x -= 4;
            position.width += 4;
            return GUI.Button(position, text, PhantomGUIStyle.BoldButton);
        }

        #endregion

        #region ICONBUTTON

        public static bool IconButton(Texture2D texture, params GUILayoutOption[] options)
            => IconButton(new GUIContent(texture), SizeType.Short, options);
        
        public static bool IconButton(GUIContent texture, params GUILayoutOption[] options)
            => IconButton(texture, SizeType.Short, options);
        
        public static bool IconButton(Texture2D texture, SizeType size, params GUILayoutOption[] options)
            => IconButton(new GUIContent(texture), size, options);

        public static bool IconButton(GUIContent texture, SizeType size, params GUILayoutOption[] options)
        {
            Rect position = EditorGUILayout.GetControlRect(false, (int)size, GUI.skin.button, options);
            return GUI.Button(position, texture, PhantomGUIStyle.Button);
        }        

        #endregion
        
        #region DISPLAYLABEL
        
        public static void DisplayLabel(string text, params GUILayoutOption[] options)
            => DisplayLabel(GUIContent.none, new GUIContent(text), options);
        
        public static void DisplayLabel(string label, string text, params GUILayoutOption[] options)
            => DisplayLabel(new GUIContent(label), new GUIContent(text), options);
        
        public static void DisplayLabel(GUIContent label, string text, params GUILayoutOption[] options)
            => DisplayLabel(label, new GUIContent(text), options);
        
        public static void DisplayLabel(GUIContent label, GUIContent text, params GUILayoutOption[] options)
        {
            Rect position = EditorGUILayout.GetControlRect(label != GUIContent.none, EditorGUIUtility.singleLineHeight, EditorStyles.label, options);
            position = EditorGUI.PrefixLabel(position, label, PhantomGUIStyle.BoldLabel);
            EditorGUI.LabelField(position, text, PhantomGUIStyle.Label);
        }
        
        #endregion
        
        #region LABELTEXT

        public static string LabelText(string text, params GUILayoutOption[] options)
            => LabelText(GUIContent.none, text, options);
        
        public static string LabelText(string label, string text, params GUILayoutOption[] options)
            => LabelText(new GUIContent(label), text, options);
        
        public static string LabelText(GUIContent label, string text, params GUILayoutOption[] options)
        {
            Rect position = EditorGUILayout.GetControlRect(label != null, EditorGUIUtility.singleLineHeight, EditorStyles.textField, options);
            position = EditorGUI.PrefixLabel(position, new GUIContent(label), PhantomGUIStyle.BoldLabel);
            return EditorGUI.TextField(position, text, PhantomGUIStyle.TextField);
        }

        #endregion
        
        #region MULTILINETEXT
        
        public static string MultilineText(string label, string text, params GUILayoutOption[] options)
            => MultilineText(new GUIContent(label), text, 3, options);
        
        public static string MultilineText(GUIContent label, string text, params GUILayoutOption[] options)
            => MultilineText(label, text, 3, options);
        
        public static string MultilineText(string label, string text, float multiline, params GUILayoutOption[] options)
            => MultilineText(new GUIContent(label), text, multiline, options);
        
        public static string MultilineText(GUIContent label, string text, float multiline, params GUILayoutOption[] options)
        {
            var position = EditorGUILayout.GetControlRect(label != null, EditorGUIUtility.singleLineHeight * multiline, EditorStyles.textArea, options);
            position = EditorGUI.PrefixLabel(position, new GUIContent(label), PhantomGUIStyle.BoldLabel);
            return EditorGUI.TextArea(position, text, PhantomGUIStyle.TextField);
        }

        #endregion
        
        #region LABELPOPUP

        public static int LabelPopup(int selectedIndex, string[] displayedOptions, params GUILayoutOption[] options)
            => LabelPopup(GUIContent.none, selectedIndex, displayedOptions, options);
        
        public static int LabelPopup(string label, int selectedIndex, string[] displayedOptions, params GUILayoutOption[] options)
            => LabelPopup(new GUIContent(label), selectedIndex, displayedOptions, options);
        
        public static int LabelPopup(GUIContent label, int selectedIndex, string[] displayedOptions, params GUILayoutOption[] options)
        {
            Rect position = EditorGUILayout.GetControlRect(label != null, EditorGUIUtility.singleLineHeight, EditorStyles.popup, options);
            position = EditorGUI.PrefixLabel(position, new GUIContent(label), PhantomGUIStyle.BoldLabel);
            return EditorGUI.Popup(position, selectedIndex, displayedOptions, PhantomGUIStyle.Popup);
        }

        #endregion

        #region FolderBROWSER

        public static string FolderBrowser(string label, string path, Action<string> onPathChanged = null, params GUILayoutOption[] options)
            => FolderBrowser(new GUIContent(label), path, onPathChanged, options);
        
        public static string FolderBrowser(GUIContent label, string path, Action<string> onPathChanged = null, params GUILayoutOption[] options)
        {
            Rect position = EditorGUILayout.GetControlRect(label != null, EditorGUIUtility.singleLineHeight, EditorStyles.popup, options);
            position = EditorGUI.PrefixLabel(position, new GUIContent(label), PhantomGUIStyle.BoldLabel);
            position.width -= 60f;
            EditorGUI.SelectableLabel(position, path, PhantomGUIStyle.Label);
            position.x += position.width;
            position.width = 60f;
            if (GUI.Button(position, "Browser", PhantomGUIStyle.Button))
            {
                if (string.IsNullOrEmpty(path))
                {
                    path = Application.dataPath;
                }
                
                var rootPath = string.IsNullOrEmpty(path) ? Application.dataPath : path;
                var folderPath = EditorUtility.OpenFolderPanel("Select Folder", rootPath, "");
                if (!string.IsNullOrEmpty(folderPath))
                {
                    var targetPath = Application.dataPath.Substring(0, Application.dataPath.Length - "Assets".Length);
                    if (folderPath.StartsWith(targetPath))
                    {
                        path = folderPath.Substring(targetPath.Length);
                        onPathChanged?.Invoke(path);
                    }
                }
            }

            return path;
        }

        #endregion
    }
}