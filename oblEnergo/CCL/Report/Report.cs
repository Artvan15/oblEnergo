using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Report
{
    abstract class Report
    {
        public void Generate()
        {
            GetInfo();
            Create();
            Send();
        }
        protected abstract void GetInfo();
        protected abstract void Create();
        protected abstract void Send();
    }

    class UserReport : Report
    {
        protected override void GetInfo()
        {

        }
        protected override void Create()
        {

        }
        protected override void Send()
        {
            
        }
    }

    class SpecialistReport : Report
    {
        protected override void GetInfo()
        {

        }
        protected override void Create()
        {

        }
        protected override void Send()
        {

        }
    }

}
