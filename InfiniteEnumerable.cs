using System;
using System.Collections.Generic;
using System.Linq;
using Ed.Extensions.Enumerable;
using static Ed.Extensions.Enumerable.EnumerableExtensions;

namespace Ed.Utilities.Enumerable{
    public static class InfiniteEnumerable{

        public static IEnumerable<T> Inifinite<T>(Func<T> next) {while(true) yield return next()  ;}


        public static IEnumerable<T> Inifinite<T> (Func<T> next, Func<bool> stopCondition){
            while(!stopCondition()) yield return next();
        }

        public static IEnumerable<T> Inifinite<T> (Func<T> next, Func<T,bool> stopCondition,bool includeLast){
            var current = next();
            while(!stopCondition(current)){ 
                yield return current;
                current = next();
            }
            if(includeLast)
                yield return current;
        }
      
        public static IEnumerable<T> Inifinite<T>(T first, Func<T,T> next, bool includeFirst)
            => (includeFirst?first.Yield():Empty<T>()).Concat(Inifinite(()=> first = next(first) ));       
        
        public static IEnumerable<T> Inifinite<T>(T first, Func<T,T> next, bool includeFirst, Func<bool> stopCondition)
            => (includeFirst?first.Yield():Empty<T>()).Concat(Inifinite(()=> first = next(first),stopCondition ));        
        public static IEnumerable<T> Inifinite<T>(T first, Func<T,T> next, bool includeFirst, Func<T,bool> stopCondition, bool includeLast)
            => (includeFirst?first.Yield():Empty<T>()).Concat(Inifinite(()=> first = next(first), stopCondition ,includeLast ));  
    }
}

