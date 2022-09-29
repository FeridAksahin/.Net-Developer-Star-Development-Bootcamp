using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignPatternWork
{
    internal class Singleton 
    {
        private Singleton() 
        {

        }

        private static Singleton instance;

        public static Singleton GetInstance()
        {
            if (instance == null) 
            {
                instance = new Singleton(); 
            }
            return instance; 
      
        }

    }
}

