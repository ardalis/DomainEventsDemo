using System;
using System.Collections.Generic;
using StructureMap;

namespace DomainEventsDemo.SharedKernel.StaticApproach
{
    public static class DomainEvents
    {
        [ThreadStatic]
        private static List<Delegate> actions;

        public static IContainer Container { get; set; }
        public static void Register<T>(Action<T> callback) where T : DomainEvent
        {
            if (actions == null)
            {
                actions = new List<Delegate>();
            }
            actions.Add(callback);
        }

        public static void ClearCallbacks()
        {
            actions = null;
        }

        public static void Raise<T>(T args) where T : DomainEvent
        {
            if (Container == null)
            {
                throw new Exception("Set Container to the application IContainer.");
            }
            foreach (var handler in Container.GetAllInstances<IHandle<T>>())
            {
                handler.Handle(args);
            }

            if (actions != null)
            {
                foreach (var action in actions)
                {
                    if (action is Action<T>)
                    {
                        ((Action<T>)action)(args);
                    }
                }
            }
        }
    }
}