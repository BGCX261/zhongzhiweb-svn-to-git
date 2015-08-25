using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Cms.Web.UI;
using Maticsoft.Common;
using System.Collections;

namespace Cms.Web.Admin.Channel
{
    public partial class List : ManagePage
    {
        Cms.DAL.Channel dal = new Cms.DAL.Channel();
        protected void Page_Load(object sender, EventArgs e)
        {
            //取得栏目传参
            if (!Page.IsPostBack)
            {
                //数据绑定
                BindData();
            }
        }

        //数据绑定
        private void BindData()
        {
            DataSet newsDS = dal.GetNewsClassList("");
            DataTable dt = newsDS.Tables[0];
            this.rptClassList.DataSource = dt;
            this.rptClassList.DataBind();
        }

        //删除操作
        protected void rptClassList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField txtClassId = (HiddenField)e.Item.FindControl("txtClassId");
            switch (e.CommandName.ToLower())
            {
                case "btndel":
                    //删除记录
                    dal.DeleteNewsClass(Convert.ToInt32(txtClassId.Value));
                    //重新绑定数据
                    BindData();
                    MessageBox.Show(this, "删除栏目成功！");
                    break;
                case "ibtnup":
                    {
                        DataSet newsDS = dal.GetNewsClassList("");
                        DataTable dt = newsDS.Tables[0];
                        ArrayList idList = new ArrayList();
                        int curID = Convert.ToInt32(txtClassId.Value);
                        for (int i = 0; i < dt.Rows.Count; ++i)
                        {
                            DataRow dr = dt.Rows[i];
                            int id = Convert.ToInt32(dr["ClassID"]);
                            idList.Add(id);
                        }
                        int index = idList.IndexOf(curID);
                        if (index != -1)
                        {
                            idList.RemoveAt(index);
                            int instIdx = index - 1;
                            if (instIdx < 0)
                                instIdx = 0;
                            idList.Insert(instIdx, curID);
                        }
                        for (int i = 0; i < idList.Count; ++i)
                        {
                            int id = (int)idList[i];
                            dal.UpdateNewsClassField(id, "ClassOrder = '" + i.ToString() + "'");
                        }
                        BindData();
                    }
                    break;
                case "ibtndown":
                    {
                        DataSet newsDS = dal.GetNewsClassList("");
                        DataTable dt = newsDS.Tables[0];
                        ArrayList idList = new ArrayList();
                        int curID = Convert.ToInt32(txtClassId.Value);
                        for (int i = 0; i < dt.Rows.Count; ++i)
                        {
                            DataRow dr = dt.Rows[i];
                            int id = Convert.ToInt32(dr["ClassID"]);
                            idList.Add(id);
                        }
                        int index = idList.IndexOf(curID);
                        if (index != -1)
                        {
                            idList.RemoveAt(index);
                            int instIdx = index + 1;
                            if (instIdx > idList.Count)
                                instIdx = idList.Count;
                            idList.Insert(instIdx, curID);
                        }
                        for (int i = 0; i < idList.Count; ++i)
                        {
                            int id = (int)idList[i];
                            dal.UpdateNewsClassField(id, "ClassOrder = '" + i.ToString() + "'");
                        }
                        BindData();
                    }
                    break;
            }
        }
        //美化列表
        protected void rptClassList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");
                string LitImg1 = "<img src=../images/folder_open.gif align=absmiddle />";
                LitFirst.Text = LitImg1;
            }
        }
    }
}