using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_06_2_BeehiveManagement
{
    class Worker
    {
        //========= Fields ========//
        
        private string[] _jobsICanDo;
        private int _shiftsToWork;
        private int _shiftsWorked;

        //========= Constructors ========//

        public Worker(string[] jobsICanDo)
        {
            _jobsICanDo = jobsICanDo;
        }

        //========= Properties ========//

        public string CurrentJob { get; private set; }

        public int ShiftsLeft { get { return _shiftsToWork; } }

        //========= Methods =======//

        public bool DoThisJob(string job, int numberOfShifts)
        {
            if (!String.IsNullOrEmpty(CurrentJob))
                return false;
            for (int i = 0; i < _jobsICanDo.Length; i++ )
            {
                if(_jobsICanDo[i] == job)
                {
                    CurrentJob = job;
                    _shiftsToWork = numberOfShifts;
                    _shiftsWorked = 0;
                    return true;
                }
            }
            return false;
        }

        public bool DidYouFinish()
        {
            if (String.IsNullOrEmpty(CurrentJob))
                return false;
            _shiftsWorked++;
            if(_shiftsWorked > _shiftsToWork)
            {
                _shiftsWorked = 0;
                _shiftsToWork = 0;
                CurrentJob = "";
                return true;
            }
            else
                return false;
        }
    }
}
