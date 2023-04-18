using System;
namespace DesignPatterns.Singleton
{
    public sealed class GlobalStateManager
    {
        private static readonly GlobalStateManager _instance = new GlobalStateManager();
        private int balance;
        private bool isTutorialComplete;

        // Constructor should be private to prevent instantiation
        private GlobalStateManager()
        {
            balance = 0;
            isTutorialComplete = false;
        }

        // Get the single instance of the class
        public static GlobalStateManager instance
        {
            get { return _instance; }
        }

        // Getter and setter for the global state
        public int GlobalState
        {
            get { return balance; }
            set { balance = value; }
        }
    }
}

