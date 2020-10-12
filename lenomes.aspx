<script language="C#" runat="server">
 public void Page_Load(Object sender, EventArgs ea){
  string msg;
  msg = readDB();
  Response.Write(msg + "$");  
 }
 string readDB(){ 
 string select = "SELECT * FROM jogadores";  
  
 System.Data.OleDb.OleDbConnection oConn = new System.Data.OleDb.OleDbConnection(); 
 oConn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("/data/db1.mdb"); 
   
  oConn.Open(); 
   
   System.Data.DataSet ds = new System.Data.DataSet(); 
   System.Data.OleDb.OleDbDataAdapter datadapt = new System.Data.OleDb.OleDbDataAdapter(select, oConn); 
   datadapt.Fill(ds, "jog"); 
   System.Data.DataSet dsT = new System.Data.DataSet();
   dsT = ds; 
   
   string list = " ";
   for(int i=0; i<dsT.Tables["jog"].Rows.Count; i++){
     list = list +  dsT.Tables["jog"].Rows[i]["nome"].ToString().Replace("_"," ")  + "\n";
   }
  return list;
}
 
</script>