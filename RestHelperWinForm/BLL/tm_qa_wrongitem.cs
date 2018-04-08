using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL {
	 	//tm_qa_wrongitem
		public partial class tm_qa_wrongitemBLL
	{
   		     
		private readonly Maticsoft.DAL.tm_qa_wrongitem dal=new Maticsoft.DAL.tm_qa_wrongitem();
        public tm_qa_wrongitemBLL()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string wrongid)
		{
			return dal.Exists(wrongid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(Maticsoft.Model.tm_qa_wrongitem model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.tm_qa_wrongitem model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string wrongid)
		{
			
			return dal.Delete(wrongid);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.tm_qa_wrongitem GetModel(string wrongid)
		{
			
			return dal.GetModel(wrongid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.tm_qa_wrongitem GetModelByCache(string wrongid)
		{
			
			string CacheKey = "tm_qa_wrongitemModel-" + wrongid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(wrongid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.tm_qa_wrongitem)objModel;
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
		public List<Maticsoft.Model.tm_qa_wrongitem> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.tm_qa_wrongitem> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.tm_qa_wrongitem> modelList = new List<Maticsoft.Model.tm_qa_wrongitem>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.tm_qa_wrongitem model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.tm_qa_wrongitem();					
																	model.wrongid= dt.Rows[n]["wrongid"].ToString();
																																model.itemid= dt.Rows[n]["itemid"].ToString();
																												if(dt.Rows[n]["ordernumber"].ToString()!="")
				{
					model.ordernumber=decimal.Parse(dt.Rows[n]["ordernumber"].ToString());
				}
																																				model.isdelete= dt.Rows[n]["isdelete"].ToString();
																												if(dt.Rows[n]["wrongnumber"].ToString()!="")
				{
					model.wrongnumber=int.Parse(dt.Rows[n]["wrongnumber"].ToString());
				}
																										
				
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