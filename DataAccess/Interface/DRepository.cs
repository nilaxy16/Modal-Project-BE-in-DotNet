using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface DRepository <T>
    {
        public IEnumerable <T> GetAllDept();

        public IEnumerable GetByDeptId(string Id);

        public IEnumerable GetByDeptName();
        public IEnumerable GetByCourseName(); 
    }
}
