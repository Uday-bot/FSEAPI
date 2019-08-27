using FSEFinalTaskDataAccess;
using FSEFinalTaskDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSEFinalTaskBusiness
{
    public class MyDataTask
    {
        private readonly MyDataRepository _myDataRepository;
        public MyDataTask(MyDataRepository  myDataRepository)
        {
            _myDataRepository = myDataRepository;
        }


        public bool CreateMyData(MyDataModel  myDataModel)
        {
            bool isSave = true;
            try
            {
                _myDataRepository.CreateMyData(myDataModel.ToEntity());
            }
            catch (Exception ex)
            {
                isSave = false;
            }

            return isSave;
        }

        public bool UpdateMyData(MyDataModel myDataModel)
        {
            bool isSave = true;
            try
            {
                _myDataRepository.UpdateMyData(myDataModel.ToEntity());
            }
            catch (Exception ex)
            {
                isSave = false;
            }

            return isSave;
        }

        public bool DeleteMyData(int applicationCode)
        {
            bool isSave = true;
            try
            {
                _myDataRepository.DeleteMyData(applicationCode);
            }
            catch (Exception ex)
            {
                isSave = false;
            }

            return isSave;
        }

        public List<MyDataModel> GetMyData()
        {
            List<FSEFinalTaskDataAccess.Entity.MyDataEntity> myDataEntities = new List<FSEFinalTaskDataAccess.Entity.MyDataEntity>();
            try
            {
                myDataEntities =  _myDataRepository.Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return myDataEntities.ToDtoList();

        }


    }
}
