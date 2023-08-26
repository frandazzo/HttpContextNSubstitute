using System;
using System.Collections;
using System.Collections.Generic;
using HttpContextMoq.Generic;
using Microsoft.AspNetCore.Http.Features;
using NSubstitute;

namespace HttpContextMoq
{
    public class FeatureCollectionMock : IFeatureCollection, IContextMock<IFeatureCollection>
    {
        public FeatureCollectionMock()
        {
            this.Mock = Substitute.For<IFeatureCollection>();
        }

        public IFeatureCollection Mock { get; }

        public object this[Type key]
        {
            get => this.Mock[key];
            set => this.Mock[key] = value;
        }

        public bool IsReadOnly => this.Mock.IsReadOnly;

        public int Revision => this.Mock.Revision;

        public TFeature Get<TFeature>() => this.Mock.Get<TFeature>();

        public IEnumerator<KeyValuePair<Type, object>> GetEnumerator() => this.Mock.GetEnumerator();

        public void Set<TFeature>(TFeature instance) => this.Mock.Get<TFeature>().Returns(instance);

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this.Mock).GetEnumerator();
    }
}