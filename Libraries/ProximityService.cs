using Grpc.Core;
using geohash_proximity;
using Geohash;
using System;
using System.Collections;

namespace geohash_proximity.Libraries;

public static class Trie
{
    public static TrieNode Root;

    public static void initRoot()
    {
        Root=new TrieNode();
    }

    public static IEnumerable<string> GetNodesByPrefix(string prefix)
    { 
        return Root.GetNodesByPrefix(prefix);
    }
}

public class TrieNode{
    bool ValuePresent;
    Dictionary<char,TrieNode> Children=new Dictionary<char, TrieNode>();    

    public IEnumerable<string> GetNodesByPrefix(string prefix)
    {
        if(prefix.Length==0)
        {
            foreach(var c in Children)
            {
                if(c.Value.ValuePresent)
                {
                    yield return c.Key.ToString();
                }
                foreach(var s in c.Value.GetNodesByPrefix(""))
                {
                    yield return c.Key+s;
                }
            }
        }
        else{
            char key=prefix[0];
            if(!Children.ContainsKey(key))
                yield break;
            var child=Children[key];
            
            if(child.ValuePresent)
                yield return key.ToString();
            
            var newPrefix=prefix.Substring(1);
            foreach(var s in child.GetNodesByPrefix(newPrefix))
            {
                yield return key+s;
            }
        }
    }
}
