using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace TinyMapEngine
{
    public class OrderedDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _dict;
        private List<TKey> _list;

        public TValue this[TKey key]
        {
            get { return _dict[key]; }
            set
            {
                if (!_dict.ContainsKey(key))
                    Add(key, value);
                else
                    _dict[key] = value;
            }
        }

        public TValue this[int index]
        {
            get { return _dict[_list[index]]; }
            set { _dict[_list[index]] = value; }
        }

        public OrderedDictionary()
        {
            _dict = new Dictionary<TKey, TValue>();
            _list = new List<TKey>();
        }

        public void Add(TKey key, TValue value)
        {
            _dict.Add(key, value);
            _list.Add(key);
        }

        public void RemoveKey(TKey key)
        {
            _dict.Remove(key);
            _list.Remove(key);
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        public int Count => _dict.Count;

        public bool ContainsKey(TKey key)
        {
            return _list.Contains(key);
        }

        public void Clear()
        {
            _dict.Clear();
            _list.Clear();
        }

        public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IDictionaryEnumerator
        {
            private OrderedDictionary<TKey, TValue> dictionary;
            private int index;
            private KeyValuePair<TKey, TValue> current;

            internal Enumerator(OrderedDictionary<TKey, TValue> dictionary)
            {
                this.dictionary = dictionary;
                index = -1;
                current = new KeyValuePair<TKey, TValue>();
            }

            public bool MoveNext()
            {
                if (++index < dictionary.Count)
                {
                    current = new KeyValuePair<TKey, TValue>(dictionary._list[index], dictionary[index]);
                    return true;
                }
                index = dictionary.Count + 1;
                current = new KeyValuePair<TKey, TValue>();
                return false;
            }

            public KeyValuePair<TKey, TValue> Current
            {
                get { return current; }
            }

            public void Dispose()
            {
            }

            object IEnumerator.Current
            {
                get
                {
                    return new KeyValuePair<TKey, TValue>(current.Key, current.Value);
                }
            }

            void IEnumerator.Reset()
            {
                index = -1;
                current = new KeyValuePair<TKey, TValue>();
            }

            DictionaryEntry IDictionaryEnumerator.Entry
            {
                get
                {
                    return new DictionaryEntry(current.Key, current.Value);
                }
            }

            object IDictionaryEnumerator.Key
            {
                get
                {
                    return current.Key;
                }
            }

            object IDictionaryEnumerator.Value
            {
                get
                {
                    return current.Value;
                }
            }
        }
    }
}