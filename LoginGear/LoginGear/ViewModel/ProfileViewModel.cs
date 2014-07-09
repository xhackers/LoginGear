﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginGear.Model;

namespace LoginGear.ViewModel
{
    public class ProfileViewModel : NotifyRootObject
    {
        private SocialRootObject _socialRootObject;

        public SocialRootObject SocialRootObject
        {
            get { return _socialRootObject; }
            set
            {
                if (Equals(value, _socialRootObject)) return;
                _socialRootObject = value;
                OnPropertyChanged();
            }
        }
    }

    
}
