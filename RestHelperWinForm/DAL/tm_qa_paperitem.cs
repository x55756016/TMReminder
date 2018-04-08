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
	 	//tm_qa_paperitem
		public partial class tm_qa_paperitem
	{
            public tm_qa_paperitem()
            {
                DbHelperSQLite.connectionString = "Data Source=" + Application.StartupPath + @"\taskDB.s3db";
            }
            
   		     
		public bool Exists(string itemid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tm_qa_paperitem");
			strSql.Append(" where ");
			                                       strSql.Append(" itemid = @itemid  ");
                            			SQLiteParameter[] parameters = {
					new SQLiteParameter("@itemid", DbType.String,50)			};
			parameters[0].Value = itemid;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.tm_qa_paperitem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tm_qa_paperitem(");			
            strSql.Append("itemid,ordernumber,eword,cword,sentence");
			strSql.Append(") values (");
            strSql.Append("@itemid,@ordernumber,@eword,@cword,@sentence");            
            strSql.Append(") ");            
            		
			SQLiteParameter[] parameters = {
			            new SQLiteParameter("@itemid", DbType.String,50) ,            
                        new SQLiteParameter("@ordernumber", DbType.Decimal,8) ,            
                        new SQLiteParameter("@eword", DbType.String,200) ,            
                        new SQLiteParameter("@cword", DbType.String,200) ,            
                        new SQLiteParameter("@sentence", DbType.String,2000)             
              
            };
			            
            parameters[0].Value = model.itemid;                        
            parameters[1].Value = model.ordernumber;                        
            parameters[2].Value = model.eword;                        
            parameters[3].Value = model.cword;                        
            parameters[4].Value = model.sentence;                        
			            DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.tm_qa_paperitem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tm_qa_paperitem set ");
			                        
            strSql.Append(" itemid = @itemid , ");                                    
            strSql.Append(" ordernumber = @ordernumber , ");                                    
            strSql.Append(" eword = @eword , ");                                    
            strSql.Append(" cword = @cword , ");                                    
            strSql.Append(" sentence = @sentence  ");            			
			strSql.Append(" where itemid=@itemid  ");
						
SQLiteParameter[] parameters = {
			            new SQLiteParameter("@itemid", DbType.String,50) ,            
                        new SQLiteParameter("@ordernumber", DbType.Decimal,8) ,            
                        new SQLiteParameter("@eword", DbType.String,200) ,            
                        new SQLiteParameter("@cword", DbType.String,200) ,            
                        new SQLiteParameter("@sentence", DbType.String,2000)             
              
            };
						            
            parameters[0].Value = model.itemid;                        
            parameters[1].Value = model.ordernumber;                        
            parameters[2].Value = model.eword;                        
            parameters[3].Value = model.cword;                        
            parameters[4].Value = model.sentence;                        
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
		public bool Delete(string itemid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tm_qa_paperitem ");
			strSql.Append(" where itemid=@itemid ");
						SQLiteParameter[] parameters = {
					new SQLiteParameter("@itemid", DbType.String,50)			};
			parameters[0].Value = itemid;


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
		public Maticsoft.Model.tm_qa_paperitem GetModel(string itemid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select itemid, ordernumber, eword, cword, sentence  ");			
			strSql.Append("  from tm_qa_paperitem ");
			strSql.Append(" where itemid=@itemid ");
						SQLiteParameter[] parameters = {
					new SQLiteParameter("@itemid", DbType.String,50)			};
			parameters[0].Value = itemid;

			
			Maticsoft.Model.tm_qa_paperitem model=new Maticsoft.Model.tm_qa_paperitem();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
																model.itemid= ds.Tables[0].Rows[0]["itemid"].ToString();
																												if(ds.Tables[0].Rows[0]["ordernumber"].ToString()!="")
				{
					model.ordernumber=decimal.Parse(ds.Tables[0].Rows[0]["ordernumber"].ToString());
				}
																																				model.eword= ds.Tables[0].Rows[0]["eword"].ToString();
																																model.cword= ds.Tables[0].Rows[0]["cword"].ToString();
																																model.sentence= ds.Tables[0].Rows[0]["sentence"].ToString();
																										
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
			strSql.Append(" FROM tm_qa_paperitem ");
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
			strSql.Append(" FROM tm_qa_paperitem ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQLite.Query(strSql.ToString());
		}

   
	}
}

