using System;
using System.Collections.Generic;
using System.Linq;

namespace Ed.Extensions.Enumerable
{
    public static class EnumerableExtensions {
        public static Dictionary<T,int> ToIndexDictionary<T>(this  IEnumerable<T> enumerable ){
            Dictionary<T,int> result = new Dictionary<T, int>();
            int i = 0;
            foreach(T t in enumerable){
                if(!result.ContainsKey(t)) result.Add(t,i);
                i++;
            }
            return result;
        }
        public static IEnumerable<T> Yield<T>(this T item) { yield return item; }
        public static IEnumerable<T> Empty<T>(){ yield break; }
        public static IEnumerable<T> CreateEnumerable<T>(int size) where T: new() 
            => CreateEnumerable(size, ()=> new T());

        public static IEnumerable<T> CreateEnumerable<T> (int size, Func<T> objectCreator ){
            for(int i=0;i< size;++i) 
                yield return objectCreator();
        }
        public static Dictionary<TKey,List<T>> CreateDictionaryList<TKey,T>(this IEnumerable<T> list,Func<T,TKey> keySelector  )
            => list.GroupBy(keySelector).ToDictionary(kvp=> kvp.Key, grp=> grp.ToList() );

           
    }
}
