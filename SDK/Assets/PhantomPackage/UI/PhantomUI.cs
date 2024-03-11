using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PhantomEngine.UI
{
    public class PhantomUI : MonoBehaviour
    {
        
        #region PROPERTY

        private static Dictionary<IUISubject, PhantomUIConfig> container;
    
        private static bool IsContainer => container is { Count: > 0 };
    
        #endregion



        #region FUNCTION

        public static bool Add(object callback) => Add(callback, null);
        
        public static bool Add(object callback, PhantomUIConfig config)
        {
            if (callback is not IUISubject target)
                return false;

            container ??= new Dictionary<IUISubject, PhantomUIConfig>();
            config ??= new PhantomUIConfig();
            config.uid = GeneratorUid(config.uid);

            return container.TryAdd(target, config);
        }

        public static bool Remove(object callback)
        {
            if (callback is not IUISubject target)
                return false;

            if (!IsContainer || !container.ContainsKey(target))
                return false;

            return container.Remove(target);
        }

        public static bool Remove(string code)
        {
            if (!IsContainer)
                return false;

            foreach (var target in container)
            {
                if (target.Value.uid != code) 
                    continue;
                
                container.Remove(target.Key);
                return true;
            }

            return false;
        }
        
        public static void Clear(bool initialize = false)
        {
            if (!IsContainer)
                return;
            
            foreach (var target in container)
            {
                container.Remove(target.Key);
            }
            
            if (initialize)
                container = null;
        }

        public static IUISubject Find(string uid)
        {
            return !IsContainer ? null : container.FirstOrDefault(x => x.Value.uid == uid).Key;
        }

        public static bool Exist(object callback)
        {
            if (callback is not IUISubject target)
                return false;
        
            return IsContainer && container.ContainsKey(target);
        }

        #endregion



        #region EVENT

        public static void Event(PhantomUIRequest request)
        {
            if (!IsContainer)
                return;

            foreach (var target in container)
            {
                target.Key.OnObserver(request);
            }
        }

        public static void TypeEvent(string type, PhantomUIRequest request)
        {
            if (!IsContainer)
                return;

            if (string.IsNullOrEmpty(type))
            {
                Event(request);
                return;
            }
            
            foreach (var target in container)
            {
                if(target.Value.type != type)
                    continue;
                
                target.Key.OnObserver(request);
            }
        }
        
        public static void TargetEvent(string uid, PhantomUIRequest request)
        {
            if (!IsContainer)
                return;
            
            foreach (var target in container)
            {
                if (target.Value.uid != uid) 
                    continue;
                
                target.Key.OnObserver(request);
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

