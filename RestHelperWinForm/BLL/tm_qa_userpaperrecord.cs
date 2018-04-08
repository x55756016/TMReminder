using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL {
	 	//tm_qa_userpaperrecord
		public partial class tm_qa_userpaperrecordBLL
	{
   		     
		private readonly Maticsoft.DAL.tm_qa_userpaperrecord dal=new Maticsoft.DAL.tm_qa_userpaperrecord();
        public tm_qa_userpaperrecordBLL()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string recordid)
		{
			return dal.Exists(recordid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(Maticsoft.Model.tm_qa_userpaperrecord model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.tm_qa_userpaperrecord model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string recordid)
		{
			
			return dal.Delete(recordid);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.tm_qa_userpaperrecord GetModel(string recordid)
		{
			
			return dal.GetModel(recordid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.tm_qa_userpaperrecord GetModelByCache(string recordid)
		{
			
			string CacheKey = "tm_qa_userpaperrecordModel-" + recordid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(recordid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.tm_qa_userpaperrecord)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.tm_qa_userpaperrecord> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.tm_qa_userpaperrecord> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.tm_qa_userpaperrecord> modelList = new List<Maticsoft.Model.tm_qa_userpaperrecord>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.tm_qa_userpaperrecord model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.tm_qa_userpaperrecord();					
																	model.recordid= dt.Rows[n]["recordid"].ToString();
																																model.userid= dt.Rows[n]["userid"].ToString();
																																model.subjectid= dt.Rows[n]["subjectid"].ToString();
																																model.paperid= dt.Rows[n]["paperid"].ToString();
																																model.lastitemid= dt.Rows[n]["lastitemid"].ToString();
																																model.lastwrongid= dt.Rows[n]["lastwrongid"].ToString();
																						
				
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}
#endregion
   
	}
}