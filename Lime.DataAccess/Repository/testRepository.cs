using Lime.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lime.DataAccess.Repository
{
    class testRepository:IRepository
    {
        public  object GetData()
        {
            return "привет";
        }
    }
}
