using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_UI.Storage
{
    public class ValidationData: ObservableObject
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Username cannot be empty.");

                OnPropertyChanged(ref _username, value);
            }
        }
    }
}
