using NSubstitute;
using System.Collections;
using System.Collections.Generic;

namespace HttpContextNSubstitute
{
    public class ItemsDictionaryMock : IItemsDictionaryMock
    {
        public ItemsDictionaryMock()
        {
            this.Mock = Substitute.For<IDictionary<object, object>>();
        }

        public IDictionary<object, object> Mock { get; }

        object IDictionary<object, object>.this[object key]
        {
            get => this.Mock[key];
            set => this.Mock[key] = value;
        }

        void IDictionary<object, object>.Add(object key, object value) => this.Mock.Add(key, value);

        bool IDictionary<object, object>.ContainsKey(object key) => this.Mock.ContainsKey(key);

        ICollection<object> IDictionary<object, object>.Keys => this.Mock.Keys;

        bool IDictionary<object, object>.Remove(object key) => this.Mock.Remove(key);

        bool IDictionary<object, object>.TryGetValue(object key, out object value) => this.Mock.TryGetValue(key, out value);

        ICollection<object> IDictionary<object, object>.Values => this.Mock.Values;

        void ICollection<KeyValuePair<object, object>>.Add(KeyValuePair<object, object> item) => this.Mock.Add(item);

        void ICollection<KeyValuePair<object, object>>.Clear() => this.Mock.Clear();

        bool ICollection<KeyValuePair<object, object>>.Contains(KeyValuePair<object, object> item) => this.Mock.Contains(item);

        void ICollection<KeyValuePair<object, object>>.CopyTo(KeyValuePair<object, object>[] array, int arrayIndex) => this.Mock.CopyTo(array, arrayIndex);

        int ICollection<KeyValuePair<object, object>>.Count => this.Mock.Count;

        bool ICollection<KeyValuePair<object, object>>.IsReadOnly => this.Mock.IsReadOnly;

        bool ICollection<KeyValuePair<object, object>>.Remove(KeyValuePair<object, object> item) => ((ICollection<KeyValuePair<object, object>>)this.Mock).Remove(item);

        IEnumerator<KeyValuePair<object, object>> IEnumerable<KeyValuePair<object, object>>.GetEnumerator() => this.Mock.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this.Mock).GetEnumerator();
    }
}
