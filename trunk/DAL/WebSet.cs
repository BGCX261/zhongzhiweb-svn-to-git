using System;
using System.Collections.Generic;
using System.Text;
using Cms.Common;
using Cms.Model;

namespace Cms.DAL
{
    public class WebSet
    {
        private static object lockHelper = new object();

        /// <summary>
        ///  读取配置文件
        /// </summary>
        /// <param name="configFilePath"></param>
        /// <returns></returns>
        public Model.WebSet loadConfig(string configFilePath)
        {
            return (Model.WebSet)SerializationHelper.Load(typeof(Model.WebSet), configFilePath);
        }

        public Model.WebSet saveConifg(Model.WebSet mode, string configFilePath)
        {
            lock (lockHelper)
            {
                SerializationHelper.Save(mode, configFilePath);
                //WgCms.Dal.Providers.webSetProvider.SetInstance(mode);
            }
            return mode;
        }
    }
}
