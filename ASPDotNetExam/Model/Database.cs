using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPDotNetExam.DataBase;

namespace ASPDotNetExam.Model
{
    public class Database
    {
        protected userContext userContext { get; set; }

        public void DataBase()
        {
            this.userContext = new userContext();
        }
    }
}
