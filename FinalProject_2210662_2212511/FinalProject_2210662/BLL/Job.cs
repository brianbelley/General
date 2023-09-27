using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject_2210662.DAL;

namespace FinalProject_2210662.BLL
{
    public class Job
    {
        private int jobId;
        private string jobTitle;

        public int JobId { get { return jobId; } set { jobId= value; } }
        public string JobTitle { get { return jobTitle; } set { jobTitle= value; } }

        public List<Job> GetAllJobs()
        {
            return JobDB.GetAllRecords();
        }

    }
}
