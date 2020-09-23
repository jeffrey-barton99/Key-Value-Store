using Key_Value_Store;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Key_Value_Store
{
    struct KeyValue
    {
        public readonly string Key;
        public readonly object Value;

        public KeyValue(string key, object value)
        {
            Key = key;
            Value = value;
        }   
    }

    class MyDictionary
    {
        int storedValues = 0;

        KeyValue[] kvs = new KeyValue[5];
        
       public object this[string key]
        {
            get => GetValueAtKey(key);
            set => AddOrReplaceKeyValue(new KeyValue(key, value));
        }
        
        public object GetValueAtKey(string key)
        {
            for (int i = 0; i < storedValues; i++)
            {
                if (key == kvs[i].Key)
                {
                    return kvs[i].Value;
                }
            }

            throw new KeyNotFoundException();
        }

        public void AddOrReplaceKeyValue(KeyValue newKeyValue)
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
