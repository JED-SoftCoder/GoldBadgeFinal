using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInsuranceChallenge
{
    public class DataRepo
    {
        private List<Data> _listOfData = new List<Data>();

        public void AddDataToList(Data data)
        {
            _listOfData.Add(data);
        }

        public List<Data> GetDataList()
        {
            return _listOfData;
        }

        public bool UpdateExistingData(int policyNumber, Data newData)
        {
            Data oldData = GetDataByPolicyNumber(policyNumber);
            if(oldData != null)
            {
                oldData.PolicyNumber = newData.PolicyNumber;
                oldData.AverageSpeeding = newData.AverageSpeeding;
                oldData.LaneSwerve = newData.LaneSwerve;
                oldData.StopSigns = newData.StopSigns;
                oldData.CloseFollow = newData.CloseFollow;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteDataFromList(int policyNumber)
        {
            Data data = GetDataByPolicyNumber(policyNumber);
            if(data == null)
            {
                return false;
            }
            int initialCount = _listOfData.Count;
            _listOfData.Remove(data);
            if(initialCount > _listOfData.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public Data GetDataByPolicyNumber(int policyNumber)
        {
            foreach(Data data in _listOfData)
            {
                if(data.PolicyNumber == policyNumber)
                {
                    return data;
                }
            }
            return null;
        }
    }
}
