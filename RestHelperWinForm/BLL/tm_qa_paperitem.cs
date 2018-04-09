using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL {
	 	//tm_qa_paperitem
		public partial class tm_qa_paperitemBLL
	{
   		     
		private readonly Maticsoft.DAL.tm_qa_paperitem dal=new Maticsoft.DAL.tm_qa_paperitem();
        public tm_qa_paperitemBLL()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string itemid)
		{
			return dal.Exists(itemid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(Maticsoft.Model.tm_qa_paperitem model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.tm_qa_paperitem model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string itemid)
		{
			
			return dal.Delete(itemid);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.tm_qa_paperitem GetModel(string itemid)
		{			
			return dal.GetModel(itemid);
		}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.tm_qa_paperitem GetModelByOrderNumber(string ordernumber)
        {
            return dal.GetModelByOrderNumber(ordernumber);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.tm_qa_paperitem GetModelByCache(string itemid)
		{
			
			string CacheKey = "tm_qa_paperitemModel-" + itemid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(itemid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.tm_qa_paperitem)objModel;
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
		public List<Maticsoft.Model.tm_qa_paperitem> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.tm_qa_paperitem> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.tm_qa_paperitem> modelList = new List<Maticsoft.Model.tm_qa_paperitem>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.tm_qa_paperitem model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.tm_qa_paperitem();					
																	model.itemid= dt.Rows[n]["itemid"].ToString();
																												if(dt.Rows[n]["ordernumber"].ToString()!="")
				{
					model.ordernumber=decimal.Parse(dt.Rows[n]["ordernumber"].ToString());
				}
																																				model.eword= dt.Rows[n]["eword"].ToString();
																																model.cword= dt.Rows[n]["cword"].ToString();
																																model.sentence= dt.Rows[n]["sentence"].ToString();
																						
				
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