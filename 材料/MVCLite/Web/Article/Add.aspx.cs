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
namespace MVCLite.Web.Article
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtID.Text))
			{
				strErr+="ID格式错误！\\n";	
			}
			if(this.txtTitle.Text.Trim().Length==0)
			{
				strErr+="Title不能为空！\\n";	
			}
			if(this.txtContent.Text.Trim().Length==0)
			{
				strErr+="Content不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtlevelMax.Text))
			{
				strErr+="levelMax格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtCID.Text))
			{
				strErr+="CID格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtAddTime.Text))
			{
				strErr+="AddTime格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtModifytime.Text))
			{
				strErr+="Modifytime格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtclick.Text))
			{
				strErr+="click格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int ID=int.Parse(this.txtID.Text);
			string Title=this.txtTitle.Text;
			string Content=this.txtContent.Text;
			int levelMax=int.Parse(this.txtlevelMax.Text);
			int CID=int.Parse(this.txtCID.Text);
			DateTime AddTime=DateTime.Parse(this.txtAddTime.Text);
			DateTime Modifytime=DateTime.Parse(this.txtModifytime.Text);
			int click=int.Parse(this.txtclick.Text);

			MVCLite.Model.Article model=new MVCLite.Model.Article();
			model.ID=ID;
			model.Title=Title;
			model.Content=Content;
			model.levelMax=levelMax;
			model.CID=CID;
			model.AddTime=AddTime;
			model.Modifytime=Modifytime;
			model.click=click;

			MVCLite.BLL.Article bll=new MVCLite.BLL.Article();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
