using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Windows.Forms;
namespace Maticsoft.DAL  
{
	 	//tm_qa_userpaperrecord
		public partial class tm_qa_userpaperrecord
	{
            public tm_qa_userpaperrecord()
            {
                DbHelperSQLite.connectionString = "Data Source=" + Application.StartupPath + @"\taskDB.s3db";
            }
   		     
		public bool Exists(string recordid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tm_qa_userpaperrecord");
			strSql.Append(" where ");
			                                       strSql.Append(" recordid = @recordid  ");
                            			SQLiteParameter[] parameters = {
					new SQLiteParameter("@recordid", DbType.String,50)			};
			parameters[0].Value = recordid;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.tm_qa_userpaperrecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tm_qa_userpaperrecord(");			
            strSql.Append("recordid,userid,subjectid,paperid,lastitemid,lastwrongid");
			strSql.Append(") values (");
            strSql.Append("@recordid,@userid,@subjectid,@paperid,@lastitemid,@lastwrongid");            
            strSql.Append(") ");

            SQLiteParameter[] parameters = {
			            new SQLiteParameter("@recordid", DbType.String,50) ,            
                        new SQLiteParameter("@userid", DbType.String,50) ,            
                        new SQLiteParameter("@subjectid", DbType.String,50) ,            
                        new SQLiteParameter("@paperid", DbType.String,50) ,            
                        new SQLiteParameter("@lastitemid", DbType.String,50) ,            
                        new SQLiteParameter("@lastwrongid", DbType.String,50)             
              
            };
			            
            parameters[0].Value = model.recordid;                        
            parameters[1].Value = model.userid;                        
            parameters[2].Value = model.subjectid;                        
            parameters[3].Value = model.paperid;                        
            parameters[4].Value = model.lastitemid;                        
            parameters[5].Value = model.lastwrongid;                        
			            DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.tm_qa_userpaperrecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tm_qa_userpaperrecord set ");
			                        
            strSql.Append(" recordid = @recordid , ");                                    
            strSql.Append(" userid = @userid , ");                                    
            strSql.Append(" subjectid = @subjectid , ");                                    
            strSql.Append(" paperid = @paperid , ");                                    
            strSql.Append(" lastitemid = @lastitemid , ");                                    
            strSql.Append(" lastwrongid = @lastwrongid  ");            			
			strSql.Append(" where recordid=@recordid  ");
						
SQLiteParameter[] parameters = {
			            new SQLiteParameter("@recordid", DbType.String,50) ,            
                        new SQLiteParameter("@userid", DbType.String,50) ,            
                        new SQLiteParameter("@subjectid", DbType.String,50) ,            
                        new SQLiteParameter("@paperid", DbType.String,50) ,            
                        new SQLiteParameter("@lastitemid", DbType.String,50) ,            
                        new SQLiteParameter("@lastwrongid", DbType.String,50)             
              
            };
						            
            parameters[0].Value = model.recordid;                        
            parameters[1].Value = model.userid;                        
            parameters[2].Value = model.subjectid;                        
            parameters[3].Value = model.paperid;                        
            parameters[4].Value = model.lastitemid;                        
            parameters[5].Value = model.lastwrongid;                        
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
		public bool Delete(string recordid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tm_qa_userpaperrecord ");
			strSql.Append(" where recordid=@recordid ");
						SQLiteParameter[] parameters = {
					new SQLiteParameter("@recordid", DbType.String,50)			};
			parameters[0].Value = recordid;


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
		public Maticsoft.Model.tm_qa_userpaperrecord GetModel(string recordid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select recordid, userid, subjectid, paperid, lastitemid, lastwrongid  ");			
			strSql.Append("  from tm_qa_userpaperrecord ");
			strSql.Append(" where recordid=@recordid ");
						SQLiteParameter[] parameters = {
					new SQLiteParameter("@recordid", DbType.String,50)			};
			parameters[0].Value = recordid;

			
			Maticsoft.Model.tm_qa_userpaperrecord model=new Maticsoft.Model.tm_qa_userpaperrecord();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
																model.recordid= ds.Tables[0].Rows[0]["recordid"].ToString();
																																model.userid= ds.Tables[0].Rows[0]["userid"].ToString();
																																model.subjectid= ds.Tables[0].Rows[0]["subjectid"].ToString();
																																model.paperid= ds.Tables[0].Rows[0]["paperid"].ToString();
																																model.lastitemid= ds.Tables[0].Rows[0]["lastitemid"].ToString();
																																model.lastwrongid= ds.Tables[0].Rows[0]["lastwrongid"].ToString();
																										
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
			strSql.Append(" FROM tm_qa_userpaperrecord ");
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
			strSql.Append(" FROM tm_qa_userpaperrecord ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQLite.Query(strSql.ToString());
		}

   
	}
}

