using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PhantomEngine.UI
{
    public class PhantomUI : MonoBehaviour
    {
        
        #region PROPERTY

        private static Dictionary<IUICallback, PhantomUIConfig> _container;
    
        private static bool IsContainer => _container is { Count: > 0 };
    
        #endregion



        #region FUNCTION

        public static bool Add(object callback) => Add(callback, null);
        
        public static bool Add(object callback, PhantomUIConfig config)
        {
            if (callback is not IUICallback target)
                return false;

            _container ??= new Dictionary<IUICallback, PhantomUIConfig>();
            config ??= new PhantomUIConfig();
            config.uid = GeneratorUid(config.uid);

            return _container.TryAdd(target, config);
        }

        public static bool Remove(object callback)
        {
            if (callback is not IUICallback target)
                return false;

            if (!IsContainer || !_container.ContainsKey(target))
                return false;

            return _container.Remove(target);
        }

        public static bool Remove(string code)
        {
            if (!IsContainer)
                return false;

            foreach (var target in _container)
            {
                if (target.Value.uid != code) 
                    continue;
                
                _container.Remove(target.Key);
                return true;
            }

            return false;
        }
        
        public static void Clear(bool initialize = false)
        {
            if (!IsContainer)
                return;
            
            foreach (var target in _container)
            {
                _container.Remove(target.Key);
            }
            
            if (initialize)
                _container = null;
        }

        public static IUICallback Find(string uid)
        {
            return !IsContainer ? null : _container.FirstOrDefault(x => x.Value.uid == uid).Key;
        }

        public static bool Exist(object callback)
        {
            if (callback is not IUICallback target)
                return false;
        
            return IsContainer && _container.ContainsKey(target);
        }

        #endregion



        #region EVENT

        public static void AllEvent(PhantomUIRequest request)
        {
            if (!IsContainer)
                return;

            foreach (var target in _container)
            {
                target.Key.OnEventCallback(request);
            }
        }

        public static void TypeEvent(PhantomUIType type, PhantomUIRequest request)
        {
            if (!IsContainer)
                return;

            if (type == PhantomUIType.None)
            {
                AllEvent(request);
                return;
            }
            
            foreach (var target in _container)
            {
                if(target.Value.type != type)
                    continue;
                
                target.Key.OnEventCallback(request);
            }
        }
        
        public static void TargetEvent(string uid, PhantomUIRequest request)
        {
            if (!IsContainer)
                return;
            
            foreach (var target in _container)
            {
                if (target.Value.uid != uid) 
                    continue;
                
                target.Key.OnEventCallback(request);
                break;
            }
        }
        
        #endregion

        

        #region UTILITY

        private static string GeneratorUid(string uid)
        {
            if (Find(uid) is not null)
                uid = string.Empty;
            
            return string.IsNullOrEmpty(uid) || uid == "0" ? Guid.NewGuid().ToString() : uid;
        }

        #endregion
        
    }

}

