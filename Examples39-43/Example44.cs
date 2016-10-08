using System;
using System.Collections.Generic;

namespace Events
{
    public class ScarceFventSource
    {
        //Jeden słownik współuzytkowany przez wszystkie instancje tej klasy,
        //który śledzi wszystkie procedury obsługi wszystkich zdarzeń
        private static readonly Dictionary<Tuple<ScarceFventSource, object>, EventHandler> _eventHandlers = new Dictionary<Tuple<ScarceFventSource, object>, EventHandler>();
 
        //Obiekty używane jako klucze do identyfikacji konkretnych zdarzeń w słowniku
        private static readonly object EventOneId = new object();
        private static readonly object EventTwoId = new object();

        public event EventHandler EventOne
        {
            add { AddEvent(EventOneId, value); }
            remove { RemoveEvent(EventOneId, value); }
        }

        public event EventHandler EventTwo
        {
            add { AddEvent(EventTwoId, value); }
            remove { RemoveEvent(EventTwoId, value); }
        }

        public void RaiseBoth()
        {
            RaiseEvent(EventOneId, EventArgs.Empty);
            RaiseEvent(EventTwoId, EventArgs.Empty);
        }

        private Tuple<ScarceFventSource, object> MakeKey(object eventId)
        {
            return Tuple.Create(this, eventId);
        }

        private void AddEvent(object eventId, EventHandler handler)
        {
            var key = MakeKey(eventId);
            EventHandler entry;
            _eventHandlers.TryGetValue(key, out entry);
            entry += handler;
            _eventHandlers[key] = entry;
        }

        private void RemoveEvent(object eventId, EventHandler handler)
        {
            var key = MakeKey(eventId);
            EventHandler entry = _eventHandlers[key];
            entry -= handler;
            if (entry == null)
            {
                _eventHandlers.Remove(key);
            }
            else
            {
                _eventHandlers[key] = entry;
            }
        }

        private void RaiseEvent(object eventId, EventArgs e)
        {
            var key = MakeKey(eventId);
            EventHandler handler;
            if (_eventHandlers.TryGetValue(key, out handler))
            {
                handler(this, e);
            }
        }
    }
}
