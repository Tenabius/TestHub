using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHub.ApplicationCore.Entities;

namespace TestHub.ApplicationCore.Interfaces
{
    public interface IRepository
    {
        Test GetById(int id);
    }
}
