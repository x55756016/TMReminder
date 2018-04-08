using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model{
	 	//tm_qa_userpaperrecord
		public class tm_qa_userpaperrecord
	{
   		     
      	/// <summary>
		/// recordid
        /// </summary>		
		private string _recordid;
        public string recordid
        {
            get{ return _recordid; }
            set{ _recordid = value; }
        }        
		/// <summary>
		/// userid
        /// </summary>		
		private string _userid;
        public string userid
        {
            get{ return _userid; }
            set{ _userid = value; }
        }        
		/// <summary>
		/// subjectid
        /// </summary>		
		private string _subjectid;
        public string subjectid
        {
            get{ return _subjectid; }
            set{ _subjectid = value; }
        }        
		/// <summary>
		/// paperid
        /// </summary>		
		private string _paperid;
        public string paperid
        {
            get{ return _paperid; }
            set{ _paperid = value; }
        }        
		/// <summary>
		/// lastitemid
        /// </summary>		
		private string _lastitemid;
        public string lastitemid
        {
            get{ return _lastitemid; }
            set{ _lastitemid = value; }
        }        
		/// <summary>
		/// lastwrongid
        /// </summary>		
		private string _lastwrongid;
        public string lastwrongid
        {
            get{ return _lastwrongid; }
            set{ _lastwrongid = value; }
        }        
		   
	}
}

