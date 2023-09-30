namespace StateManagementObserverPattern.StateStores.CounterStore {
    public class CounterStore {
        private CounterState _state;

        public CounterStore()
        {
            _state = new CounterState(0);
         //  initialize _state, or will occur nullreference error. 
        }
        public CounterState GetState()
        {
            return _state;
        }
        public void IncrementCount() {
            var count=_state.Count;
            count++;
            _state=new CounterState(count);
            BroadcastStateChange();
        }

        public void DecrementCount() {
            var count = _state.Count;
            count--;
            _state = new CounterState(count);
            BroadcastStateChange();
        }
        ///////////////////////////////////////////Observer pattern
        /// <summary>
        /// 
        /// </summary>
        /// 
        #region observer pattern
        private Action? _listeners;   //This is Listener, kind like a event handler, no need parameters.
        public void AddStateChangeListeners(Action listener) {
            _listeners += listener;
            //register the Listener, which is _listeners
        }
        public void RemoveStateChangeListeners(Action listener) {
            _listeners -= listener;
            //unregister the Listener, which is _listeners
        }
        public void BroadcastStateChange() {
            _listeners.Invoke();
            //Broadcast changes
        }
        #endregion
    }
}
