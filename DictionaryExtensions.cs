using System;
using System.Collections.Generic;
using System.Linq;

namespace Ed.Extensions.Dictionary{
        public static class DictionaryExtensions {
        public static Dictionary<TKey,TValue> Merge<TKey,TValue>(this Dictionary<TKey,TValue> first , Dictionary<TKey,TValue> second,bool overRide ){
            foreach(var kvp in second){
                if(overRide || !first.ContainsKey(kvp.Key))
                    first[kvp.Key] = kvp.Value;
            }
            return first;
        }

          
        public static T LookupOrDefault<TKey,T> (this Dictionary<TKey,T> dictionary,TKey key, Func<T> defaultValue ){
            T result;
            if(!dictionary.TryGetValue(key,out result)){
                result = defaultValue();
            }
            return result;
        }
        public static T LookupOrDefault<TKey,T> (this Dictionary<TKey,T> dictionary,TKey key ) where T: class {
            T result;
            if(!dictionary.TryGetValue(key,out result)){
                result = Activator.CreateInstance(typeof(T)) as T;
            }
            return result;
        }
        
    }

}