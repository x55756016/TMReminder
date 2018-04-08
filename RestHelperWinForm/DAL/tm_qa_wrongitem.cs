using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using System.Data.SQLite;
using Maticsoft.DBUtility;
using System.Windows.Forms;
namespace Maticsoft.DAL  
{
	 	//tm_qa_wrongitem
		public partial class tm_qa_wrongitem
	{
            public tm_qa_wrongitem()
            {
                DbHelperSQLite.connectionString = "Data Source=" + Application.StartupPath + @"\taskDB.s3db";
            }
   		     
		public bool Exists(string wrongid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tm_qa_wrongitem");
			strSql.Append(" where ");
			                                       strSql.Append(" wrongid = @wrongid  ");
                            			SQLiteParameter[] parameters = {
					new SQLiteParameter("@wrongid", DbType.String,50)			};
			parameters[0].Value = wrongid;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.tm_qa_wrongitem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tm_qa_wrongitem(");			
            strSql.Append("wrongid,itemid,ordernumber,isdelete,wrongnumber");
			strSql.Append(") values (");
            strSql.Append("@wrongid,@itemid,@ordernumber,@isdelete,@wrongnumber");            
            strSql.Append(") ");            
            		
			SQLiteParameter[] parameters = {
			            new SQLiteParameter("@wrongid", DbType.String,50) ,            
                        new SQLiteParameter("@itemid", DbType.String,50) ,            
                        new SQLiteParameter("@ordernumber", DbType.Decimal,8) ,            
                        new SQLiteParameter("@isdelete", DbType.String,50) ,            
                        new SQLiteParameter("@wrongnumber", DbType.Int32,4)             
              
            };
			            
            parameters[0].Value = model.wrongid;                        
            parameters[1].Value = model.itemid;                        
            parameters[2].Value = model.ordernumber;                        
            parameters[3].Value = model.isdelete;                        
            parameters[4].Value = model.wrongnumber;                        
			            DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.tm_qa_wrongitem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tm_qa_wrongitem set ");
			                        
            strSql.Append(" wrongid = @wrongid , ");                                    
            strSql.Append(" itemid = @itemid , ");                                    
            strSql.Append(" ordernumber = @ordernumber , ");                                    
            strSql.Append(" isdelete = @isdelete , ");                                    
            strSql.Append(" wrongnumber = @wrongnumber  ");            			
			strSql.Append(" where wrongid=@wrongid  ");
						
SQLiteParameter[] parameters = {
			            new SQLiteParameter("@wrongid", DbType.String,50) ,            
                        new SQLiteParameter("@itemid", DbType.String,50) ,            
                        new SQLiteParameter("@ordernumber", DbType.Decimal,8) ,            
                        new SQLiteParameter("@isdelete", DbType.String,50) ,            
                        new SQLiteParameter("@wrongnumber", DbType.Int32,4)             
              
            };
						            
            parameters[0].Value = model.wrongid;                        
            parameters[1].Value = model.itemid;                        
            parameters[2].Value = model.ordernumber;                        
            parameters[3].Value = model.isdelete;                        
            parameters[4].Value = model.wrongnumber;                        
            int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string wrongid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tm_qa_wrongitem ");
			strSql.Append(" where wrongid=@wrongid ");
						SQLiteParameter[] parameters = {
					new SQLiteParameter("@wrongid", DbType.String,50)			};
			parameters[0].Value = wrongid;


			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
				
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.tm_qa_wrongitem GetModel(string wrongid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select wrongid, itemid, ordernumber, isdelete, wrongnumber  ");			
			strSql.Append("  from tm_qa_wrongitem ");
			strSql.Append(" where wrongid=@wrongid ");
						SQLiteParameter[] parameters = {
					new SQLiteParameter("@wrongid", DbType.String,50)			};
			parameters[0].Value = wrongid;

			
			Maticsoft.Model.tm_qa_wrongitem model=new Maticsoft.Model.tm_qa_wrongitem();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
																model.wrongid= ds.Tables[0].Rows[0]["wrongid"].ToString();
																																model.itemid= ds.Tables[0].Rows[0]["itemid"].ToString();
																												if(ds.Tables[0].Rows[0]["ordernumber"].ToString()!="")
				{
					model.ordernumber=decimal.Parse(ds.Tables[0].Rows[0]["ordernumber"].ToString());
				}
																																				model.isdelete= ds.Tables[0].Rows[0]["isdelete"].ToString();
																												if(ds.Tables[0].Rows[0]["wrongnumber"].ToString()!="")
				{
					model.wrongnumber=int.Parse(ds.Tables[0].Rows[0]["wrongnumber"].ToString());
				}
																														
				return model;
			}
			else
			{
				return null;
			}
		}
		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM tm_qa_wrongitem ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQLite.Query(strSql.ToString());
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM tm_qa_wrongitem ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQLite.Query(strSql.ToString());
		}

   
	}
}

