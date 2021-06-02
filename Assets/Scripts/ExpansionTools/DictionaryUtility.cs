using System.Collections;
using System.Collections.Generic;

/// <summary>
/// The static expansion tool class for Dictionary<TKey,Tvalue>;
/// </summary>
public static class DictionaryUtility
{
    public static Tvalue TryGet<Tkey,Tvalue>(this Dictionary<Tkey,Tvalue> dict, Tkey key)
    {
        /// <summary>
        /// Search the value by specific key.
        /// </summary>
        /// <typeparam name="Tkey"></typeparam>
        /// <typeparam name="Tvalue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        Tvalue value;
        dict.TryGetValue(key, out value);
        return value;
    }
}
