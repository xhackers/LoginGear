using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginGear.Model;

namespace LoginGear
{
    public interface ILogin
    {
        void Show<T>( SocialInfo socialInfo);
    }
}
