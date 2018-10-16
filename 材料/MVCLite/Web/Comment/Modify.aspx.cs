using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace MVCLite.Web.Comment
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(ID);
				}
			}
		}
			
	private void ShowInfo(int ID)
	{
		MVCLite.BLL.Comment bll=new MVCLite.BLL.Comment();
		MVCLite.Model.Comment model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.txtContent.Text=model.Content;
		this.txtuserid.Text=model.userid.ToString();
		this.txtPID.Text=model.PID.ToString();
		this.txtusername.Text=model.username;
		this.txtAddTime.Text=model.AddTime.ToString();
		this.txtstatus.Text=model.status.ToString();
		this.txtarticleid.Text=model.articleid.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtContent.Text.Trim().Length==0)
			{
				strErr+="Content不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtuserid.Text))
			{
				strErr+="userid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtPID.Text))
			{
				strErr+="PID格式错误！\\n";	
			}
			if(this.txtusername.Text.Trim().Length==0)
			{
				strErr+="username不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtAddTime.Text))
			{
				strErr+="AddTime格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtstatus.Text))
			{
				strErr+="status格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtarticleid.Text))
			{
				strErr+="articleid格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int ID=int.Parse(this.lblID.Text);
			string Content=this.txtContent.Text;
			int userid=int.Parse(this.txtuserid.Text);
			int PID=int.Parse(this.txtPID.Text);
			string username=this.txtusername.Text;
			DateTime AddTime=DateTime.Parse(this.txtAddTime.Text);
			int status=int.Parse(this.txtstatus.Text);
			int articleid=int.Parse(this.txtarticleid.Text);


			MVCLite.Model.Comment model=new MVCLite.Model.Comment();
			model.ID=ID;
			model.Content=Content;
			model.userid=userid;
			model.PID=PID;
			model.username=username;
			model.AddTime=AddTime;
			model.status=status;
			model.articleid=articleid;

			MVCLite.BLL.Comment bll=new MVCLite.BLL.Comment();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
