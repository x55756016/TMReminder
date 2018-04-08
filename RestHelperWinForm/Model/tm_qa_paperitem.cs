using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model{
	 	//tm_qa_paperitem
		public class tm_qa_paperitem
	{
   		     
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
		/// eword
        /// </summary>		
		private string _eword;
        public string eword
        {
            get{ return _eword; }
            set{ _eword = value; }
        }        
		/// <summary>
		/// cword
        /// </summary>		
		private string _cword;
        public string cword
        {
            get{ return _cword; }
            set{ _cword = value; }
        }        
		/// <summary>
		/// sentence
        /// </summary>		
		private string _sentence;
        public string sentence
        {
            get{ return _sentence; }
            set{ _sentence = value; }
        }        
		   
	}
}

