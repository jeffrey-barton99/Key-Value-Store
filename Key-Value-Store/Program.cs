using Key_Value_Store;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Key_Value_Store
{
    struct LinkedList
    {
        public readonly string Key;
        public readonly object @int;

        public LinkedList(string key, object value)
        {
            Key = key;
            @int = value;
        }   
    }

    class MyDictionary
    {
        int storedValues = 0;

        LinkedList[] kvs = new LinkedList[5];
        
       public object this[string key]
        {
            get => GetValueAtKey(key);
            set => AddOrReplaceKeyValue(new LinkedList(key, value));
        }
        
        public object GetValueAtKey(string key)
        {
            for (int i = 0; i < storedValues; i++)
            {
                if (key == kvs[i].Key)
                {
                    return kvs[i].@int;
                }
            }

            throw new KeyNotFoundException();
        }

        public void AddOrReplaceKeyValue(LinkedList newKeyValue)
        {
            bool foundMatchingKey = false;

            for (int i = 0; i < storedValues; i++)
            {
                if (newKeyValue.Key == kvs[i].Key)
                {
                    foundMatchingKey = true;
                    kvs[i] = newKeyValue;
                }
            }

            if (!foundMatchingKey)
            {
                kvs[storedValues++] = newKeyValue;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            var d = new MyDictionary();
            try
            {
                Console.WriteLine(d["Cats"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            d["Cats"] = 42;
            d["Dogs"] = 17;
            Console.WriteLine($"{(int)d["Cats"]}, {(int)d["Dogs"]}");
        }
    }
        
    
}
