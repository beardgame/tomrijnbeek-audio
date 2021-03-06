﻿using System.Diagnostics.CodeAnalysis;

namespace Bearded.Audio
{
    abstract class AudioService<TService, TImplementation>
        where TImplementation : AudioService<TService, TImplementation>, TService, new()
        where TService : class
    {
        [MaybeNull] private static TService instance;
        public static TService Instance => instance ??= new TImplementation();

        protected readonly AudioContext Context;

        protected AudioService()
        {
            Context = AudioContext.Instance;
        }

        internal static void SetTestInstance(TService testInstance)
        {
            instance = testInstance;
        }
    }
}
