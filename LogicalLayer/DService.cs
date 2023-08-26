using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalLayer
{
    public interface DService <T>
    {
        public IEnumerable<T> GetAllDepartment();
        public IEnumerable GetDeptIdRequest(string DeptId);
        public IEnumerable GetDeptNameRequest();
        public IEnumerable GetCourseNameRequest();

    }
}
