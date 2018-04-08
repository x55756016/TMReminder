using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model{
	 	//tm_qa_wrongitem
		public class tm_qa_wrongitem
	{
   		     
      	/// <summary>
		/// wrongid
        /// </summary>		
		private string _wrongid;
        public string wrongid
        {
            get{ return _wrongid; }
            set{ _wrongid = value; }
        }        
		/// <summary>
		/// itemid
        /// </summary>		
		private string _itemid;
        public string itemid
        {
            get{ return _itemid; }
            set{ _itemid = value; }
        }        
		/// <summary>
		/// ordernumber
        /// </summary>		
		private decimal _ordernumber;
        public decimal ordernumber
        {
            get{ return _ordernumber; }
            set{ _ordernumber = value; }
        }        
		/// <summary>
		/// isdelete
        /// </summary>		
		private string _isdelete;
        public string isdelete
        {
            get{ return _isdelete; }
            set{ _isdelete = value; }
        }        
		/// <summary>
		/// wrongnumber
        /// </summary>		
		private int _wrongnumber;
        public int wrongnumber
        {
            get{ return _wrongnumber; }
            set{ _wrongnumber = value; }
        }        
		   
	}
}

