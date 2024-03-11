#if UNITY_EDITOR

using System.Collections.Generic;
using UnityEngine;

namespace PhantomEditor
{
    public class PhantomEditorSetting : ScriptableObject
    {

        #region VARIABLE

        private List<PhantomProfileTable> _profiles;
        private int _profileIndex = -1;
        
        #endregion



        #region PROPERTY

        // ==================================================
        // [ Count ]
        // ==================================================
        public int GetCount() => _profiles?.Count ?? 0;
        
        
        // ==================================================
        // [ Index ]
        // ==================================================
        public int GetIndex() => _profileIndex;

        public void SetIndex(int index)
        {
            _profileIndex = index;
        }
        
        
        // ==================================================
        // [ Label ]
        // ==================================================
        public string GetLabel(int index)
        {
            if (_profiles is null || _profiles.Count == 0 || _profiles.Count - 1 < index)
                return string.Empty;
            
            return _profiles[index].label;
        }
        
        
        #endregion



        #region FUNCTION

        public void Default()
        {
            _profiles ??= new List<PhantomProfileTable>()
            {
                new()
                {
                    label = "Default profile",
                    type = PhantomProfileType.Local,
                    url = ""
                }
            };
        }

        #endregion
        
    }
}

#endif