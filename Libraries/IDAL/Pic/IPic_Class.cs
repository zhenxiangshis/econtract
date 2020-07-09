using System;
using System.Collections.Generic;
using System.Text;
using Model.Pic;
using System.Collections;
using System.Data;

namespace IDAL.Pic
{
    public interface IPic_Class
    {
        // Methods
        int CreatePicClass(Pic_Class model);
        int DeletePicClass(int ClassID);
        bool Exists(int ClassID);
        DataSet GetList(int PageSize, int PageIndex, string strWhere);
        int GetMaxId();
        DataSet GetPicClassList(string strWhere);
        Pic_Class GetPicClassModel(int ClassID);
        void UpdatePicClass(Pic_Class model);
    }
}
