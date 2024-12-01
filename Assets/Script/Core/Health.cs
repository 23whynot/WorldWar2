using System;


namespace Script.Core
{
    public class Health
    {
        private int _count = 3;
   
        public event Action OnHealthChanged;
        public event Action OnDeath;

        public int GetCount()
        {
            return _count;
        }
   
        public void Decrease()
        {
            _count--;
            OnHealthChanged?.Invoke();
            if (_count == 0)
            {
                OnDeath?.Invoke();
            }
        }
    }
}
