using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public sealed class PhantomExportTool : PhantomGUITool
    {
        public override string DrawName => PhantomExportConfig.ToolName;
        public override Vector2 DrawSize => new(PhantomExportConfig.ToolWidth, PhantomExportConfig.ToolHeight);
        
        
        private Vector2 _drawScrollPosition;
        private Rect _drawScrollSelected;
        private List<string> _drawScrollContents;
        
        private readonly string _drawPackageHeader = "Package";
        private string _drawPackageName;
        private string _drawPackageNote;
        
        private readonly string _drawVersionHeader = "Version";
        private readonly VersionData _drawVersionData = new();
        
        private readonly string _drawCalendarHeader = "Calendar";
        private readonly CalendarData _drawCalendarData = new();
        
        private readonly string _drawBrowserHeader = "Path";
        private readonly string _drawBrowserRootKey = "phantom_export_path_root";
        private string _drawBrowserRoot = "";
        private readonly string _drawBrowserPackageKey = "phantom_export_path_package";
        private string _drawBrowserPackage;
        
        
        protected override void DrawOpen()
        {
            if (!string.IsNullOrEmpty(EditorPrefs.GetString(_drawBrowserRootKey)))
            {
                _drawBrowserRoot = EditorPrefs.GetString(_drawBrowserRootKey);
                OnChangedRoot(_drawBrowserRoot);
            }

            if (!string.IsNullOrEmpty(EditorPrefs.GetString(_drawBrowserPackageKey)))
            {
                _drawBrowserPackage = EditorPrefs.GetString(_drawBrowserPackageKey);    
            }
        }
        
        protected override void DrawClose()
        {
            EditorPrefs.SetString(_drawBrowserRootKey, _drawBrowserRoot);
            EditorPrefs.SetString(_drawBrowserPackageKey, _drawBrowserPackage);
        }

        //var folderContent = EditorGUIUtility.IconContent("Folder Icon");
        
        protected override void DrawGUI()
        {
            PhantomGUI.BeginHorizontal();
            {
                PhantomGUI.BeginVertical(GUILayout.Width(200f));
                {
                    PhantomGUI.Prefix(20f);
                    _drawScrollPosition = PhantomGUI.BeginScroll(ScrollType.Vertical, _drawScrollPosition);
                    {
                        if (_drawScrollContents is { Count: > 0 })
                        {
                            if (_drawScrollSelected != Rect.zero)
                            {
                                PhantomGUI.DrawSolidRect(_drawScrollSelected, PhantomGUIColor.SelectedColor);
                            }
                            
                            var folderContent = EditorGUIUtility.IconContent("Folder On Icon");
                            EditorGUILayout.PrefixLabel(folderContent);
                            
                            foreach (var folder in _drawScrollContents)
                            {
                                var folderLast = folder.LastIndexOf('/');
                                var folderName = folder.Substring(folderLast + 1);
                                PhantomGUIProperty.DisplayLabel(folderContent, folderName);
                                
                                var folderRect = GUILayoutUtility.GetLastRect();
                                var folderEvent = Event.current;
                                if (folderEvent.type == EventType.MouseDown && folderRect.Contains(folderEvent.mousePosition))
                                {
                                    if (folderEvent.clickCount != 1)
                                        continue;

                                    _drawScrollSelected = _drawScrollSelected == folderRect ? Rect.zero : folderRect;
                                    _drawPackageName = folderName;
                                }
                            }   
                        }
                    }
                    PhantomGUI.EndScroll();
                }
                PhantomGUI.EndVertical();
                PhantomGUI.BeginVertical();
                {
                    PhantomGUI.Prefix(80f);
                    PhantomGUI.BeginGroup(_drawPackageHeader);
                    {
                        _drawPackageName = PhantomGUIProperty.LabelText("Name", _drawPackageName);
                        _drawPackageNote = PhantomGUIProperty.MultilineText("Note", _drawPackageNote, 5);
                    }
                    PhantomGUI.EndGroup();
                    PhantomGUI.BeginGroup(_drawVersionHeader);
                    {
                        _drawVersionData.Major = PhantomGUIProperty.LabelText("Major", _drawVersionData.Major);
                        _drawVersionData.Minor = PhantomGUIProperty.LabelText("Minor", _drawVersionData.Minor);
                        _drawVersionData.Patch = PhantomGUIProperty.LabelText("Patch", _drawVersionData.Patch);
                        _drawVersionData.Build = PhantomGUIProperty.LabelText("Build", _drawVersionData.Build);
                    }
                    PhantomGUI.EndGroup();
                    PhantomGUI.BeginGroup(_drawCalendarHeader);
                    {
                        _drawCalendarData.Year = PhantomGUIProperty.LabelPopup("Year", _drawCalendarData.Year, _drawCalendarData.GetYears());
                        _drawCalendarData.Month = PhantomGUIProperty.LabelPopup("Month", _drawCalendarData.Month, _drawCalendarData.GetMonths());
                        _drawCalendarData.Day = PhantomGUIProperty.LabelPopup("Day", _drawCalendarData.Day, _drawCalendarData.GetDays());
                    }
                    PhantomGUI.EndGroup();
                    PhantomGUI.BeginGroup(_drawBrowserHeader);
                    {
                        _drawBrowserRoot = PhantomGUIProperty.FolderBrowser("Root", _drawBrowserRoot, OnChangedRoot);
                        _drawBrowserPackage = PhantomGUIProperty.FolderBrowser("Package", _drawBrowserPackage);
                    }
                    PhantomGUI.EndGroup();
                    
                    PhantomGUIProperty.ControlButton("Export", SizeType.Venti);
                }
                PhantomGUI.EndVertical();    
            }
            PhantomGUI.EndHorizontal();
        }

        private void OnChangedRoot(string path)
        {
            _drawScrollSelected = Rect.zero;
            _drawScrollContents ??= new List<string>();
            _drawScrollContents.Clear();
            
            var folders = AssetDatabase.GetSubFolders(path);
            if (folders is { Length: > 0 })
            {
                foreach (var folder in folders)
                {
                    _drawScrollContents.Add(folder);
                }
            }
        }
    }
}