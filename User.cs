
using System;
using System.Security.AccessControl;

namespace Refactored
{
    class User
    {
        private string name;
        private int secretDigits;
        private bool isActive;
        private bool isNumberGuessed;

        //This will prevent the name to be changed after initialization by the constructor
        public string Name
        {
            get { return this.name; } 
        }
        
        public int SecretDigits 
        {
            get { return this.secretDigits; } 
        }

        public bool IsActive 
        {
            get { return this.isActive; }
            set { this.isActive = value; }
        }

        public bool IsGuessed
        {
            get { return this.isNumberGuessed; }
            set { this.isNumberGuessed = value; }
        }
        
        public User(string name, int secretDigits)
        {
            this.name = name;
            this.secretDigits = secretDigits;
        }

    }    
}

